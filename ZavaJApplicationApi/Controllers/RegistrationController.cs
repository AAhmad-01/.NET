using Azure;
using ContosoUniversity.DAL;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Claims;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Twilio.Rest.Api.V2010.Account;
using ZavaJApplicationApi.Common;
using ZavaJApplicationApi.DAL;
using ZavaJApplicationApi.GenericRepository;
using ZavaJApplicationApi.LocationServices;
using ZavaJApplicationApi.Model;
using static System.Net.WebRequestMethods;

namespace ZavaJApplicationApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IdentityDBContext _dbContext;
        private UnitOfWork _unitOfWork;
        User user = new User();

        LocationService locationService = new LocationService();
        public RegistrationController(IdentityDBContext dbContext)
        {
            _dbContext = dbContext;
            _unitOfWork = new UnitOfWork(_dbContext);


        }


        [HttpGet]
        [Route("SendEmail")]
        public void SendEmail(string email)
        {

            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Zavaj Application", "hhhh"));
                message.To.Add(new MailboxAddress("Ammar", "ammarzulfiqar2000@gmail.com"));
                message.Subject = "Zavaj Application";
                message.Body = new TextPart("plain")
                {
                    Text = "Hello !!! your otp code is Generated!!!"
                };

                using var client = new SmtpClient();
                client.Connect("smtpout.secureserver.net", 465, true);
                client.Authenticate("contact@zavaj.net", "Z123@1");
                client.Send(message);
                client.Disconnect(true);

                // Disconnect from the SMTP servere
                client.Disconnect(true);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }

        }

        private string GenerateRandomOTP()
        {
            const string chars = "0123456789";
            var random = new Random();
            var otp = new string(Enumerable.Repeat(chars, 6) // Generate a 6-digit OTP
                .Select(s => s[random.Next(s.Length)])
                .ToArray());

            return otp;
        }
        [HttpPost]
        [Route("generateOtp")]
        public async Task<IActionResult> GenerateOTP()
        {
            var commonClass = new CommonClass();
          
            // Read the form data
            var formCollection = await Request.ReadFormAsync();

            // Retrieve the value of the 'email' field from the form data
            string email = formCollection["email"];
            if (string.IsNullOrEmpty(email))
            {
                // Check if the email field is present in the request body
                var emailField = formCollection.FirstOrDefault(field => field.Key.ToLower() == "email");
                if (emailField.Equals(default(KeyValuePair<string, StringValues>)))
                {
                    return BadRequest("The 'email' field is missing.");
                }
                else
                {
                    email = emailField.Value;
                }
            }

            string generatedOtp = GenerateRandomOTP();
            ClaimsPrincipal currentUser = HttpContext.User;

            // Generate a random OTP
            var otpModel = new OtpTable
            {
                email = email,
                IsCodeVerified = false,
                CreateDateTime = DateTime.Now,
                OtpCode = int.Parse(generatedOtp), // Implement this method to generate the OTP
                ExpirationTime = DateTime.UtcNow.AddMinutes(5) // Set an expiration time (e.g., 5 minutes)
            };

            try
            {
                _unitOfWork.OtpRepository.Insert(otpModel);
                return Ok(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return Ok(false);
            }
        }

        bool isEmailOtpVerified(string userEmail,int otp )
        {
            var currentDateTimeUtc = DateTime.UtcNow;
            var   userOTP = _dbContext.OtpTable.FirstOrDefault(o => o.email == userEmail && o.OtpCode == otp && o.ExpirationTime > currentDateTimeUtc);
                if(userOTP != null)
                {
                    return true;
                }
                return false;
            
        }

        [HttpPost]
        [Route("verifyOtp")]
        public IActionResult VerifyOTP(int otp, string? userEmail, string? phoneNumber) {
            ClaimsPrincipal currentUser = HttpContext.User;
            var currentDateTimeUtc = DateTime.UtcNow;
            var model = _unitOfWork.UserRepository.GetById(18);
            OtpTable? userOTP = null;
            if (userEmail != null)
            {
                userOTP = _dbContext.OtpTable.FirstOrDefault(o => o.email == userEmail && o.OtpCode == otp && o.ExpirationTime > currentDateTimeUtc);
                model.IsEmailVerified = true;
            }

            else if (phoneNumber != null)
            {
                userOTP = _dbContext.OtpTable.FirstOrDefault(o => o.phoneNumber == phoneNumber && o.OtpCode == otp && o.ExpirationTime > currentDateTimeUtc);
                model.IsPhoneNumberVerfied = true;

            }
          
            if (userOTP != null)
            {
                _unitOfWork.UserRepository.Update(model);
                _dbContext.SaveChanges();
                return Ok("OTP verified successfully!");
            }


            // OTP is invalid or expired
            return BadRequest("Invalid OTP or expired.");
        }

        [HttpPost]
        [Route("registerationStep1")]

        public async Task<IActionResult> RegisterationStepOneAsync() {
              var formCollection = await Request.ReadFormAsync();
                  var  gender = formCollection.FirstOrDefault(field => field.Key.ToLower() == "gender");
            var name = formCollection.FirstOrDefault(field => field.Key.ToLower() == "name");
            var dateOfBirth = formCollection.FirstOrDefault(field => field.Key.ToLower() == "dob");
            var otp = formCollection.FirstOrDefault(field => field.Key.ToLower() == "otp");
            var currentUserEmail = formCollection.FirstOrDefault(field => field.Key.ToLower() == "email");
            if (gender.Equals(default(KeyValuePair<string, StringValues>)))
                {
                    return BadRequest("The 'gender' field is missing.");
                }
            if (name.Equals(default(KeyValuePair<string, StringValues>)))
            {
                return BadRequest("The 'name' field is missing.");
            }
            if (dateOfBirth.Equals(default(KeyValuePair<string, StringValues>)))
            {
                return BadRequest("The 'Date of Birth' field is missing.");
            }
            if (otp.Equals(default(KeyValuePair<string, StringValues>)))
            {
                return BadRequest("The 'Otp' field is missing.");
            }
            if(isEmailOtpVerified(currentUserEmail.Value, int.Parse(otp.Value)))
            {
                try
                {
                    /* user.Id = Guid.NewGuid(),*/
                    DateTime dOB = DateTime.ParseExact(dateOfBirth.Value, "dd/MM/yyyy", null); ;
                    user.Gender = gender.Value;
                    user.UserName = name.Value;
                    user.DateOfBirth = dOB;
                    user.StepsCompleted = 1;
                    user.EmailAddress = currentUserEmail.Value;
                    user.IsEmailVerified = true;
                    _unitOfWork.UserRepository.Insert(user);
                    _unitOfWork.Save(); ;
                    return Ok(true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    return BadRequest(ex.Message);

                }
            }

            return BadRequest("Email not Verified");


        }
        [HttpPost]
        [Route("registerationStep2")]
        public async Task<IActionResult> RegisterationStepTwoAsync(int sectId, int professionId, int ethnicGroupId, int educationLevelId, IFormFile file)
        {
                try
                {
                if (file != null && file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await file.CopyToAsync(ms);
                        byte[] profilePictureBytes = ms.ToArray();
                        user.ProfilePicture = profilePictureBytes.ToString();
                        // Assuming you have a database context set up with Entity Framework Core
                        /*      using (var dbContext = new YourDbContext())
                              {
                                  var user = dbContext.Users.FirstOrDefault(); // Replace with appropriate logic to get the user

                                  if (user != null)
                                  {
                                      user.ProfilePicture = profilePictureBytes;
                                      await dbContext.SaveChangesAsync();
                                  }
                              }*/
                    }
                }
               
                var model = _unitOfWork.UserRepository.GetById(18);
                    model.SectId = sectId;
                    model.ProfessionId = professionId;
                    model.EthnicGroupId = ethnicGroupId;
                    model.EducationLevelId = educationLevelId;
                model.StepsCompleted = 2;
                model.ProfilePicture = user.ProfilePicture;
                    _unitOfWork.UserRepository.Update(model);
                    _dbContext.SaveChanges();
                    return Ok(true);
                
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    throw;
                }

                
        } 


        [HttpPost]
        [Route("addMorePhotoes")]
        [HttpPost]
        public async Task<IActionResult> UploadProfilePictures(List<IFormFile> files)
        {
            if (files != null && files.Count > 0)
            {
                using (var dbContext = _dbContext)
                {
                    var user = dbContext.Users.FirstOrDefault(); // Replace with appropriate logic to get the user

                    if (user != null)
                    {
                        foreach (var file in files)
                        {
                            if (file != null && file.Length > 0)
                            {
                                using (var ms = new MemoryStream())
                                {
                                    await file.CopyToAsync(ms);
                                    byte[] profilePictureBytes = ms.ToArray();

                                    // Save each profile picture to the database or perform desired operations
                                    // For example, you can create a separate table for profile pictures
                               /*     var profilePicture = new ProfilePicture
                                    {
                                        UserId = user.Id,
                                        PictureData = profilePictureBytes
                                    };

                                    dbContext.ProfilePictures.Add(profilePicture);*/
                                }
                            }
                        }

                        await dbContext.SaveChangesAsync();
                    }
                }
            }

            // Return appropriate response or redirect
            return Ok();
        }




        [HttpPost]
        [Route("addPhoneNumber")]

        public IActionResult AddPhoneNumber(int phoneNumber)
        {
            try
            {
                string accountSid = Environment.GetEnvironmentVariable("ACeaeaf0c0f46eaa74ca0676db475776a8");
                string authToken = Environment.GetEnvironmentVariable("4cb6fdeb72e61748e6eb634a90ff86dc");

                Twilio.TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                    body: "Hi there",
                    from: new Twilio.Types.PhoneNumber("+13252526750"),
                    to: new Twilio.Types.PhoneNumber("+923174458066")
                );
                var commonClass = new CommonClass();
                string generatedOtp = GenerateRandomOTP();
                ClaimsPrincipal currentUser = HttpContext.User;
                // Generate a random OTP
                var otp = new OtpTable
                {
                    phoneNumber= phoneNumber.ToString(),
                    IsCodeVerified = false,
                    CreateDateTime = DateTime.Now,
                    OtpCode = int.Parse(generatedOtp), // Implement this method to generate the OTP
                    ExpirationTime = DateTime.UtcNow.AddMinutes(5) // Set an expiration time (e.g., 5 minutes)
                };
                return Ok(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                throw;
            }
        }

        [HttpPost]
        [Route("addUserLocation")]

        public IActionResult AddUserLocation(string latitude, string longitude)
        {
            string coordinate = $"{latitude},{longitude}"; //Console.ReadLine();
            string apiKey = "YOUR_API_KEY";
            string url = "https://maps.googleapis.com/maps/api/geocode/xml?latlng=" + coordinate + "&key=" + apiKey;
            
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(url);
            XmlNodeList xNodelst = xDoc.GetElementsByTagName("result");
            XmlNode xNode = xNodelst.Item(0);
            string FullAddress = xNode.SelectSingleNode("formatted_address").InnerText;
            string Number = xNode.SelectSingleNode("address_component[1]/long_name").InnerText;
            string Street = xNode.SelectSingleNode("address_component[2]/long_name").InnerText;
            string Village = xNode.SelectSingleNode("address_component[3]/long_name").InnerText;
            string Area = xNode.SelectSingleNode("address_component[4]/long_name").InnerText;
            string County = xNode.SelectSingleNode("address_component[5]/long_name").InnerText;
            string State = xNode.SelectSingleNode("address_component[6]/long_name").InnerText;
            string Zip = xNode.SelectSingleNode("address_component[8]/long_name").InnerText;
            string Country = xNode.SelectSingleNode("address_component[7]/long_name").InnerText;
            Console.WriteLine("Full Address: " + FullAddress);
            Console.WriteLine("Number: " + Number);
            Console.WriteLine("Street: " + Street);
            Console.WriteLine("Village: " + Village);
            Console.WriteLine("Area: " + Area);
            Console.WriteLine("County: " + County);
            Console.WriteLine("State: " + State);
            Console.WriteLine("Zip: " + Zip);
            Console.WriteLine("Country: " + Country);
            return Ok(true);
        }


        [HttpPost]
        [Route("getNearByPeople")]
        public List<User> GetNearbyPeople(double userLatitude, double userLongitude, double maxDistance)
        {
            
            List<User> nearbyPeople = new List<User>();

            foreach (var user in _unitOfWork.UserRepository.GetAll())
            {
                double distance =locationService.CalculateDistance(userLatitude, userLongitude, user.Userlatitude??0, user.UserLongitude??0);

                if (distance <= maxDistance)
                {
                    nearbyPeople.Add(user);
                }
            }

            return nearbyPeople;
        }

        

        [HttpPost]
        [Route("registrationEight")]
        public IActionResult FinalRegistrationStep(int ethnicOrginId,int heightId,int marriageStatusId, int prayStatusId,bool isHaveChildren, bool isSmoke, bool isDrinkAlochal,  int futureChildrenStatusId,
            bool isMoveAbroad, string interestId, string personailityId, string bio
            )
        {
            try
            {
                var model = _unitOfWork.UserRepository.GetById(18);
                model.EthnicGroupId = ethnicOrginId;
                model.UserHeight = heightId;
            model.PrayId = prayStatusId;
                model.PersonailityIds = personailityId;
                model.InterestIds = interestId;
                model.MarriageStatusId = marriageStatusId ;
                    model.IsHaveChildren = isHaveChildren;
                model.IsSmoke = isSmoke;
                model.IsAlcohal = isDrinkAlochal;
                model.IsWantToMoveAbroad = isMoveAbroad;
                    model.Bio = bio;
                _unitOfWork.UserRepository.Update(model);
                _dbContext.SaveChanges();
                return Ok(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                throw;
            }
        }

        [HttpPost]
        [Route("addProfilePicture")]
     public   async Task FaceDetectionApiAsync ()
        {
            try
            {
                    string imageUrl = "C:/Users/ammar/Desktop/mypic.jpg";
                    using var client = new HttpClient();
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "967be2f84a7944d0bd41a974916c3959");
                    byte[] imageData;
                    using (var imageStream = new FileStream(imageUrl, FileMode.Open, FileAccess.Read))
                   using (var memoryStream = new MemoryStream())
                    {
                        imageStream.CopyTo(memoryStream);
                        imageData = memoryStream.ToArray();
                    }

                    var content = new ByteArrayContent(imageData);
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                    string requestUrl = "https://epicface.cognitiveservices.azure.com/face/v1.0/detect?returnFaceId=true&returnFaceLandmarks=false&returnFaceAttributes=age,gender"; // Modify the query parameters as needed
                    var response = await client.PostAsync(requestUrl, content);
                    string responseContent = await response.Content.ReadAsStringAsync();
                    if (!responseContent.IsNullOrEmpty())
                    {
                        dynamic? json = JsonConvert.DeserializeObject(responseContent);
                        if(json != null)
                        {
                            var model = _unitOfWork.UserRepository.GetById(18);
                            model.ProfilePictureFaceId = json[0]["faceId"];
                        _unitOfWork.UserRepository.Update(model);
                        _dbContext.SaveChanges();

                        }
                    }
                   
                    Console.WriteLine(responseContent.ToString());
            
            }
            catch (Exception)
            {

                throw;
            }
            // Parse and work with the response data as needed
         
        }

        [HttpPost]
        [Route("verifyIdentity")]

        public async Task<bool> verifyIdentity(IFormFile? file)
        {
            if (file != null && file.Length > 0)
            {
                byte[]? bytes = null;
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "967be2f84a7944d0bd41a974916c3959");
                using (var ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    bytes = ms.ToArray();
                }
                var model = _unitOfWork.UserRepository.GetById(18);
            if(model!= null) { 
                var content = new ByteArrayContent(bytes);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                string requestUrl = "https://epicface.cognitiveservices.azure.com/face/v1.0/detect?returnFaceId=true&returnFaceLandmarks=false&returnFaceAttributes=age,gender"; // Modify the query parameters as needed
                var response = await client.PostAsync(requestUrl, content);
                string responseContent = await response.Content.ReadAsStringAsync();
                if (!responseContent.IsNullOrEmpty())
                {
                    dynamic? json = JsonConvert.DeserializeObject(responseContent);
                    if (json != null)
                    {
                        var selfieFaceId = json[0]["faceId"];
                            if(string.Equals(model.ProfilePictureFaceId, selfieFaceId))
                            {
                                model.IsSelfieVarified = true;
                                _unitOfWork.UserRepository.Update(model);                
                                _dbContext.SaveChanges();
                                return true;
                            }

                            return false;
                    }

                        return false;
                    }
                    return false;
            }
                return false;

            }
            return false;
        }

        [HttpPost]
        [Route("GetImages")]
        public async Task verifyImages()
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "967be2f84a7944d0bd41a974916c3959");

            string imageUrl1 = "C:/Users/ammar/Desktop/pic2.jpg";
            string imageUrl2 = "C:/Users/ammar/Desktop/pic2.jpg";
            byte[] imageData1;
            byte[] imageData2;

            using (var imageStream1 = new FileStream(imageUrl1, FileMode.Open, FileAccess.Read))
            using (var memoryStream1 = new MemoryStream())
            {
                imageStream1.CopyTo(memoryStream1);
                imageData1 = memoryStream1.ToArray();
            }

            using (var imageStream2 = new FileStream(imageUrl2, FileMode.Open, FileAccess.Read))
            using (var memoryStream2 = new MemoryStream())
            {
                imageStream2.CopyTo(memoryStream2);
                imageData2 = memoryStream2.ToArray();
            }

            var content = new MultipartFormDataContent();
            content.Add(new ByteArrayContent(imageData1), "image1", "image1.jpg");
            content.Add(new ByteArrayContent(imageData2), "image2", "image2.jpg");

            string endpoint = "YOUR_ENDPOINT_URL";
            string requestUrl = "https://epicface.cognitiveservices.azure.com/face/v1.0/verify";

            var response = await client.PostAsync(requestUrl, content);
            string responseContent = await response.Content.ReadAsStringAsync();

            // Parse the response and handle the result

        }

    }
}

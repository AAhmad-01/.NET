using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZavaJApplicationApi.Model
{
    public class User
    {
        [Key]
        public int? Id { get; set; }

        public string? UserName { get; set; } = string.Empty;

        public string? Password { get; set; } = string.Empty;

        // We can Set Gender bit for male /Female
        public string? Gender { get; set; }
        public double? Userlatitude { get; set; }

        public double? UserLongitude { get; set; }

        public string? ProfilePicture { get; set; }= string.Empty;

        public string? Selfie { get; set; }= string.Empty;

        public DateTime? DateOfBirth { get; set; }

        public int? SectId { get; set; }
        public int? ProfessionId { get; set; }

        public int? EthnicGroupId { get; set; }

        public int? EducationLevelId { get; set; }

        public int? PhoneNumber { get; set; }

        public bool? IsPhoneNumberVerfied { get; set; }

        public bool? IsEmailVerified { get; set; }

        public int? EthnicOrginId { get; set; }

        public int? UserHeight { get; set; }

        public bool? IsMarried { get; set; } = false;

        public int PrayId { get; set; }

        public bool? IsHaveChildren { get; set; } = false;

        public bool? IsSmoke { get; set; } = false;

        public bool? IsAlcohal { get; set; } = false;

        public int? FutureChildrenId { get; set; }


        public string? Bio { get; set; }
        public bool? IsWantToMoveAbroad { get; set; } = false;

        public string? InterestIds { get; set; }
        public string? FoodBaverageIds { get; set; }

        public string? PersonailityIds { get; set; }

        public string? ProfilePictureFaceId { get; set; }

        public bool IsSelfieVarified { get; set; } = false;
        public int? MarriageStatusId { get; set; }
        public string? ArtsCultureIds { get; set; }
        public int RegisterationStepCompleted { get; set; } = 0;
        public DateTime? CreateDateTime { get; set; } = DateTime.Now;    

        public DateTime? Modified { get; set; }

        public bool? isActive { get; set; } = false;

        public int StepsCompleted { get; set; }


    }
}

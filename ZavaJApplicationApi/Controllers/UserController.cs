using ContosoUniversity.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZavaJApplicationApi.DAL;
using ZavaJApplicationApi.LocationServices;
using ZavaJApplicationApi.Model;

namespace ZavaJApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IdentityDBContext _dbContext;
        private UnitOfWork _unitOfWork;
        User user = new User();

        LocationService locationService = new LocationService();
        public UserController(IdentityDBContext dbContext)
        {
            _dbContext = dbContext;
            _unitOfWork = new UnitOfWork(_dbContext);


        }
        private readonly List<string> _items = new List<string>
        {
            "Item 1",
            "Item 2",
            "Item 3"
        };


        [HttpGet]
        [Route("MatchLevel")]
        
        public IActionResult MatchLevel(int matchUserId,  int matchLevelId)
        {
            try
            {
                var matchUser = _unitOfWork.UserRepository.GetById(matchUserId);
                if (matchUser != null)
                {
                    var matchTableModel = new MatchTable
                    {

                        MatchUserId = matchUserId,
                        UserId = user.Id ?? 0,
                        MatchLevelId = matchLevelId

                    };
                    _unitOfWork.MatchTableRepository.Insert(matchTableModel);
                    _unitOfWork.Save();
                    return Ok();
                }
                return Unauthorized();

            }
            catch (Exception)
            {
                return Unauthorized();
                throw;
            }
            
        }



        [HttpGet]
        [Route("all")]
        public IActionResult GetItems()
        {
            _dbContext.Add(GetItems);
            return Ok(_items);
        }

        [HttpGet]
        [Route("search")]

        public string searchText()
        {
            return "hello Ammar";
        }


    }
}

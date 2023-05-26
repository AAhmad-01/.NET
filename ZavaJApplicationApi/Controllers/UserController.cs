using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ZavaJApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected DbContext _context;
        private readonly List<string> _items = new List<string>
        {
            "Item 1",
            "Item 2",
            "Item 3"
        };

        
        [HttpGet]
        [Route("all")]
        public IActionResult GetItems()
        {
            _context.Add(GetItems);
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

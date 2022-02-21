using Bungie_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bungie_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        public IActionResult Index()
        {
            return View();
        }

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        
        [HttpGet(Name = "GetUser")]
        public User Get(string userId)
        {
            return null;
        }
    }
}

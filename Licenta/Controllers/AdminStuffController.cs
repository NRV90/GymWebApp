using Licenta.Models;
using Licenta.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Licenta.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminStuffController : Controller
    {
        private readonly MongoDBService _mongoService;

        public AdminStuffController(MongoDBService connection)
        {
            _mongoService = connection;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Users()
        {
            return View();
        }
        [HttpGet]
        public async Task <List<UserModel>> GetAllUsers()
        {
            var allUsers= await _mongoService.GetAllUsersFromMongo();

            return allUsers;
        }






    }
}

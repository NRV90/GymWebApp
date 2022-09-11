using Licenta.DAL;
using Licenta.Models.Models;
using Licenta.Utils.Mappers;
using Licenta.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Licenta.Controllers
{
    [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> Users()
        {
            var listOfUsers = await GetUsers();


            return View(listOfUsers);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(UserViewModel user)
        {

            var userMongo = await _mongoService.FindUser(user.Id);

            return View(userMongo.ParseToUserVM());

        }

        [HttpPost]
        public async Task<IActionResult> Modify(UserViewModel user)
        {

            var result = await _mongoService.ModifyUser(user.ParseToUserModel());

            return View("Index");

        }



        [HttpPost]
        public async Task<IActionResult> DeleteUser([FromBody] UserIdViewModel userId)
        {

            var resultOperation = await _mongoService.DeleteUser(userId.UserId);


            var listOfUsers = await GetUsers();
            return PartialView("_UsersTable", listOfUsers);






        }

        [HttpGet]
        public IActionResult UpdateUser()
        {

            return View();
        }

        [HttpPost]
        public IActionResult UpdateUser([FromBody] UserIdViewModel userId)
        {
            Console.WriteLine(userId.UserId);
            return RedirectToAction("UpdateUser");
        }




        private async Task<List<UserViewModel>> GetUsers()
        {
            var allUsers = await _mongoService.GetAllUsersFromMongo();

            var listOfUsers = new List<UserViewModel>();
            foreach (var user in allUsers)
            {
                listOfUsers.Add((UserViewModel)user.ParseToUserVM());
            }
            return listOfUsers;

        }



    }
}

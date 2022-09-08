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
            Console.WriteLine(user.Id);
            var A = new UserModel();
            A.Id = user.Id;
            A.Email = user.Email;
            A.Password = user.Password;
            A.FirstName = user.FirstName;
            A.LastName = user.LastName;
            A.Role = user.Role;
            var result = await _mongoService.ModifyUser(A);

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
                var usermodel = new UserViewModel();
                usermodel.Id = user.Id;
                usermodel.Email = user.Email;
                usermodel.FirstName = user.FirstName;
                usermodel.LastName = user.LastName;
                usermodel.Role = user.Role;


                listOfUsers.Add(usermodel);

            }
            return listOfUsers;

        }


        private Object ParseDataEx0(Object A, Object B)
        {



            return A;
        }



    }
}

using Licenta.DAL;
using Licenta.Identity;
using Licenta.Models.Models;
using Licenta.Utils.Mappers;
using Licenta.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Licenta.Controllers
{
    public class AutentificareController : Controller
    {
        private readonly MongoDBService _mongoService;

        public AutentificareController(MongoDBService connection)
        {
            _mongoService = connection;
        }

        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Register(UserViewModel userVM)
        {

            var createUser = await _mongoService.CreateUserAsync(userVM.SentDataToCreateUser());

            if (createUser == 1)
            {

                Console.WriteLine("Controller is working1");
                return Json(new { message = "Connected succesfully" });
            }

            else
            {

                Console.WriteLine("Controller is working2");
                return Json(new { message = "Email already been taken!" });

            }



        }
        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel userVM)
        {


            var loginUser = await _mongoService.ConnectUserAsync(userVM.SentDataToConnectUser());//checking if input data is corect and exist in our database
            Console.WriteLine(loginUser);
            if (loginUser?.Id != null)
            {


                IdentityUser.CreateClaimsAsync(loginUser, HttpContext);// with this function i create the claims
                return Redirect("/Autentificare/Profile");


            }



            TempData["Error"] = "Error. Username or Password is invalid";
            return View("Index");
        }



        [Authorize]
        public IActionResult Profile()
        {

            return View();
        }


        [HttpGet]
        public IActionResult Denied()
        {

            return View();
        }


        [Authorize]

        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync();
            return Redirect("/");

        }




    }


}

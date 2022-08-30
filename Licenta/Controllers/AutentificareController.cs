using Licenta.Identity;
using Licenta.Models;
using Licenta.Services;
using Licenta.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Licenta.Controllers
{
    public class AutentificareController : Controller
    {
        private readonly MongoDBService _mongoService;

        public AutentificareController(MongoDBService connection) {
            _mongoService = connection;
        }
       
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public async  Task<JsonResult> Register( UserViewModel userVM)
        {
            var user = new UserModel();
            user.FirstName=userVM.FirstName;
            user.LastName = userVM.LastName;
            user.Email = userVM.Email;
            user.Password = userVM.Password;
                var createUser = await _mongoService.CreateUserAsync(user);

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
           
            var user = new UserModel();
            user.Email = userVM.Email;
            user.Password = userVM.Password;   
            var loginUser = await _mongoService.ConnectUserAsync(user);//cheching if input data is corect and exist in our database
            Console.WriteLine(loginUser);
            if (loginUser!=null) {
                user.Role = loginUser;//if loginUser is not null i will take the role passed 
                IdentityUser.CreateClaimsAsync(user,HttpContext);// with this function i create the claims
                return Redirect("/Autentificare/Profile");


            }



            TempData["Error"] = "Error. Username or Password is invalid";
            return View("Index");
        }



        [Authorize]
        public IActionResult Profile()
        {
            var testing = _mongoService.GetAllUsersFromMongo();
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

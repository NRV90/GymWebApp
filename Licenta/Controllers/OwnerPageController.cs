using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Licenta.Controllers
{
    [Authorize(Roles = "Admin,Owner")]
    public class OwnerPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreationPage()
        {
            return View();
        }
    }
}

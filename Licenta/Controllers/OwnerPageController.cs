using Licenta.DAL;
using Licenta.Models.Models;
using Licenta.Utils.Mappers;
using Licenta.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Licenta.Controllers
{
    [Authorize(Roles = "Admin,Owner")]
    public class OwnerPageController : Controller
    {
        private readonly MongoDBSiteService _siteService;
     public  OwnerPageController(MongoDBSiteService connection)
        {


            _siteService = connection;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreationPage()
        {

            return View();
        }

        [HttpPost]
        public async Task<int> CreatePage(PageViewModel site)
        {
            await _siteService.AddPage(site.SendDataToCreateSite());
            return 1;
        }


    }
}

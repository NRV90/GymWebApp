using Licenta.DAL;
using Licenta.Models.Models;
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
            SiteCreationModel finalSite = new SiteCreationModel(); 
            finalSite.Title = site.Title;
            finalSite.Description = site.Description;
            finalSite.Price = site.Price;
            finalSite.UserId = site.UserId;
            finalSite.Location = site.Location;
            await _siteService.AddPage(finalSite);
            return 1;
        }


    }
}

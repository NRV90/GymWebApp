using Licenta.Models.Models;
using Licenta.ViewModels;

namespace Licenta.Utils.Mappers
{
    public static class SiteMappers
    {

        public static SiteCreationModel SendDataToCreateSite(this PageViewModel A) {
            SiteCreationModel B=new SiteCreationModel();
            B.Title = A.Title;
            B.Description = A.Description;
            B.Location = A.Location;
            B.Price= A.Price;
           B.UserId= A.UserId;
            if (A.CoverPhoto != null) {
                string folder = "sites";
            
            }


            return B;
        }

    }
}

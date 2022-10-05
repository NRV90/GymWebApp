namespace Licenta.ViewModels
{
    public class PageViewModel
    {
       

        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Photos { get; set; }//??
        public string Location { get; set; }
        public string Price { get; set; }

        public IFormFile CoverPhoto { get; set; }



    }
}

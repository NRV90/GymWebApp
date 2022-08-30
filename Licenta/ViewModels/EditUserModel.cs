namespace Licenta.ViewModels
{
    public class EditUserModel
    {

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
        public string Role { get; set; }
        public List<TypeOfUser> Roles { get; set; }
    }
}

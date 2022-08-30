using Licenta.Models.Models;
using Licenta.ViewModels;

namespace Licenta.Utils.Mappers
{
    public static class UserMappers
    {
        public static Object ParseToUserVM(this UserModel B)
        {
            var A = new UserViewModel();
           A.Id = B.Id;
            A.Email = B.Email;
            A.FirstName = B.FirstName;
            A.LastName = B.LastName;
            A.Role = B.Role;


            return A;
        }
        public static Object ParseToUserModel(this UserViewModel B)
        {
            var A = new UserModel();
            A.Id = B.Id;
            A.Email = B.Email;
            A.FirstName = B.FirstName;
            A.LastName = B.LastName;
            A.Role = B.Role;


            return A;
        }

        public static Object ParseToEditUserModel(this UserModel B)
        {
            var A = new EditUserModel();
            A.Id = B.Id;
            A.Email = B.Email;
            A.FirstName = B.FirstName;
            A.LastName = B.LastName;
            A.Role = B.Role;


            return A;
        }




    }
}

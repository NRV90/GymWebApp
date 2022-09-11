using Licenta.Models.Models;
using Licenta.ViewModels;

namespace Licenta.Utils.Mappers
{
    public static class UserMappers
    {
        public static UserViewModel ParseToUserVM(this UserModel B)
        {
            var A = new UserViewModel();
           A.Id = B.Id;
            A.Email = B.Email;
            A.FirstName = B.FirstName;
            A.LastName = B.LastName;
            A.Role = B.Role;


            return A;
        }
        public static UserModel ParseToUserModel(this UserViewModel B)
        {
            var A = new UserModel();
            A.Id = B.Id;
            A.Email = B.Email;
            A.FirstName = B.FirstName;
            A.LastName = B.LastName;
            A.Role = B.Role;


            return A;
        }

        public static EditUserModel ParseToEditUserModel(this UserModel B)
        {
            var A = new EditUserModel();
            A.Id = B.Id;
            A.Email = B.Email;
            A.FirstName = B.FirstName;
            A.LastName = B.LastName;
            A.Role = B.Role;


            return A;
        }
        public static UserModel SentDataToCreateUser(this UserViewModel B) {

            var A = new UserModel();
            A.Email = B.Email;
            A.Password= B.Password;
            A.FirstName = B.FirstName;
            A.LastName = B.LastName;


            return A;


        }
        public static UserModel SentDataToConnectUser(this UserViewModel B)
        {

            var A = new UserModel();
            A.Email = B.Email;
            A.Password = B.Password;


            return A;


        }
       



    }
}

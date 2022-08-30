using System.ComponentModel.DataAnnotations;

namespace Licenta.Models
{
    public class LoginUserModel
    {

        public string Password { get; set; }
        [Required(ErrorMessage = "Va rog sa introduceti numele")]
        public string Email { get; set; }


    }
}

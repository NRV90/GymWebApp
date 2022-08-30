using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Licenta.ViewModels
{
    public class UserViewModel
    {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
       
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
     
        public string Password { get; set; }

        public string Email { get; set; }


    }
}

﻿

using MongoDB.Bson.Serialization.Attributes;

namespace Licenta.Models.Models
{
    public class UserModel
    {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
       
        public string FirstName { get; set; }
      
        public string LastName { get; set; }
     
        public string Password { get; set; }
     
        public string Email { get; set; }

        public string Role { get; set; } = "User";





    }
}

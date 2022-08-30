using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Models.Models
{
    public class SiteCreationModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public  List<string> Photos { get; set; }//??
        public string Location { get; set; }
        public string Price { get; set; }

    }
}

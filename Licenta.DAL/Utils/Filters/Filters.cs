using Licenta.Models.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.DAL.Utils.Filters
{
    public static class Filters
    {
        public static FilterDefinition<UserModel> SearchById(this string id)
        {


            var filter = Builders<UserModel>.Filter.Eq("_id", ObjectId.Parse(id));

            return filter;
        }
        public static FilterDefinition<UserModel> SearchByEmail(this string email)
        {


            var filter = Builders<UserModel>.Filter.Eq("Email", email);

            return filter;
        }


    }
}

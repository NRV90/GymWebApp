using Licenta.Models.Models;
using MongoDB.Driver;

namespace Licenta.DAL
{
    public class MongoDBSiteService
    {
        private readonly IMongoCollection<SiteCreationModel> _sitesCollection;
        private readonly MongoDBService _userCollection;

        public MongoDBSiteService(MongoDBService connection)
        {
            MongoClient client = new MongoClient("mongodb+srv://manualex2000:1234@cluster0.y9z7f.mongodb.net/FmDataBase?retryWrites=true&w=majority");
            IMongoDatabase database = client.GetDatabase("simple_db");
            _sitesCollection = database.GetCollection<SiteCreationModel>("sites");
            _userCollection = connection;

        }
        public async Task<int> AddPage(SiteCreationModel site)
        {


            await _sitesCollection.InsertOneAsync(site);

            return 1;

        }






    }
}

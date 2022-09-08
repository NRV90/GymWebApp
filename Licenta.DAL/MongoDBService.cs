using Licenta.DAL.MongoSettings;
using Licenta.Models.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Security.Cryptography;
using System.Text;

namespace Licenta.DAL
{
    public class MongoDBService
    {
        private readonly IMongoCollection<UserModel> _userCollection;


        public MongoDBService(IOptions<MongoDBSettings> mongoDBsettings)
        {

            //MongoClient client = new MongoClient(mongoDBsettings.Value.ConnectionString);

            //IMongoDatabase database = client.GetDatabase(mongoDBsettings.Value.DatabaseName);

            //_userCollection = database.GetCollection<UserModel>(mongoDBsettings.Value.CollectionName);
            MongoClient client = new MongoClient("mongodb+srv://manualex2000:1234@cluster0.y9z7f.mongodb.net/FmDataBase?retryWrites=true&w=majority");
            IMongoDatabase database = client.GetDatabase("simple_db");
            _userCollection = database.GetCollection<UserModel>("people");
        }

        public async Task<int> CreateUserAsync(UserModel user)
        {



            var searchUser = await _userCollection.FindAsync(x => x.Email.Equals(user.Email));
            var validateUser = searchUser.FirstOrDefaultAsync()?.Result;

            if (validateUser?.Email == null)
            {


                user.Password = hashPassword(user.Password);



                await _userCollection.InsertOneAsync(user);

                Console.WriteLine("Service is working1");
                return 1;//If the email is unique the return 1

            }
            else
            {
                Console.WriteLine("Service is working2");

                return 0;//If the email isn't unique the return 0


            }
        }
        public async Task<UserModel> ConnectUserAsync(UserModel user)
        {
            var theUser = await _userCollection.FindAsync(x => x.Email.Equals(user.Email));//searching for an email match
            var resultUser = theUser.FirstOrDefaultAsync()?.Result;//i get the result of the searched done in the upper line

            //checking if email exist
            if (resultUser?.Email != null)
            {
                var hashedLogPass = hashPassword(user.Password);
                if (hashedLogPass == resultUser.Password)
                    return resultUser;//return 1 if the password and email are correct
                else
                    return null;// return 0 if password is wrong

            }
            else
            {

                return null;// return 0 if email null 

            }





        }
        public async Task<string> DeleteUser(string userId)
        {
            var deleteFilter = Builders<UserModel>.Filter.Eq("_id", ObjectId.Parse(userId));
            var resultOperation = await _userCollection.DeleteOneAsync(deleteFilter);
            Console.WriteLine(resultOperation);
            if (resultOperation != null)
                return "Ok";
            return "";

        }



        public async Task<List<UserModel>> GetAllUsersFromMongo()
        {
            //List<UserModel> usersList = new List<UserModel>();
            var users = await _userCollection.FindAsync(_ => true);
            var resultUsers = users.ToList();//list of users
            foreach (var elem in resultUsers)
            { Console.WriteLine(elem); }





            return resultUsers;
        }
        public async Task<UserModel> FindUser(string userId)
        {
            var filter = Builders<UserModel>.Filter.Eq("_id", ObjectId.Parse(userId));
            Console.WriteLine("Id string: " + userId);
            var user = await _userCollection.FindAsync(filter);
            var finalUser = user.FirstOrDefaultAsync()?.Result;

            return finalUser;

        }


        public async Task<int> ModifyUser(UserModel userModel)
        {
            var filter = Builders<UserModel>.Filter.Eq("_id", ObjectId.Parse(userModel.Id));
            var UpdateDefinition = Builders<UserModel>.Update.Set(user => user.FirstName, userModel.FirstName)
                                                             .Set(user => user.LastName, userModel.LastName)
                                                             .Set(user => user.Email, userModel.Email)
                                                             .Set(user => user.Role, userModel.Role);

            Console.WriteLine("Id Object: " + userModel.Id);

            var user = await _userCollection.FindOneAndUpdateAsync(filter, UpdateDefinition);

            if (user != null)
                return 1;
            return 0;

        }





        private string hashPassword(string password)
        {
            var sha = SHA256.Create();
            var asBytePass = Encoding.Default.GetBytes(password);
            var hashedPass = sha.ComputeHash(asBytePass);

            return Convert.ToBase64String(hashedPass);
        }

    }






}
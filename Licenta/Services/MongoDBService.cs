using Licenta.Models;
using Licenta.MongoSettings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Security.Cryptography;
using System.Text;

namespace Licenta.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<UserModel> _userCollection;


        public MongoDBService(IOptions<MongoDBSettings> mongoDBsettings)
        {

            MongoClient client = new MongoClient(mongoDBsettings.Value.ConnectionString);

            IMongoDatabase database = client.GetDatabase(mongoDBsettings.Value.DatabaseName);

            _userCollection = database.GetCollection<UserModel>(mongoDBsettings.Value.CollectionName);


        }

        public async Task<int> CreateUserAsync(UserModel user)
        {

            Console.WriteLine("ceva");

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
        public async Task<string> ConnectUserAsync(UserModel user)
        {
            var theUser = await _userCollection.FindAsync(x => x.Email.Equals(user.Email));//searching for an email match
            var resultUser = theUser.FirstOrDefaultAsync()?.Result;//i get the result of the searched done in the upper line

            //checking if email exist
            if (resultUser?.Email != null)
            {
                var hashedLogPass = hashPassword(user.Password);
                if (hashedLogPass == resultUser.Password)
                    return resultUser?.Role;//return 1 if the password and email are correct
                else
                    return "";// return 0 if password is wrong

            }
            else
            {

                return "";// return 0 if email null 

            }
            Console.WriteLine(theUser);




        }
        public async Task<List<UserModel>> GetAllUsersFromMongo()
        {
            //List<UserModel> usersList = new List<UserModel>();
            var users = await _userCollection.FindAsync(_=>true);
            var resultUsers=users.ToList();//list of users
            foreach (var elem in resultUsers) 
            { Console.WriteLine(elem); }
         




            return resultUsers;
        }






        private string hashPassword(string password) {
            var sha = SHA256.Create();
            var asBytePass = Encoding.Default.GetBytes(password);
            var hashedPass = sha.ComputeHash(asBytePass);

            return Convert.ToBase64String(hashedPass);
        }

    }
   





}


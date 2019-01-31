using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using FoodWebApp.Models;

namespace FoodWebApp.DB_Service
{
    public class UserService
    {
        private readonly IMongoCollection<UserModel> _users;

        // Conntect to MongoDB database
        // Draft version of constructor for testing purpose
        public UserService() {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("MFDN_APP_DB");
            _users = database.GetCollection<UserModel>("Users");
        }

        public List<UserModel> Get()
        {
            return _users.Find(UserModel => true).ToList();
        }

        public UserModel Get(string id)
        {
            return _users.Find<UserModel>(user => user.UserId == id).FirstOrDefault();
        }

        // Why return the user object? this is not like sql which returns the number of rows affected...
        public UserModel Create(UserModel user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, UserModel userIn)
        {
            _users.ReplaceOne(user => user.UserId == id, userIn);
        }

        public void Remove(UserModel userIn)
        {
            _users.DeleteOne(user => user.UserId == userIn.UserId);
        }

        public void Remove(string id)
        {
            _users.DeleteOne(user => user.UserId == id);
        }

    }
}
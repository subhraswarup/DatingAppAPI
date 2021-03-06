using System.Collections.Generic;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Newtonsoft.Json;

namespace DatingAppAPI.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext contex)
        {
            _context=contex;
        }
        public void SeedUsers()
        {
            var userData =  System.IO.File.ReadAllText("Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);
            foreach(var user in users){
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);
                user.PasswordHash=passwordHash;
                user.PasswordSalt=passwordSalt;
                user.UserName = user.UserName.ToLower();

                _context.Usres.Add(user);
            }
            _context.SaveChanges();
        }
         private void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt){
            using( var hmac=new System.Security.Cryptography.HMACSHA512()) {
               passwordSalt=hmac.Key;
               passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
               
        }
    }
}
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SMS.Data;
using SMS.Data.Entities;

namespace SMS.Services
{
    public class AuthManager
    {
        private readonly SMSDbContext _db;

        public AuthManager(SMSDbContext db)
        {
            _db = db;
        }

        public User Login(string email, string password)
        {
            string hashedPassword = Utilities.PasswordHasher.Sha256(password);

            return _db.Users.FirstOrDefault(u =>
                u.Email == email && u.Password == hashedPassword);
        }
    }
}

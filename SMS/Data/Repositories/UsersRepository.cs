using System.Collections.Generic;
using System.Linq;
using SMS.Data.Entities;

namespace SMS.Data.Repositories
{
    public class UsersRepository
    {
        private readonly SMSDbContext _db;

        public UsersRepository(SMSDbContext db)
        {
            _db = db;
        }

        public List<User> GetAll() => _db.Users.ToList();

        public User GetById(int id) => _db.Users.Find(id);

        public User GetByEmail(string email) => _db.Users.FirstOrDefault(u => u.Email == email);

        public void Add(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void Update(User user)
        {
            _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(User user)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
        }
    }
}

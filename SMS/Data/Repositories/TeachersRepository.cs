using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SMS.Data.Entities;

namespace SMS.Data.Repositories
{
    public class TeachersRepository
    {
        private readonly SMSDbContext _db;

        public TeachersRepository(SMSDbContext db)
        {
            _db = db;
        }

        public List<Teacher> GetAllWithUser() => _db.Teachers.Include(t => t.User).ToList();

        public Teacher GetById(int id) => _db.Teachers.Find(id);

        public void Add(Teacher teacher)
        {
            _db.Teachers.Add(teacher);
            _db.SaveChanges();
        }

        public void Update(Teacher teacher)
        {
            _db.Entry(teacher).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(Teacher teacher)
        {
            _db.Teachers.Remove(teacher);
            _db.SaveChanges();
        }
    }
}

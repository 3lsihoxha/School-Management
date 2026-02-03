using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SMS.Data.Entities;

namespace SMS.Data.Repositories
{
    public class StudentsRepository
    {
        private readonly SMSDbContext _db;

        public StudentsRepository(SMSDbContext db)
        {
            _db = db;
        }

        public List<Student> GetAllWithUser() => _db.Students.Include(s => s.User).ToList();

        public Student GetById(int id) => _db.Students.Find(id);

        public void Add(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
        }

        public void Update(Student student)
        {
            _db.Entry(student).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(Student student)
        {
            _db.Students.Remove(student);
            _db.SaveChanges();
        }
    }
}

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SMS.Data.Entities;

namespace SMS.Data.Repositories
{
    public class CoursesRepository
    {
        private readonly SMSDbContext _db;

        public CoursesRepository(SMSDbContext db)
        {
            _db = db;
        }

        public List<Course> GetAllWithTeacher() => _db.Courses.Include(c => c.Teacher).ToList();

        public Course GetById(int id) => _db.Courses.Find(id);

        public void Add(Course course)
        {
            _db.Courses.Add(course);
            _db.SaveChanges();
        }

        public void Update(Course course)
        {
            _db.Entry(course).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(Course course)
        {
            _db.Courses.Remove(course);
            _db.SaveChanges();
        }
    }
}

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SMS.Data.Entities;

namespace SMS.Data.Repositories
{
    public class EnrollmentsRepository
    {
        private readonly SMSDbContext _db;

        public EnrollmentsRepository(SMSDbContext db)
        {
            _db = db;
        }

        public List<Enrollment> GetAll() => _db.Enrollments.ToList();

        public List<Enrollment> GetByStudentId(int studentId) =>
            _db.Enrollments.Where(e => e.StudentId == studentId).ToList();

        public void Add(Enrollment enrollment)
        {
            _db.Enrollments.Add(enrollment);
            _db.SaveChanges();
        }

        public void Delete(Enrollment enrollment)
        {
            _db.Enrollments.Remove(enrollment);
            _db.SaveChanges();
        }
    }
}

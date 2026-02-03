using SMS.Services;
using SMS.Data;
using SMS.Data.Repositories;

namespace SMS
{
    // Mirrors the professor's HMS structure: managers are grouped under Services and exposed via ServiceManager.
    public class ServiceManager
    {
        private readonly SMSDbContext _db;

        public ServiceManager()
        {
            _db = new SMSDbContext();

            UsersManager = new Services.UsersManager(new UsersRepository(_db));
            StudentsManager = new Services.StudentsManager(new StudentsRepository(_db));
            TeachersManager = new Services.TeachersManager(new TeachersRepository(_db));
            CoursesManager = new Services.CoursesManager(new CoursesRepository(_db));

            AuthManager = new Services.AuthManager(_db);
        }

        public Services.AuthManager AuthManager { get; }
        public Services.UsersManager UsersManager { get; }
        public Services.StudentsManager StudentsManager { get; }
        public Services.TeachersManager TeachersManager { get; }
        public Services.CoursesManager CoursesManager { get; }
    }
}

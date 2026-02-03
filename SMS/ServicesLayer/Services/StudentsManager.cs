using System.Collections.Generic;
using SMS.Data.Entities;
using SMS.Data.Repositories;

namespace SMS.Services
{
    public class StudentsManager
    {
        private readonly StudentsRepository _studentsRepository;

        public StudentsManager(StudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        public List<Student> GetAllWithUser() => _studentsRepository.GetAllWithUser();
    }
}

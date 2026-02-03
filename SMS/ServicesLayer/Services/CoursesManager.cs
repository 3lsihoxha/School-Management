using System.Collections.Generic;
using SMS.Data.Entities;
using SMS.Data.Repositories;

namespace SMS.Services
{
    public class CoursesManager
    {
        private readonly CoursesRepository _coursesRepository;

        public CoursesManager(CoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        public List<Course> GetAllWithTeacher() => _coursesRepository.GetAllWithTeacher();
    }
}

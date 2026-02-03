using System.Collections.Generic;
using SMS.Data.Entities;
using SMS.Data.Repositories;

namespace SMS.Services
{
    public class TeachersManager
    {
        private readonly TeachersRepository _teachersRepository;

        public TeachersManager(TeachersRepository teachersRepository)
        {
            _teachersRepository = teachersRepository;
        }

        public List<Teacher> GetAllWithUser() => _teachersRepository.GetAllWithUser();
    }
}

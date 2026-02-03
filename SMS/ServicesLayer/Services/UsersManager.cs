using System.Collections.Generic;
using SMS.Data.Entities;
using SMS.Data.Repositories;

namespace SMS.Services
{
    public class UsersManager
    {
        private readonly UsersRepository _usersRepository;

        public UsersManager(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public List<User> GetAll() => _usersRepository.GetAll();

        public User GetById(int id) => _usersRepository.GetById(id);

        public void Update(User user) => _usersRepository.Update(user);
    }
}

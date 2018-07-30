using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LynxProject.Core;
using LynxProject.Repository;
using LynxProject.Repository.Entity;
using LynxProject.Repository.Repo;

namespace LynxProject.BLL
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Delete(int id)
        {
            var userEntity = _userRepository.Delete(id);

            return true;
        }

        public List<User> GetAll()
        {
            var users = _userRepository.GetAll();
            List<User> listOfUsers = new List<User>();

            foreach (var user in users)
            {
                listOfUsers.Add(user);
            }

            return listOfUsers;
        }

        public List<User> GetAll(string searchText)
        {
            var users = _userRepository.GetAll();  
            List<User> listOfUsers = new List<User>();

            foreach(var user in users)
            {
                if (user.Username.ToLower().Contains(searchText.ToLower()) || user.FirstName.ToLower().Contains(searchText.ToLower()) || user.LastName.ToLower().Contains(searchText.ToLower()))

                listOfUsers.Add(user);
            }

            return listOfUsers;
        }

        public User GetUserById(int id)
        {
            var userEntity = _userRepository.GetById(id);

            return ConvertToUser(userEntity);
        }

        public int Insert(int userId)
        {
            throw new NotImplementedException();
        }

        public void Save(User user)
        {
            var userEntity = ConvertToUserEntity(user);

            if(user.Id == 0)
            {
                _userRepository.Insert(userEntity);
            }
            else
            {
                _userRepository.Update(userEntity);
            }
        }

        private UserEntity ConvertToUserEntity(User userDataEntity)
        {
            var user = new UserEntity
            {
                Id = userDataEntity.Id,
                Username = userDataEntity.Username,
                FirstName = userDataEntity.FirstName,
                LastName = userDataEntity.LastName,
                Email = userDataEntity.Email,
                Password = userDataEntity.Password,
                PhoneNumber = userDataEntity.PhoneNumber
            };

            return user;
        }

        private User ConvertToUser(UserEntity userEntity)
        {
            var user = new User
            {
                Id = userEntity.Id,
                Username = userEntity.Username,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                Email = userEntity.Email,
                Password = userEntity.Password,
                PhoneNumber = userEntity.PhoneNumber
            };

            return user;
        }
    }
}

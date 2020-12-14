using ManageCondo.DomainModels;
using ManageCondo.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagaCondo.Business
{
    public class UserBusiness
    {
        private readonly IUserRepository _userRepository;
        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            IEnumerable<User> units = _userRepository.GetAllUsers();
            return units;
        }

        public IEnumerable<User> GetUsersByEmail(string email)
        {
            IEnumerable<User> units = _userRepository.GetUsersByEmail(email);
            return units;
        }

        public IEnumerable<User> GetAllResidents()
        {
            IEnumerable<User> units = _userRepository.GetAllResidents();
            return units;
        }

        public Result<bool> AddUser(User unit)
        {
            return _userRepository.AddUser(unit);
        }

        public Result<bool> UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }

        public User GetUserDetails(int userID)
        {
            return _userRepository.GetUserDetails(userID);
        }

        public void DeleteUser(int userID)
        {
            _userRepository.DeleteUser(userID);
        }

        public bool ValidateUser(string email, string password)
        {
            return _userRepository.ValidateUser(email, password);
        }

        public string[] GetUserRole(string email)
        {
            return _userRepository.GetUserRole(email);
        }
    }
}

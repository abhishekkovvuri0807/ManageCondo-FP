﻿using ManageCondo.DomainModels;
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
            IEnumerable<User> units = _userRepository.GetAllUsers();
            return units;
        }

        public bool AddUser(User unit)
        {
            return _userRepository.AddUser(unit);
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
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
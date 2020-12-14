using DAL.Utility;
using ManageCondo.DomainModels;
using ManageCondo.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly ManageCondoContext _dbContext;

        public UserRepository(ManageCondoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users.Where(u => u.IsActive == true).ToList();
        }

        public IEnumerable<User> GetUsersByEmail(string email)
        {
            return _dbContext.Users.Where(u => u.IsActive == true && u.Email == email).ToList();
        }

        public IEnumerable<User> GetAllResidents()
        {
            return _dbContext.Users.Where(u => u.IsActive == true && u.Role == "Resident").ToList();
        }

        public Result<bool> AddUser(User user)
        {
            user.IsActive = true;
            User userData = _dbContext.Users.Where(p => p.Email == user.Email && p.IsActive == true).FirstOrDefault();
            if(userData == null)
            {
                _dbContext.Users.Add(user);
                if(_dbContext.SaveChanges() > 0)
                {
                    string subject = "Manage Condo Credentials";
                    string message = "Manage Condo Credentials - Email: " + user.Email + " Password: " + user.Password;
                    Email.SendMail(user.Email, subject, message);
                    return Result<bool>.Success(true, Constants.USER_ADD_SUCCESS);
                }
            } else
            {
                return Result<bool>.Fail(Constants.USER_EXISTS);
            }
            return Result<bool>.Fail(Constants.ERROR);
        }

        public Result<bool> UpdateUser(User user)
        {
            User userData = _dbContext.Users.Where(p => p.ID == user.ID).FirstOrDefault();

            if (userData != null)
            {
                userData.FirstName = user.FirstName;
                userData.LastName = user.LastName;
                userData.Email = user.Email;
                userData.Password = user.Password;
                userData.Role = user.Role;
                userData.Status = user.Status;

                if (_dbContext.SaveChanges() > 0)
                {
                    string subject = "Update Manage Condo Credentials";
                    string message = "Manage Condo Credentials - Email: " + user.Email + " Password: " + user.Password;
                    Email.SendMail(userData.Email, subject, message);
                    return Result<bool>.Success(true, Constants.USER_UPDATE_SUCCESS);
                }
            }
            else
            {
                return Result<bool>.Fail(Constants.USER_NOT_EXISTS);
            }
            return Result<bool>.Fail(Constants.ERROR);
        }

        public User GetUserDetails(int userID)
        {
            return _dbContext.Users.Where(p => p.ID == userID).FirstOrDefault();
        }

        public void DeleteUser(int userID)
        {
            User user = _dbContext.Users.Where(p => p.ID == userID).FirstOrDefault();
            user.IsActive = false;
            _dbContext.SaveChanges();
        }

      
        public bool ValidateUser(string email, string password)
        {
            User user = _dbContext.Users.Where(u => u.IsActive == true && u.Email == email && u.Password == password).FirstOrDefault();
            if(user != null)
            {
                return true;
            }
            return false;
        }

        public string[] GetUserRole(string email)
        {
            List<string> roles = _dbContext.Users.Where(u => u.IsActive == true && u.Email == email).Select(u => u.Role).Distinct().ToList();
            return roles.ToArray();
        }
     
    }
}

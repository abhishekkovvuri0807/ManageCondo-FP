using ManageCondo.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCondo.Repository.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        bool AddUser(User user);

        void UpdateUser(User user);

        User GetUserDetails(int userID);

        void DeleteUser(int userID);

        bool ValidateUser(string email, string password);

        string[] GetUserRole(string email);

        IEnumerable<User> GetUsersByEmail(string email);
    }
}

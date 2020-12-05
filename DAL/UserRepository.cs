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

        public bool AddUser(User user)
        {
            user.IsActive = true;
            User userData = _dbContext.Users.Where(p => p.Email == user.Email && p.IsActive == true).FirstOrDefault();
            if(userData == null)
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                SendMail(user.Email, user.Password);
                return true;
            }
            return false;
           
        }

        public void UpdateUser(User user)
        {
            User userData = _dbContext.Users.Where(p => p.ID == user.ID).FirstOrDefault();
            userData.FirstName = user.FirstName;
            userData.LastName = user.LastName;
            userData.Email = user.Email;
            userData.Password = user.Password;
            userData.Role = user.Role;
            userData.Status = user.Status;
            _dbContext.SaveChanges();
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

        public void SendMail(string email, string password)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("managecondo.app@gmail.com", "ManageCondoApp3");
                smtp.Timeout = 30000;

                MailMessage message = new MailMessage();
                message.To.Add(email);
                message.From = new MailAddress("managecondo.app@gmail.com");
                message.Subject = "Manage Condo Credentials";
                message.Body = "Manage Condo Credentials - Email: " + email + " Password: " + password;
                smtp.Send(message);
                
            } catch(Exception ex)
                {
                throw ex;
            }
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
            List<string> roles = _dbContext.Users.Where(u => u.IsActive == true && u.Email == email).Select(u => u.Role).ToList();
            return roles.ToArray();
        }

     
    }
}

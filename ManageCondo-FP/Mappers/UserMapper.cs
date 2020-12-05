using ManageCondo.DomainModels;
using ManageCondo_FP.Common;
using ManageCondo_FP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageCondo_FP.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel ToUserViewModel(this User user)
        {
            UserViewModel viewModel = new UserViewModel();
            viewModel.UserID = user.ID;
            viewModel.FirstName = user.FirstName;
            viewModel.LastName = user.LastName;
            viewModel.Email = user.Email;
            viewModel.Password = user.Password;
            viewModel.ConfirmPassword = user.Password;
            viewModel.Role = (UserRole)Enum.Parse(typeof(UserRole), user.Role, true);
            viewModel.Status = (UserStatus)Enum.Parse(typeof(UserStatus), user.Status, true);
            return viewModel;
        }

        public static List<UserViewModel> ToUserViewModelList(this IEnumerable<User> users)
        {
            List<UserViewModel> usersDTO = new List<UserViewModel>();
            foreach (User user in users)
            {
                usersDTO.Add(user.ToUserViewModel());
            }
            return usersDTO;
        }

        public static User ToUser(this UserViewModel userViewModel)
        {
            User user = new User();
            user.ID = userViewModel.UserID;
            user.FirstName = userViewModel.FirstName;
            user.LastName = userViewModel.LastName;
            user.Email = userViewModel.Email;
            user.Password = userViewModel.Password;
            user.Status = userViewModel.Status.ToString();
            user.Role = userViewModel.Role.ToString();
            return user;
        }
    }
}
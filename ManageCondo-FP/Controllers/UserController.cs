using ManagaCondo.Business;
using ManageCondo.DomainModels;
using ManageCondo_FP.Common;
using ManageCondo_FP.Mappers;
using ManageCondo_FP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ManageCondo_FP.Controllers
{
    [Authorize(Roles = "Admin,Resident")]
    public class UserController : Controller
    {
        private readonly UserBusiness _userBusiness;

        public UserController(UserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        // GET: User
        public ActionResult Index()
        {
            string email = User.Identity.Name;

            string[] roles = _userBusiness.GetUserRole(email);

            if (roles.Contains(UserRole.Resident.ToString()))
            {
                IEnumerable<User> unitList = _userBusiness.GetUsersByEmail(User.Identity.Name);
                IEnumerable<UserViewModel> unitViewModelList = UserMapper.ToUserViewModelList(unitList);
                return View(unitViewModelList);
            }
            else
            {
                IEnumerable<User> unitList = _userBusiness.GetAllUsers();
                IEnumerable<UserViewModel> unitViewModelList = UserMapper.ToUserViewModelList(unitList);
                return View(unitViewModelList);
            }

        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            User user = _userBusiness.GetUserDetails(id);
            UserViewModel unitViewModel = UserMapper.ToUserViewModel(user);
            return View(unitViewModel);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserViewModel unitViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = UserMapper.ToUser(unitViewModel);
                    _userBusiness.AddUser(user);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            User user = _userBusiness.GetUserDetails(id);
            UserViewModel unitViewModel = UserMapper.ToUserViewModel(user);
            return View(unitViewModel);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserViewModel userViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User unit = UserMapper.ToUser(userViewModel);
                    _userBusiness.UpdateUser(unit);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            User unit = _userBusiness.GetUserDetails(id);
            UserViewModel unitViewModel = UserMapper.ToUserViewModel(unit);
            return View(unitViewModel);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _userBusiness.DeleteUser(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

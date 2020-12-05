using DAL;
using ManagaCondo.Business;
using ManageCondo.DomainModels;
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
    public class HomeController : Controller
    {
        UserBusiness _userBusiness;
        public HomeController(UserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        public ActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Property");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                bool IsValidUser = _userBusiness.ValidateUser(user.Email, user.Password);
                if (IsValidUser)
                {
                    string[] roles = _userBusiness.GetUserRole(user.Email);
                   
                    FormsAuthentication.SetAuthCookie(user.Email, false);

                    return RedirectToAction("Index", "Property");
                }
            }
            ModelState.AddModelError("", "invalid Email or Password");
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
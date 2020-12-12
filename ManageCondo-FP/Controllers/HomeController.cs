using ManagaCondo.Business;
using ManageCondo_FP.Common;
using ManageCondo_FP.Models;
using Newtonsoft.Json;
using System;
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
        public ActionResult Login(LoginViewModel user, string ReturnUrl = "")
        {
            if (ModelState.IsValid)
            {
                bool IsValidUser = _userBusiness.ValidateUser(user.Email, user.Password);
                if (IsValidUser)
                {
                    string[] roles = _userBusiness.GetUserRole(user.Email);

                    UserViewModel userModel = new UserViewModel();
                    userModel.Email = user.Email;
                    userModel.Role = (UserRole)Enum.Parse(typeof(UserRole), roles[0], true); ;

                    string userData = JsonConvert.SerializeObject(userModel);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
                    (
                        1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData
                    );
                    string enTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie("UserCookie", enTicket);
                    Response.Cookies.Add(faCookie);
                }
                if (Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Property");
                }
            }
            ModelState.AddModelError("", "invalid Email or Password");
            return View();
        }

        public ActionResult Logout()
        {

            HttpCookie cookie = new HttpCookie("UserCookie", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }
    }
}
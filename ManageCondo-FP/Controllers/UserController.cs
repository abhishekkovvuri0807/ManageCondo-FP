using ManagaCondo.Business;
using ManageCondo.DomainModels;
using ManageCondo_FP.Authentication;
using ManageCondo_FP.Common;
using ManageCondo_FP.Mappers;
using ManageCondo_FP.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ManageCondo_FP.Controllers
{
    //[CustomAuthorize(Roles = "Admin, Resident")]
    public class UserController : Controller
    {
        private readonly UserBusiness _userBusiness;

        public UserController(UserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        // GET: User
        [CustomAuthorize(Roles = "Admin, Resident")]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.UserIDSortParm = String.IsNullOrEmpty(sortOrder) ? "userid_desc" : "";
            ViewBag.FirstNameSortParm = sortOrder == "firstname_asc" ? "firstname_desc" : "firstname_asc";
            ViewBag.LastNameSortParm = sortOrder == "lastname_asc" ? "lastname_desc" : "lastname_asc";
            ViewBag.EmailSortParm = sortOrder == "email_asc" ? "email_desc" : "email_asc";
            ViewBag.StatusSortParm = sortOrder == "status_asc" ? "status_desc" : "status_asc";
            ViewBag.RolwSortParm = sortOrder == "role_asc" ? "role_desc" : "role_asc";


            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            IEnumerable<User> unitList;
            if (User.IsInRole(UserRole.Admin.ToString()))
            {
                unitList = _userBusiness.GetAllUsers();
            } else
            {
                unitList = _userBusiness.GetUsersByEmail(User.Identity.Name);
            }

            IEnumerable<UserViewModel> userViewModelList = UserMapper.ToUserViewModelList(unitList);

            if (!String.IsNullOrEmpty(searchString))
            {
                userViewModelList = userViewModelList.Where(s => s.FirstName.Contains(searchString)
                                       || s.LastName.Contains(searchString) || s.Email.Contains(searchString)
                                       || s.Role.ToString().Contains(searchString) || s.Status.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "userid_desc":
                    userViewModelList = userViewModelList.OrderByDescending(s => s.UserID);
                    break;
                case "firstname_desc":
                    userViewModelList = userViewModelList.OrderByDescending(s => s.FirstName);
                    break;
                case "firstname_asc":
                    userViewModelList = userViewModelList.OrderBy(s => s.FirstName);
                    break;
                case "lastname_desc":
                    userViewModelList = userViewModelList.OrderByDescending(s => s.LastName);
                    break;
                case "lastname_asc":
                    userViewModelList = userViewModelList.OrderBy(s => s.LastName);
                    break;
                case "email_desc":
                    userViewModelList = userViewModelList.OrderByDescending(s => s.Email);
                    break;
                case "email_asc":
                    userViewModelList = userViewModelList.OrderBy(s => s.Email);
                    break;
                case "role_desc":
                    userViewModelList = userViewModelList.OrderByDescending(s => s.Role.ToString());
                    break;
                case "role_asc":
                    userViewModelList = userViewModelList.OrderBy(s => s.Role.ToString());
                    break;
                case "status_desc":
                    userViewModelList = userViewModelList.OrderByDescending(s => s.Status);
                    break;
                case "status_asc":
                    userViewModelList = userViewModelList.OrderBy(s => s.Status);
                    break;
                default:
                    userViewModelList = userViewModelList.OrderBy(s => s.UserID);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(userViewModelList.ToPagedList(pageNumber, pageSize));

        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            User user = _userBusiness.GetUserDetails(id);
            UserViewModel unitViewModel = UserMapper.ToUserViewModel(user);
            return View(unitViewModel);
        }

        // GET: User/Create
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create(UserViewModel unitViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = UserMapper.ToUser(unitViewModel);
                    Result<bool> result = _userBusiness.AddUser(user);
                    if(result.isSuccess)
                    {
                        return RedirectToAction(nameof(Index));
                    } else
                    {
                        ModelState.AddModelError(string.Empty, result.errorMessage);
                        return View();
                    }
                }
                else
                {
                    return View(unitViewModel);
                }
            }
            catch(Exception ex)
            {
                return RedirectToAction("AppError", "Error");
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
                    User user = UserMapper.ToUser(userViewModel);
                    Result<bool> result = _userBusiness.UpdateUser(user);
                    if (result.isSuccess)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result.errorMessage);
                        return View();
                    }
                }
                else
                {
                    return View(userViewModel);
                }
            }
            catch
            {
                return RedirectToAction("AppError", "Error");
            }
        }

        // GET: User/Delete/5

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            User unit = _userBusiness.GetUserDetails(id);
            UserViewModel unitViewModel = UserMapper.ToUserViewModel(unit);
            return View(unitViewModel);
        }

        // POST: User/Delete/5
        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]
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

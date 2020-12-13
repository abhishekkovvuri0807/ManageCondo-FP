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
using System.Web;
using System.Web.Mvc;

namespace ManageCondo_FP.Controllers
{
    public class ResidentController : Controller
    {
        private readonly ResidentBusiness _residentBusiness;
        private readonly UserBusiness _userBusiness;
        private readonly UnitBusiness _unitBusiness;


        public ResidentController(ResidentBusiness residentBusiness, UserBusiness userBusiness, UnitBusiness unitBusiness)
        {
            _residentBusiness = residentBusiness;
            _userBusiness = userBusiness;
            _unitBusiness = unitBusiness;
        }
        // GET: Resident
        [CustomAuthorize(Roles = "Admin, Resident")]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ResidentIDSortParm = String.IsNullOrEmpty(sortOrder) ? "residentid_desc" : "";
            ViewBag.FirstNameSortParm = sortOrder == "firstname_asc" ? "firstname_desc" : "firstname_asc";
            ViewBag.SecondNameSortParm = sortOrder == "secondname_asc" ? "secondname_desc" : "secondname_asc";
            ViewBag.AddressSortParm = sortOrder == "address_asc" ? "address_desc" : "address_asc";
            ViewBag.EmailSortParm = sortOrder == "email_asc" ? "email_desc" : "email_asc";
            ViewBag.TypeSortParm = sortOrder == "type_asc" ? "type_desc" : "type_asc";
            ViewBag.PhoneSortParm = sortOrder == "phone_asc" ? "phone_desc" : "phone_asc";
            ViewBag.MoveInDateSortParm = sortOrder == "moveindate_asc" ? "moveindate_desc" : "moveindate_asc";
            ViewBag.DateOfBirthSortParm = sortOrder == "dateofbirth_asc" ? "dateofbirth_desc" : "dateofbirth_asc";
            ViewBag.EmergencyNotesSortParm = sortOrder == "emergencynotes_asc" ? "emergencynotes_desc" : "emergencynotes_asc";
            ViewBag.EmergencyContactSortParm = sortOrder == "emergencycontact_asc" ? "emergencycontact_desc" : "emergencycontact_asc";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            IEnumerable<Resident> residentList;

            if (User.IsInRole(UserRole.Admin.ToString()))
            {
                residentList = _residentBusiness.GetAllResidents();
            }
            else
            {
                residentList = _residentBusiness.GetResidentByEmail(User.Identity.Name);
            }

            IEnumerable<ResidentViewModel> residentViewModelList = ResidentMapper.ToResidentViewModelList(residentList);

            if (!String.IsNullOrEmpty(searchString))
            {
                residentViewModelList = residentViewModelList.Where(s => s.Phone.Contains(searchString)
                                       || s.Address.Contains(searchString) || s.MoveInDate.ToString().Contains(searchString)
                                       || s.EmergencyNotes.Contains(searchString) || s.DateOfBirth.ToString().Contains(searchString)
                                       || s.EmergencyContact.Contains(searchString) || s.ResidentID.ToString().Contains(searchString)
                                       || s.ResidentType.ToString().Contains(searchString) || s.HavePets.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "residentid_desc":
                    residentViewModelList = residentViewModelList.OrderByDescending(s => s.ResidentID);
                    break;
                case "firstname_desc":
                    residentViewModelList = residentViewModelList.OrderByDescending(s => s.User.FirstName);
                    break;
                case "firstname_asc":
                    residentViewModelList = residentViewModelList.OrderBy(s => s.User.FirstName);
                    break;
                case "secondname_desc":
                    residentViewModelList = residentViewModelList.OrderByDescending(s => s.User.LastName);
                    break;
                case "secondname_asc":
                    residentViewModelList = residentViewModelList.OrderBy(s => s.User.LastName);
                    break;
                case "address_desc":
                    residentViewModelList = residentViewModelList.OrderByDescending(s => s.Address);
                    break;
                case "address_asc":
                    residentViewModelList = residentViewModelList.OrderBy(s => s.Address);
                    break;
                case "email_desc":
                    residentViewModelList = residentViewModelList.OrderByDescending(s => s.User.Email);
                    break;
                case "email_asc":
                    residentViewModelList = residentViewModelList.OrderBy(s => s.User.Email);
                    break;
                case "type_desc":
                    residentViewModelList = residentViewModelList.OrderByDescending(s => s.ResidentType.ToString());
                    break;
                case "type_asc":
                    residentViewModelList = residentViewModelList.OrderBy(s => s.ResidentType.ToString());
                    break;
                case "phone_desc":
                    residentViewModelList = residentViewModelList.OrderByDescending(s => s.Phone);
                    break;
                case "phone_asc":
                    residentViewModelList = residentViewModelList.OrderBy(s => s.Phone);
                    break;
                case "moveindate_desc":
                    residentViewModelList = residentViewModelList.OrderByDescending(s => s.MoveInDate);
                    break;
                case "moveindate_asc":
                    residentViewModelList = residentViewModelList.OrderBy(s => s.MoveInDate);
                    break;
                case "dateofbirth_desc":
                    residentViewModelList = residentViewModelList.OrderByDescending(s => s.DateOfBirth);
                    break;
                case "dateofbirth_asc":
                    residentViewModelList = residentViewModelList.OrderBy(s => s.DateOfBirth);
                    break;
                default:
                    residentViewModelList = residentViewModelList.OrderBy(s => s.ResidentID);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(residentViewModelList.ToPagedList(pageNumber, pageSize));
        }

        // GET: Resident/Details/5
        [CustomAuthorize(Roles = "Admin, Resident")]
        public ActionResult Details(int id)
        {
            Resident unit = _residentBusiness.GetResidentDetails(id);
            ResidentViewModel unitViewModel = ResidentMapper.ToResidentViewModel(unit);
            return View(unitViewModel);
        }

        // GET: Resident/Create

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ResidentViewModel residentViewModel = new ResidentViewModel();
            IEnumerable<User> userList = _userBusiness.GetAllUsers();
            List<UserViewModel> userViewModelList = UserMapper.ToUserViewModelList(userList);
            IEnumerable<Unit> unitList = _unitBusiness.GetAllUnits();
            List<UnitViewModel> unitViewModelList = UnitMapper.ToUnitViewModelList(unitList);
            residentViewModel.Users = new SelectList(userViewModelList, "UserID", "Email");
            residentViewModel.Units = new SelectList(unitViewModelList, "UnitID", "Name");
            return View(residentViewModel);
        }

        // POST: Resident/Create
        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create(ResidentViewModel residentViewModel)
        {
            IEnumerable<User> userList = _userBusiness.GetAllUsers();
            List<UserViewModel> userViewModelList = UserMapper.ToUserViewModelList(userList);
            IEnumerable<Unit> unitList = _unitBusiness.GetAllUnits();
            List<UnitViewModel> unitViewModelList = UnitMapper.ToUnitViewModelList(unitList);
            residentViewModel.Users = new SelectList(userViewModelList, "UserID", "Email");
            residentViewModel.Units = new SelectList(unitViewModelList, "UnitID", "Name");
            try
            {
                if (ModelState.IsValid)
                {
                    Resident resident = ResidentMapper.ToResident(residentViewModel);
                    Result<bool> result = _residentBusiness.AddResident(resident);
                    if (result.isSuccess)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result.errorMessage);
                        return View(residentViewModel);
                    }
                }
                else
                {
                    return View(residentViewModel);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("AppError", "Error");
            }
        }

        // GET: Resident/Edit/5
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Resident resident = _residentBusiness.GetResidentDetails(id);
            ResidentViewModel residentViewModel = ResidentMapper.ToResidentViewModel(resident);

            IEnumerable<User> userList = _userBusiness.GetAllUsers();
            List<UserViewModel> userViewModelList = UserMapper.ToUserViewModelList(userList);
            IEnumerable<Unit> unitList = _unitBusiness.GetAllUnits();
            List<UnitViewModel> unitViewModelList = UnitMapper.ToUnitViewModelList(unitList);
            residentViewModel.Users = new SelectList(userViewModelList, "UserID", "Email");
            residentViewModel.Units = new SelectList(unitViewModelList, "UnitID", "Name");

            return View(residentViewModel);
        }

        // POST: Resident/Edit/5
        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(int id, ResidentViewModel residentViewModel)
        {
            try
            {
                IEnumerable<User> userList = _userBusiness.GetAllUsers();
                List<UserViewModel> userViewModelList = UserMapper.ToUserViewModelList(userList);
                IEnumerable<Unit> unitList = _unitBusiness.GetAllUnits();
                List<UnitViewModel> unitViewModelList = UnitMapper.ToUnitViewModelList(unitList);
                residentViewModel.Users = new SelectList(userViewModelList, "UserID", "Email");
                residentViewModel.Units = new SelectList(unitViewModelList, "UnitID", "Name");

                if (ModelState.IsValid)
                {
                    Resident resident = ResidentMapper.ToResident(residentViewModel);
                    Result<bool> result = _residentBusiness.UpdateResident(resident);
                    if (result.isSuccess)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result.errorMessage);
                        return View(residentViewModel);
                    }
                }
                else
                {
                    return View(residentViewModel);
                }
            }
            catch
            {
                return RedirectToAction("AppError", "Error");
            }
        }

        // GET: Resident/Delete/5
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Resident resident = _residentBusiness.GetResidentDetails(id);
            ResidentViewModel residentViewModel = ResidentMapper.ToResidentViewModel(resident);
            return View(residentViewModel);
        }

        // POST: Resident/Delete/5
        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Result<bool> result = _residentBusiness.DeleteResident(id);
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
            catch
            {
                return View();
            }
        }
    }
}

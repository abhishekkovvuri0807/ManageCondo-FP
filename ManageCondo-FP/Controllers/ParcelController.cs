using ManagaCondo.Business;
using ManageCondo.DomainModels;
using ManageCondo_FP.Authentication;
using ManageCondo_FP.Common;
using ManageCondo_FP.Mappers;
using ManageCondo_FP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageCondo_FP.Controllers
{
    public class ParcelController : Controller
    {

        private readonly ParcelBusiness _parcelBusiness;
        private readonly UserBusiness _userBusiness;

        public ParcelController(ParcelBusiness parcelBusiness, UserBusiness userBusiness)
        {
            _parcelBusiness = parcelBusiness;
            _userBusiness = userBusiness;
        }
        // GET: Parcel
        [CustomAuthorize(Roles = "Admin, Resident")]
        public ActionResult Index()
        {
            IEnumerable<Parcel> parcelList;

            if (User.IsInRole(UserRole.Admin.ToString()))
            {
                parcelList = _parcelBusiness.GetAllParcels();
            }
            else
            {
                parcelList = _parcelBusiness.GetParcelByUser(User.Identity.Name);
            }

            IEnumerable<ParcelViewModel> residentViewModelList = ParcelMapper.ToParcelViewModelList(parcelList);

            return View(residentViewModelList);
        }

        // GET: Parcel/Details/5
        [CustomAuthorize(Roles = "Admin, Resident")]
        public ActionResult Details(int id)
        {
            Parcel unit = _parcelBusiness.GetParcelDetails(id);
            ParcelViewModel unitViewModel = ParcelMapper.ToParcelViewModel(unit);
            return View(unitViewModel);
        }

        // GET: Parcel/Create
        [CustomAuthorize(Roles = "Admin")]
        
        public ActionResult Create()
        {
            ParcelViewModel parcelViewModel = new ParcelViewModel();
            IEnumerable<User> userList = _userBusiness.GetAllResidents();
            List<UserViewModel> userViewModelList = UserMapper.ToUserViewModelList(userList);
            parcelViewModel.Users = new SelectList(userViewModelList, "UserID", "Email");
            return View(parcelViewModel);
        }

        // POST: Parcel/Create
        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create(ParcelViewModel parcelViewModel)
        {
            IEnumerable<User> userList = _userBusiness.GetAllResidents();
            List<UserViewModel> userViewModelList = UserMapper.ToUserViewModelList(userList);
            parcelViewModel.Users = new SelectList(userViewModelList, "UserID", "Email");
            try
            {
                if (ModelState.IsValid)
                {
                    Parcel parcel = ParcelMapper.ToParcel(parcelViewModel);
                    Result<bool> result = _parcelBusiness.AddParcel(parcel);
                    if (result.isSuccess)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result.errorMessage);
                        return View(parcelViewModel);
                    }
                }
                else
                {
                    return View(parcelViewModel);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("AppError", "Error");
            }
        }

        // GET: Parcel/Edit/5
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Parcel parcel = _parcelBusiness.GetParcelDetails(id);
            ParcelViewModel parcelViewModel = ParcelMapper.ToParcelViewModel(parcel);

            IEnumerable<User> userList = _userBusiness.GetAllResidents();
            List<UserViewModel> userViewModelList = UserMapper.ToUserViewModelList(userList);
            parcelViewModel.Users = new SelectList(userViewModelList, "UserID", "Email");
            return View(parcelViewModel);
        }

        // POST: Parcel/Edit/5
        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]

        public ActionResult Edit(int id, ParcelViewModel parcelViewModel)
        {
            try
            {
                IEnumerable<User> userList = _userBusiness.GetAllResidents();
                List<UserViewModel> userViewModelList = UserMapper.ToUserViewModelList(userList);
                parcelViewModel.Users = new SelectList(userViewModelList, "UserID", "Email");

                if (ModelState.IsValid)
                {
                    Parcel parcel = ParcelMapper.ToParcel(parcelViewModel);
                    Result<bool> result = _parcelBusiness.UpdateParcel(parcel);
                    if (result.isSuccess)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result.errorMessage);
                        return View(parcelViewModel);
                    }
                }
                else
                {
                    return View(parcelViewModel);
                }
            }
            catch
            {
                return RedirectToAction("AppError", "Error");
            }
        }

        // GET: Parcel/Delete/5
        [CustomAuthorize(Roles = "Admin")]

        public ActionResult Delete(int id)
        {
            Parcel unit = _parcelBusiness.GetParcelDetails(id);
            ParcelViewModel unitViewModel = ParcelMapper.ToParcelViewModel(unit);
            return View(unitViewModel);
        }

        // POST: Parcel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Result<bool> result = _parcelBusiness.DeleteParcel(id);
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

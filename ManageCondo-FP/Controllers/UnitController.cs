using ManagaCondo.Business;
using ManageCondo.Business;
using ManageCondo.DomainModels;
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
    public class UnitController : Controller
    {
        private readonly PropertyBusiness _propertyBusiness;
        private readonly UnitBusiness _unitBusiness;

        public UnitController(PropertyBusiness propertyBusiness, UnitBusiness unitBusiness)
        {
            _propertyBusiness = propertyBusiness;
            _unitBusiness = unitBusiness;
        }
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.UnitIDSortParm = String.IsNullOrEmpty(sortOrder) ? "unitid_desc" : "";
            ViewBag.NameSortParm = sortOrder == "name_asc" ? "name_desc" : "name_asc";
            ViewBag.DescriptionSortParm = sortOrder == "description_asc" ? "description_desc" : "description_asc";
            ViewBag.LevelSortParm = sortOrder == "level_asc" ? "level_desc" : "level_asc";
            ViewBag.FobkeySortParm = sortOrder == "fobkey_asc" ? "fobkey_desc" : "fobkey_asc";
            ViewBag.IsRentedSortParm = sortOrder == "isRented_asc" ? "isRented_desc" : "isRented_asc";
            ViewBag.StatusSortParm = sortOrder == "status_asc" ? "status_desc" : "status_asc";
            ViewBag.PropertyNameSortParm = sortOrder == "propertyname_asc" ? "propertyname_desc" : "propertyname_asc";



            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            IEnumerable<Unit> unitList = _unitBusiness.GetAllUnits();
            IEnumerable<UnitViewModel> unitViewModelList = UnitMapper.ToUnitViewModelList(unitList);



            if (!String.IsNullOrEmpty(searchString))
            {
                unitViewModelList = unitViewModelList.Where(s => s.Name.Contains(searchString)
                                       || s.Level.ToString().Contains(searchString) || s.Description.Contains(searchString)
                                       || s.FobKey.Contains(searchString) || s.Status.ToString().Contains(searchString)
                                       || s.IsRentedOut.ToString().Contains(searchString) || s.PropertyID.ToString().Contains(searchString) || s.UnitID.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "unitid_desc":
                    unitViewModelList = unitViewModelList.OrderByDescending(s => s.PropertyID);
                    break;
                case "name_desc":
                    unitViewModelList = unitViewModelList.OrderByDescending(s => s.Name);
                    break;
                case "name_asc":
                    unitViewModelList = unitViewModelList.OrderBy(s => s.Name);
                    break;
                case "level_desc":
                    unitViewModelList = unitViewModelList.OrderByDescending(s => s.Level);
                    break;
                case "level_asc":
                    unitViewModelList = unitViewModelList.OrderBy(s => s.Level);
                    break;
                case "fobkey_asc":
                    unitViewModelList = unitViewModelList.OrderByDescending(s => s.FobKey);
                    break;
                case "fobkey_desc":
                    unitViewModelList = unitViewModelList.OrderBy(s => s.FobKey);
                    break;
                case "description_desc":
                    unitViewModelList = unitViewModelList.OrderByDescending(s => s.Description);
                    break;
                case "description_asc":
                    unitViewModelList = unitViewModelList.OrderBy(s => s.Description);
                    break;
                case "status_desc":
                    unitViewModelList = unitViewModelList.OrderByDescending(s => s.Status);
                    break;
                case "status_asc":
                    unitViewModelList = unitViewModelList.OrderBy(s => s.Status);
                    break;
                case "isRented_desc":
                    unitViewModelList = unitViewModelList.OrderByDescending(s => s.IsRentedOut);
                    break;
                case "isRented_asc":
                    unitViewModelList = unitViewModelList.OrderBy(s => s.IsRentedOut);
                    break;
                case "propertyname_desc":
                    unitViewModelList = unitViewModelList.OrderByDescending(s => s.Property.Name);
                    break;
                case "propertyname_asc":
                    unitViewModelList = unitViewModelList.OrderBy(s => s.Property.Name);
                    break;
                default:
                    unitViewModelList = unitViewModelList.OrderBy(s => s.PropertyID);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(unitViewModelList.ToPagedList(pageNumber, pageSize));
        }

        // GET: Unit/Details/5
        public ActionResult Details(int id)
        {
            Unit unit = _unitBusiness.GetUnitDetails(id);
            UnitViewModel unitViewModel = UnitMapper.ToUnitViewModel(unit);
            return View(unitViewModel);
        }

        // GET: Unit/Create
        public ActionResult Create()
        {
            UnitViewModel unitViewModel = new UnitViewModel();
            IEnumerable<Property> propertyList = _propertyBusiness.GetAllProperties();
            List<PropertyViewModel> propertyViewModelList = PropertyMapper.ToPropertyViewModelList(propertyList);
            unitViewModel.Properties = new SelectList(propertyViewModelList, "PropertyID", "Name");
            return View(unitViewModel);
        }

        // POST: Unit/Create
        [HttpPost]
        public ActionResult Create(UnitViewModel unitViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Unit unit = UnitMapper.ToUnit(unitViewModel);
                    _unitBusiness.AddUnit(unit);
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

        // GET: Unit/Edit/5
        public ActionResult Edit(int id)
        {

            Unit unit = _unitBusiness.GetUnitDetails(id);
            UnitViewModel unitViewModel = UnitMapper.ToUnitViewModel(unit);

            IEnumerable<Property> propertyList = _propertyBusiness.GetAllProperties();
            List<PropertyViewModel> propertyViewModelList = PropertyMapper.ToPropertyViewModelList(propertyList);
            unitViewModel.Properties = new SelectList(propertyViewModelList, "PropertyID", "Name");
            return View(unitViewModel);
        }

        // POST: Unit/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UnitViewModel unitViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Unit unit = UnitMapper.ToUnit(unitViewModel);
                    _unitBusiness.UpdateUnit(unit);
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

        // GET: Unit/Delete/5
        public ActionResult Delete(int id)
        {
            Unit unit = _unitBusiness.GetUnitDetails(id);
            UnitViewModel unitViewModel = UnitMapper.ToUnitViewModel(unit);
            return View(unitViewModel);
        }

        // POST: Unit/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UnitViewModel unitViewModel)
        {
            try
            {
                _unitBusiness.DeleteUnit(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

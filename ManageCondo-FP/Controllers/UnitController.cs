using ManagaCondo.Business;
using ManageCondo.Business;
using ManageCondo.DomainModels;
using ManageCondo_FP.Mappers;
using ManageCondo_FP.Models;
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
        public ActionResult Index()
        {
            IEnumerable<Unit> unitList = _unitBusiness.GetAllUnits();
            List<UnitViewModel> unitViewModelList = UnitMapper.ToUnitViewModelList(unitList);
            return View(unitViewModelList);
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
            return View();
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
                if (ModelState.IsValid)
                {
                    Unit unit = UnitMapper.ToUnit(unitViewModel);
                    _unitBusiness.DeleteUnit(unit);
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
    }
}

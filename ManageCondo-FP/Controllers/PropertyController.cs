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
    public class PropertyController : Controller
    {
        private readonly PropertyBusiness _propertyBusiness;

        public PropertyController(PropertyBusiness propertyBusiness)
        {
            _propertyBusiness = propertyBusiness;
        }
        public ActionResult Index()
        {
            IEnumerable<Property> propertyList = _propertyBusiness.GetAllProperties();
            List<PropertyViewModel> propertyViewModelList = PropertyMapper.ToPropertyViewModelList(propertyList);
            return View(propertyViewModelList);
        }

        // GET: Property/Details/5
        public ActionResult Details(int id)
        {
            Property property = _propertyBusiness.GetPropertyDetails(id);
            PropertyViewModel propertyViewModel = PropertyMapper.ToPropertyViewModel(property);
            return View(propertyViewModel);
        }

        // GET: Property/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Property/Create
        [HttpPost]
        public ActionResult Create(PropertyViewModel propertyViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Property property = PropertyMapper.ToProperty(propertyViewModel);
                    _propertyBusiness.AddProperty(property);
                    return RedirectToAction(nameof(Index));
                } else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Property/Edit/5
        public ActionResult Edit(int id)
        {
            Property property = _propertyBusiness.GetPropertyDetails(id);
            PropertyViewModel propertyViewModel = PropertyMapper.ToPropertyViewModel(property);
            return View(propertyViewModel);
        }

        // POST: Property/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PropertyViewModel propertyViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Property property = PropertyMapper.ToProperty(propertyViewModel);
                    _propertyBusiness.UpdateProperty(property);
                    return RedirectToAction(nameof(Index));
                } else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Property/Delete/5
        public ActionResult Delete(int id)
        {
            Property property = _propertyBusiness.GetPropertyDetails(id);
            PropertyViewModel propertyViewModel = PropertyMapper.ToPropertyViewModel(property);
            return View(propertyViewModel);
        }

        // POST: Property/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PropertyViewModel propertyViewModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Property property = PropertyMapper.ToProperty(propertyViewModel);
                    _propertyBusiness.DeleteProperty(property);
                    return RedirectToAction(nameof(Index));
                } else
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

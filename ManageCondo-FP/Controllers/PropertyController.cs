using ManageCondo.Business;
using ManageCondo.DomainModels;
using ManageCondo_FP.Mappers;
using ManageCondo_FP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ManageCondo_FP.Authentication;

namespace ManageCondo_FP.Controllers
{
    //[CustomAuthorize(Roles = "Admin")]
    public class PropertyController : Controller
    {
        private readonly PropertyBusiness _propertyBusiness;

        public PropertyController(PropertyBusiness propertyBusiness)
        {
            _propertyBusiness = propertyBusiness;
        }
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.PropertyIDSortParm = String.IsNullOrEmpty(sortOrder) ? "propertyid_desc" : "";
            ViewBag.NameSortParm = sortOrder == "name_asc" ? "name_desc" : "name_asc";
            ViewBag.AddressSortParm = sortOrder == "address_asc" ? "address_desc" : "address_asc";
            ViewBag.EmailSortParm = sortOrder == "email_asc" ? "email_desc" : "email_asc";
            ViewBag.DescriptionSortParm = sortOrder == "description_asc" ? "description_desc" : "description_asc";
            ViewBag.StatusSortParm = sortOrder == "status_asc" ? "status_desc" : "status_asc";
            ViewBag.PhoneSortParm = sortOrder == "phone_asc" ? "phone_desc" : "phone_asc";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            IEnumerable<Property> propertyList = _propertyBusiness.GetAllProperties();
            IEnumerable<PropertyViewModel> propertyViewModelList = PropertyMapper.ToPropertyViewModelList(propertyList);

            if (!String.IsNullOrEmpty(searchString))
            {
                propertyViewModelList = propertyViewModelList.Where(s => s.Name.Contains(searchString)
                                       || s.Address.Contains(searchString) || s.Description.Contains(searchString)
                                       || s.Email.Contains(searchString) || s.Status.ToString().Contains(searchString)
                                       || s.Phone.Contains(searchString) || s.PropertyID.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "propertyid_desc":
                    propertyViewModelList = propertyViewModelList.OrderByDescending(s => s.PropertyID);
                    break;
                case "name_desc":
                    propertyViewModelList = propertyViewModelList.OrderByDescending(s => s.Name);
                    break;
                case "name_asc":
                    propertyViewModelList = propertyViewModelList.OrderBy(s => s.Name);
                    break;
                case "address_desc":
                    propertyViewModelList = propertyViewModelList.OrderByDescending(s => s.Address);
                    break;
                case "address_asc":
                    propertyViewModelList = propertyViewModelList.OrderBy(s => s.Address);
                    break;
                case "email_desc":
                    propertyViewModelList = propertyViewModelList.OrderByDescending(s => s.Email);
                    break;
                case "email_asc":
                    propertyViewModelList = propertyViewModelList.OrderBy(s => s.Email);
                    break;
                case "description_desc":
                    propertyViewModelList = propertyViewModelList.OrderByDescending(s => s.Description);
                    break;
                case "description_asc":
                    propertyViewModelList = propertyViewModelList.OrderBy(s => s.Description);
                    break;
                case "status_desc":
                    propertyViewModelList = propertyViewModelList.OrderByDescending(s => s.Status);
                    break;
                case "status_asc":
                    propertyViewModelList = propertyViewModelList.OrderBy(s => s.Status);
                    break;
                case "phone_desc":
                    propertyViewModelList = propertyViewModelList.OrderByDescending(s => s.Phone);
                    break;
                case "phone_asc":
                    propertyViewModelList = propertyViewModelList.OrderBy(s => s.Phone);
                    break;
                default:
                    propertyViewModelList = propertyViewModelList.OrderBy(s => s.PropertyID);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(propertyViewModelList.ToPagedList(pageNumber, pageSize));
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
                bool result = _propertyBusiness.DeleteProperty(id);
                if(result)
                {
                    return RedirectToAction(nameof(Index));
                } else
                {
                    ModelState.AddModelError(string.Empty, "Property cannot be deleted because it may be associated with units. Please unassign this property with units and then delete. ");
                    Property property = _propertyBusiness.GetPropertyDetails(id);
                    PropertyViewModel propertyViewModelData = PropertyMapper.ToPropertyViewModel(property);
                    return View(propertyViewModelData);
                }
            }
            catch
            {
                return View();
            }
        }
    }
}

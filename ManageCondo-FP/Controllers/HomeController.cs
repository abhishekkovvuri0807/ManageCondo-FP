using DAL;
using ManageCondo.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageCondo_FP.Controllers
{
    public class HomeController : Controller
    {
        PropertyRepository _propertyRepository;
        public HomeController(PropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public ActionResult Index()
        {
            //_propertyRepository.add();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
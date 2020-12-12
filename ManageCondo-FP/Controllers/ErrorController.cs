using System.Web.Mvc;

namespace ManageCondo_FP.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult AccessDenied()
        {
            return View();
        }

        public ActionResult AppError()
        {
            return View();
        }
    }
}
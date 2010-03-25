using System.Web.Mvc;

namespace UCDArchVsTemplate.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC 2!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}

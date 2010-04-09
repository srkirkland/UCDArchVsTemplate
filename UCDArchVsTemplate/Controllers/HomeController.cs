using System.Web.Mvc;
using UCDArch.Web.Controller;
using UCDArch.Web.Attributes;

namespace UCDArchVsTemplate.Controllers
{
    [HandleTransactionsManually]
    public class HomeController : SuperController
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

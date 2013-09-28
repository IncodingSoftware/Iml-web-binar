namespace IML.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult IndexIML()
        {
            return View();
        }

        [HttpGet]
        public ActionResult IndexJquery()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
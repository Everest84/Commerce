
using System.Web.Mvc;

namespace Commerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new Commerce.Models.SendCodeViewModel());
        }
        
        public ActionResult About()
        {
            return View();
        }
        
        public ActionResult Contact()
        {
            return View();
        }
        
        public ActionResult Goals()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace PocketChange.Controllers
{
    public class GoalsController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}
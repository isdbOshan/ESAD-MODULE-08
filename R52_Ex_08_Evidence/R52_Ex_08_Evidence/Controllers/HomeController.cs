using Microsoft.AspNetCore.Mvc;

namespace R52_Ex_08_Evidence.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

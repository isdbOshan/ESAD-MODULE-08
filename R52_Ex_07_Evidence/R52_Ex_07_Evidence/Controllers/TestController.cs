using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace R52_Ex_07_Evidence.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        // GET: Test
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}
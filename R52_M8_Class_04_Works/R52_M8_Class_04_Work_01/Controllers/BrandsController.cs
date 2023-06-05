using Microsoft.AspNetCore.Mvc;
using R52_M8_Class_04_Work_01.Models;
using R52_M8_Class_04_Work_01.Repositories.Interfaces;

namespace R52_M8_Class_04_Work_01.Controllers
{
    public class BrandsController : Controller
    {
        IUnitOfWork unitOfWork;
        IGenericRepo<Brand> repo;
        public BrandsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repo = this.unitOfWork.GetRepo<Brand>();
        }
        public async Task<IActionResult> Index()
        {
            return View(await this.repo.GetAsync());
        }
    }
}

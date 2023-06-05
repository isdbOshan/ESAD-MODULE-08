using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCoreMVCCore.Models;
using WebCoreMVCCore.ViewModel;

namespace WebCoreMVCCore.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeDBContext _context;
        private readonly IWebHostEnvironment env;
        public EmployeesController(EmployeeDBContext _context, IWebHostEnvironment env)
        {
            this._context = _context;
            this.env = env;
        }

        public async Task<IActionResult> All()
        {
            var data = await _context.Experiences.ToListAsync();
            return View(data);

        }
        public IActionResult Index()
        {
            return View(_context.Employees.Include(e=>e.Experience).ToList());
        }
        ///creating Section 

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeInputModel model)
        {
            if (ModelState.IsValid)
            {
                var emp = new Employee
                {
                    EmployeeName = model.EmployeeName,
                    JoinDate = model.JoinDate,
                    Salary = model.Salary,
                    WorkHome = model.WorkHome,

                    Picture = model.Picture

                };
                await _context.Employees.AddAsync(emp);
                await _context.SaveChangesAsync();
                return Json(new { id = emp.EmployeeId });
            }
            return View(null);
        }
        [HttpPost]
        public async Task<IActionResult> SaveExp(int id, ExperienceViewModel[] exp)
        {
            if (ModelState.IsValid)
            {
                foreach (var x in exp)
                {

                    await _context.Experiences.AddAsync(new Experience { ExperienceName = x.ExperienceName, ExperienceDescription = x.ExperienceDescription, EmployeeId = id });
                }
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        public async Task<IActionResult> Upload(PictureUploadViewModel data)
        {
            if (ModelState.IsValid)
            {
                string ext = Path.GetExtension(data.Picture.FileName).ToLower();
                string f = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                FileStream fs = new FileStream(Path.Combine(env.WebRootPath, "Pictures", f), FileMode.Create);
                await data.Picture.CopyToAsync(fs);
                fs.Close();
                return Json(new { Saved = f });
            }
            return Json(null);
        }



        ///don't go 
    }
}

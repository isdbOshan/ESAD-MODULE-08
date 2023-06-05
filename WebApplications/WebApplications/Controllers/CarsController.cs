using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplications.Models;
using WebApplications.ViewModels;

namespace WebApplications.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarInformationDbContext db;
        private readonly IWebHostEnvironment env;
        public CarsController(CarInformationDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
       
        public IActionResult Index()
        {
            return View(db.CarDetails.Include(d => d.PartsDetails).ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarDataInputViewModel model)
        {
            if (ModelState.IsValid)
            {
                var car = new CarDetail
                {
                    CarName = model.CarName,
                    LaunchDate = model.LaunchDate,
                    Price = model.Price,
                    IsStock = model.IsStock,

                    Picture = model.Picture

                };
                foreach (var s in model.PartsDetails)
                {
                    car.PartsDetails.Add(new PartsDetail { PartName = s.PartName, PartsPrice = s.PartsPrice });
                }
                await db.CarDetails.AddAsync(car);
                await db.SaveChangesAsync();
                return Json(new { id = car.CarDetailId });
            }
            return View(null);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var data = await db.CarDetails.Include(x => x.PartsDetails).FirstOrDefaultAsync(x => x.CarDetailId == id);
            if (data == null) return NotFound();
            var viewData = new CarDataEditViewModel
            {
                CarDetailId = data.CarDetailId,
                CarName = data.CarName,
                LaunchDate = data.LaunchDate,
                Price = data.Price,
                IsStock = data.IsStock,
                Picture = data.Picture
            };
            viewData.PartsDetails = data.PartsDetails.Select(x => new PartsDataInputViewModel { PartName = x.PartName, PartsPrice = x.PartsPrice, PartsDetailId = x.PartsDetailId }).ToList();
            return View(viewData);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(CarDataEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var data = await db.CarDetails.Include(x => x.PartsDetails).FirstOrDefaultAsync(x => x.CarDetailId == model.CarDetailId);
                if (data == null) return NotFound();
                db.PartsDetails.RemoveRange(data.PartsDetails);
                data.CarName     = model.CarName;
                data.Price = model.Price;
                data.LaunchDate = model.LaunchDate;
                data.IsStock = model.IsStock;
                data.Picture = model.Picture;
                foreach (var s in model.PartsDetails)
                {
                    data.PartsDetails.Add(new PartsDetail { PartName = s.PartName, PartsPrice = s.PartsPrice });
                }
                await db.SaveChangesAsync();
                return Json(new { success = true });
            }
            return Json(new { success = true });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            CarDetail d = new CarDetail { CarDetailId = id };
            db.Entry(d).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return Json(new { id = id });
        }
        public IActionResult GetSpecs(int id)
        {
            var data = db.PartsDetails.Where(x => x.CarDetailId == id).ToList();
            return Json(data);
        }
        public async Task<IActionResult> Upload(PictureDataInputViewModel data)
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
    }
}

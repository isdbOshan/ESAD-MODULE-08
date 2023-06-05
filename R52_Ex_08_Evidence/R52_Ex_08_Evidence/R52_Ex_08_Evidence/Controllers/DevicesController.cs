using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using R52_Ex_08_Evidence.Models;
using R52_Ex_08_Evidence.ViewModels;

namespace R52_Ex_08_Evidence.Controllers
{
    public class DevicesController : Controller
    {
        private readonly DeviceDbContext db;
        private readonly  IWebHostEnvironment env; 
        public DevicesController(DeviceDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        public async Task<IActionResult> All()
        {
            var data = await db.Specs.ToListAsync();
            return Json(data);
        }
        public IActionResult Index()
        {
            return View(db.Devices.Include(d=> d.Specs).ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DeviceInputModel model)
        { 
            if (ModelState.IsValid)
            {
                var device = new Device
                {
                    DeviceName = model.DeviceName,
                    ReleaseDate = model.ReleaseDate,
                    Price = model.Price,
                    OnSale = model.OnSale,
                   
                    Picture = model.Picture

                };
                foreach(var s in model.Specs)
                {
                    device.Specs.Add(new Spec { SpecName=s.SpecName, Value=s.Value});
                }
                await db.Devices.AddAsync(device);
                await db.SaveChangesAsync();
                return Json(new { id = device.DeviceId });
            }
            return View(null);
        }
        public async Task <IActionResult> Edit(int id)
        {
            var data = await db.Devices.Include(x=> x.Specs).FirstOrDefaultAsync(x=> x.DeviceId == id);
            if (data == null) return NotFound();
            var viewData = new DeviceEditModel
            {
                DeviceId = data.DeviceId,
                DeviceName = data.DeviceName,
                ReleaseDate = data.ReleaseDate,
                Price = data.Price,
                OnSale = data.OnSale,
                Picture = data.Picture
            };
            viewData.Specs = data.Specs.Select(x=> new SpecInputModel { SpecName = x.SpecName, Value = x.Value, SpecId=x.SpecId}).ToList();
            return View(viewData);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(DeviceEditModel model)
        {
            if (ModelState.IsValid)
            {
                var data = await db.Devices.Include(x => x.Specs).FirstOrDefaultAsync(x => x.DeviceId == model.DeviceId);
                if (data == null) return NotFound();
               db.Specs.RemoveRange(data.Specs);
                data.DeviceName = model.DeviceName;
                data.Price = model.Price;
                data.ReleaseDate=model.ReleaseDate;
                data.OnSale = model.OnSale;
                data.Picture = model.Picture;
                foreach(var s in model.Specs)
                {
                    data.Specs.Add(new Spec { SpecName = s.SpecName, Value = s.Value });
                }
                await db.SaveChangesAsync();
                return Json(new { success = true });
            }
            return Json(new { success = true });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Device d = new Device { DeviceId = id };
            db.Entry(d).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return Json(new { id = id });
        }
        public IActionResult GetSpecs(int id)
        {
            var data = db.Specs.Where(x => x.DeviceId == id).ToList();
            return Json(data);
        }
        public async Task<IActionResult> Upload(ImageUpload data)
        {
            if(ModelState.IsValid)
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

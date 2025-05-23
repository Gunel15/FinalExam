using FinalExam.DataAccessLayer;
using FinalExam.Models;
using FinalExam.ViewModels.Persons;
using FinalExam.ViewModels.Positions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PersonController(EateryCafeDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var datas=await _context.Persons.Select(x=>new PersonGetVM
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl=x.ImageUrl,
                PositionName=x.Position.Name
            }).ToListAsync();
            return View(datas);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Position=await _context.Positions.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create(PersonCreateVM vm)
        {
            ViewBag.Position = await _context.Positions.ToListAsync();  ////
            if (!ModelState.IsValid) 
                return View(vm);
            if (vm.ImageFile != null)
            {
                if (!vm.ImageFile.ContentType.StartsWith("image"))
                    ModelState.AddModelError("ImageFile", "File type must be image");
                
                if (vm.ImageFile.Length > 5 * 1024 * 1024)
                    ModelState.AddModelError("ImageFile", "File length must be less than 500kb");
            }

            string newImgName = Guid.NewGuid().ToString() + vm.ImageFile!.FileName;
            string path=Path.Combine("wwwroot","imgs","persons",newImgName);
            using FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            await vm.ImageFile.CopyToAsync(fs);

            Person person = new()
            {
                Name = vm.Name,
                ImageUrl = newImgName,
                PositionId = vm.PositionId,
            };

            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Position = await _context.Positions.ToListAsync();
            if (!id.HasValue || id.Value < 1)
                return BadRequest();
            var person=await _context.Persons.Where(x=>x.Id==id).Select(x=>new PersonUpdateVM
            {
                Name=x.Name,
                PositionId=x.PositionId,    
            }).FirstOrDefaultAsync();
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int?id,PersonUpdateVM vm)
        {
            ViewBag.Position = await _context.Positions.ToListAsync();
            if (!id.HasValue || id.Value < 1)
                return BadRequest();
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
                return NotFound();
            if (vm.ImageFile != null)
            {
                if (!vm.ImageFile.ContentType.StartsWith("image"))
                    ModelState.AddModelError("ImageFile", "File type must be image");

                if (vm.ImageFile.Length > 5 * 1024 * 1024)
                    ModelState.AddModelError("ImageFile", "File length must be less than 500kb");

                string newImgName = Guid.NewGuid().ToString() + vm.ImageFile!.FileName;
                string path = Path.Combine("wwwroot", "imgs", "persons", newImgName);
                using FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                await vm.ImageFile.CopyToAsync(fs);
                person.ImageUrl = newImgName;
            }
            person.Name = vm.Name;
            person.PositionId= vm.PositionId;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue || id.Value < 1)
                return BadRequest();
            var result=await _context.Persons.Where(x=>x.Id==id).ExecuteDeleteAsync();
            if(result==0) return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}

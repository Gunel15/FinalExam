using FinalExam.DataAccessLayer;
using FinalExam.ViewModels;
using FinalExam.ViewModels.Persons;
using FinalExam.ViewModels.Positions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Controllers
{
    public class HomeController(EateryCafeDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
           var persons=await _context.Persons.Select(x=>new PersonGetVM
           {
               Name = x.Name,
               Id = x.Id,
               ImageUrl = x.ImageUrl,
               PositionName=x.Position.Name
           }).ToListAsync();


            var positions = await _context.Positions.Select(x => new PositionGetVM
            {
                Name = x.Name,
                Id = x.Id,
            }).ToListAsync();

            HomeVM vm = new()
            {
                Positions = positions,
                Persons = persons
            };
            return View(vm);
        }
    }
}

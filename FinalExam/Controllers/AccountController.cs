using Azure.Identity;
using FinalExam.Models;
using FinalExam.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.Controllers
{
    public class AccountController(UserManager<User> _userManager,RoleManager<IdentityRole>_roleManager,SignInManager<User>_signInManager) : Controller
    {
        public async Task<IActionResult> CreateRoles()
        {
            await _roleManager.CreateAsync(new() { Name = "Admin" });
            await _roleManager.CreateAsync(new() { Name = "Member" });
            await _roleManager.CreateAsync(new() { Name = "Moderator" });
            return Ok("Roles Created");
        }
       public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid) 
                return View(vm);
            User user = new()
            {
                UserName = vm.UserName,
                FullName = vm.FullName,
                Email = vm.Email,
            };
            var result= await _userManager.CreateAsync(user,vm.Password);
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(vm);
            }
            await _userManager.AddToRoleAsync(user, "Member");
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);
            var user = await _userManager.FindByEmailAsync(vm.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Username or password is incorrect");
                return View(vm);
            }
            var result = await _signInManager.PasswordSignInAsync(user, vm.Password, isPersistent: false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password is incorrect");
                return View(vm);
            }
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> CreateAdmin()
        {
            User admin = new()
            {
                FullName = "Admin",
                UserName = "admin",
                Email = "admin@gmail.com"
            };
            await _userManager.CreateAsync(admin,"Admin123@");
            await _userManager.AddToRoleAsync(admin, "Admin");
            return Ok("Admin created");
        }
    }
}

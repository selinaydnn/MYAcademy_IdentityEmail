using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MYAcademy_IdentityEmail.Entities;
using MYAcademy_IdentityEmail.Models;

namespace MYAcademy_IdentityEmail.Controllers
{
    public class RegisterController1 : Controller
    {
        private readonly UserManager<AppUser> _usermanager;

        public RegisterController1(UserManager<AppUser> usermanager)
        {
            _usermanager = usermanager;
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel userRegisterViewModel)
        {
            AppUser appUser = new AppUser()
            {
                Name = userRegisterViewModel.Name,
                Surname = userRegisterViewModel.Surname,
                Email = userRegisterViewModel.Email,
                UserName = userRegisterViewModel.Username
            };

            var result = await _usermanager.CreateAsync(appUser, userRegisterViewModel.Password);

            if(result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();
            
        }
    }
}

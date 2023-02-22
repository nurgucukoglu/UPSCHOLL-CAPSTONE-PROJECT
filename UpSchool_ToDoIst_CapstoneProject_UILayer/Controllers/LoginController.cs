using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Net.Mail;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using UpSchool_ToDoIst_CapstoneProject_DTOLayer.AppUserDtos;
using UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace UpSchool_ToDoIst_CapstoneProject_UILayer.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserLoginDto appUserLoginDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(appUserLoginDto.Name, appUserLoginDto.PasswordHash, false, true);

                if (result.Succeeded)
                {                 
                    return RedirectToAction("Index", "Home");
                }
            }

            return View("Home");

        }
    }
}

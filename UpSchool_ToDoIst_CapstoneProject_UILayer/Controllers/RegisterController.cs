using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MimeKit;
using System;
using System.Net.Mail;
using System.Threading.Tasks;
using UpSchool_ToDoIst_CapstoneProject_DTOLayer.AppUserDtos;
using UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete;
using UpSchool_ToDoIst_CapstoneProject_UILayer.Models;

namespace UpSchool_ToDoIst_CapstoneProject_UILayer.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public RegisterController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }


        public void SendEmail( string emailcode, string emailAddress)
        {

            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("enurgucuk@gmail.com");
            mailMessage.To.Add(emailAddress);

            mailMessage.Subject = "Kayıt kodu";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = emailcode;

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Host = "smtp.gmail.com";
            client.Credentials = new System.Net.NetworkCredential("enurgucuk@gmail.com", "iexdzknwllkzunxw");
            client.Port = 587;
            client.EnableSsl = true;
            client.Send(mailMessage);


        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto p)
        {

            if (ModelState.IsValid)
            {
                AppUser appUser = _mapper.Map<AppUser>(p);

                appUser.EmailConfirmedControlCode = new Random().Next(10000, 999999).ToString();


                if (p.Password == p.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(appUser, p.Password);

                    if (result.Succeeded)
                    {
                        SendEmail(appUser.EmailConfirmedControlCode, p.Email);
                        return RedirectToAction("EmailConfirmed", "Register");
                    }

                    else  //validasyonları sağlamıyorsa
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }

                }

                else //şifreler uyuşmuyorsa
                {
                    ModelState.AddModelError("", "şifreler uyuşmuyor");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult EmailConfirmed()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> EmailConfirmed(AppUser appUser)
        {
            var user = await _userManager.FindByEmailAsync(appUser.Email);
            if (user.EmailConfirmedControlCode == appUser.EmailConfirmedControlCode)
            {
                user.EmailConfirmed = true;

                var result = await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}


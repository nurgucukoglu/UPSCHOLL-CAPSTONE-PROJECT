using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UpSchool_ToDoIst_CapstoneProject_DTOLayer.AppUserDtos;
using UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete;
using UpSchool_ToDoIst_CapstoneProject_UILayer.Models;

namespace UpSchool_ToDoIst_CapstoneProject_UILayer.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index() 
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            //rol atadan kullanıcılar listesinden seçilen kişi id
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();
            TempData["UserId"] = user.Id; //. başka actionlarda da kullanılabilir. Ama ViewBag de sadece assignrole gönderilebilir.
            var userRoles = await _userManager.GetRolesAsync(user);//gönderilen kullanıcının rolünü getirsin metotu


            List<RoleAssignModel> models = new List<RoleAssignModel>();

            foreach (var item in roles)  //rol atama yapar. Roles listesinden gelen rolü
            {
                RoleAssignModel roleAssignModel = new RoleAssignModel();
                roleAssignModel.Name = item.Name;
                roleAssignModel.RoleID = item.Id;
                roleAssignModel.Exists = userRoles.Contains(item.Name); //kullanıcının bulunduğu roller=userroles 
                models.Add(roleAssignModel);
            }
            return View(models);       
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignModel> model) //list çünkü birden fazla rolde gelebilir.
        {

            var userid = (int)TempData["UserId"];//Controller'dan UI'a TempData ile gönderdiğimiz veriyi burada controller'da çağırıp kullanıyoruz.

            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);

            foreach (var item in model) //bu kısımda ilgili rol seçilmişse db de full satır eklenir(2sütun vardı birbiriyle ilişkili aspneyuserroles), seçilmemişse full satır silinir.
            {
                if (item.Exists)//rol varsa checkbox da bunları yap:
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                    //checkboxda seçili ise rolü ekle
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                    //checkboxda seçili değilse o rolü sil 
                }
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateUser()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name); //kullanıcı adını name.i
            AppUserUpdateDto userUpdateModel = new AppUserUpdateDto();

            //atama işlemleri
            userUpdateModel.Name = values.Name;
            userUpdateModel.Surname = values.SurName;
            userUpdateModel.Email = values.Email;

            return View(userUpdateModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(AppUserUpdateDto p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
          
            //atamalar
            values.Name = p.Name;
            values.SurName = p.Surname;
            values.Email = p.Email;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, p.Password); //şifreyi aldık.
            var result = await _userManager.UpdateAsync(values);

            if (result.Succeeded) //başarılı bir şekilde güncellenmişe:
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

    }
}

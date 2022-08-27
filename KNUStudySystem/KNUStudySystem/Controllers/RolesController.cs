using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using KNUStudySystem.Models;
using KNUStudySystem.ViewModels;
using KNUStudySystem.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using System.Dynamic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MySql.Data.MySqlClient;

namespace KNUStudySystem.Controllers
{
    /*[Authorize(Roles = "Адміністратор")]*/
    [AllowAnonymous]
    public class RolesController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<AppUser> _userManager;
        private readonly Database _database;
        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, Database database)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _database = database;

        }
        public IActionResult Index() => View(_roleManager.Roles.ToList());

        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }

        public IActionResult UserList() => View(_userManager.Users.ToList());

        public async Task<IActionResult> Edit(string userId)
        {
            // получаем пользователя
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.FirstName + " " + user.LastName,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            // получаем пользователя
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var user_roles = await _userManager.GetRolesAsync(user);
                // получаем все роли
                var all_roles = _roleManager.Roles.ToList();
                // получаем список ролей, которые были добавлены
                var added_roles = roles.Except(user_roles);
                // получаем роли, которые были удалены
                var removed_roles = user_roles.Except(roles);
                if (added_roles.Contains("Викладач"))
                {
                    Teacher teacher = new Teacher
                    {
                        UserId = user.Id,
                        UserName = user.UserName
                    };
                    teacher.AddInfoToDb(_database);
                }
                if (removed_roles.Contains("Викладач"))
                {
                    Teacher teacher = new Teacher();
                    teacher.UserId = user.Id;
                    teacher.DeleteInfoFromDb(_database);
                }
                if (removed_roles.Contains("Студент"))
                {
                    Student student = new Student();
                    student.UserId = user.Id;
                    student.DeleteInfoFromDb(_database);
                }    
                await _userManager.AddToRolesAsync(user, added_roles);

                await _userManager.RemoveFromRolesAsync(user, removed_roles);
                
                

                return RedirectToAction("UserList");
            }

            return NotFound();
        }
    }
}

﻿    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using KNUStudySystem.Areas.Identity.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using KNUStudySystem.Models;

namespace KNUStudySystem.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly Database _database;

        public LoginModel(SignInManager<AppUser> signInManager, 
            ILogger<LoginModel> logger,
            UserManager<AppUser> userManager,
            Database database)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _database = database;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user != null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError("message", "Email not confirmed yet");
                    return Page();
                }

                if (await _userManager.CheckPasswordAsync(user, Input.Password) == false)
                {
                    ModelState.AddModelError("message", "Invalid credentials");
                    return Page();
                }
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(user.UserName, Input.Password, Input.RememberMe, lockoutOnFailure: true);                
                
                if (result.Succeeded)
                {
                    if (isUserFilledHisInfo(await _userManager.GetRolesAsync(user), user))
                    {
                        _logger.LogInformation("User logged in and redirected to his profile to fill specific info");
                        return RedirectToPage("./Manage/Index");
                    }
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                if (result.IsNotAllowed)
                {
                    _logger.LogWarning("User account is now allowed to login");
                    return Page();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
        private bool isUserFilledHisInfo (IList<string> user_roles, AppUser user)
        {
            if (user_roles.Contains("Викладач"))
            {
                Teacher teacher = new Teacher
                {
                    UserId = user.Id
                };
                teacher.GetInfoFromDb(_database);
                if (teacher.isFilledHisInfo())
                {
                    return true;
                }
            }
            else if (user_roles.Contains("Студент"))
            {
                Student student = new Student
                {
                    UserId = user.Id
                };
                student.GetInfoFromDb(_database);
                if (student.isFilledHisInfo())
                {
                    return true;
                }
            }
            else
            {
                return true;
            }

            return false;
        }
    }
}

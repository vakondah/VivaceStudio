﻿//CSC237
//Aliaksandra Hrechka
//05/08/2020
using CSC237_AHrechka_FinalProject.Models;
using CSC237_AHrechka_FinalProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private VivaceContext context;

        public AccountController(UserManager<User> userMngr, SignInManager<User> signInMngr, VivaceContext ctx)
        {
            userManager = userMngr;
            signInManager = signInMngr;
            context = ctx;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User 
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult LogIn(string returnURL = "")
        {
            var model = new LoginViewModel { ReturnURL = returnURL };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Username, model.Password, isPersistent: model.RememberMe,
                    lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnURL)
                        && Url.IsLocalUrl(model.ReturnURL))
                    {
                        return Redirect(model.ReturnURL);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // opens account settings page:
        [Route("Settings/Account")]
        [HttpGet]
        public async Task<IActionResult> AccountSettings()
        {
            var user = await userManager.GetUserAsync(User);

            ChangePasswordViewModel model = new ChangePasswordViewModel
            {
                Id = user.Id,
                Email = user.Email
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.GetUserAsync(User);

                var result = await userManager.ChangePasswordAsync(user, model.OldPassword,
                                                        model.NewPassword);
                if (result.Succeeded)
                {
                    TempData["message"] = "Your password was successfully changed";
                    model.OldPassword = "";
                    return RedirectToAction("AccountSettings");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View("AccountSettings", model);
        }

        
        public IActionResult RemoveAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Delete()
        {
            //get current user
            var user = await userManager.GetUserAsync(User);

            //Sign user out
            await signInManager.SignOutAsync();

            //Delete user's image and practices:
            Image img = context.Images
               .Where(i => i.UserID == user.Id)
               .FirstOrDefault();

            List<PracticeLog> pl = new List<PracticeLog>();
            pl = context.PracticeLog
                .Where(u => u.UserID == user.Id)
                .ToList();

            foreach (var item in pl)
            {
                context.PracticeLog.Remove(item);
            }

            if (img != null)
            {
                context.Images.Remove(img);
            }

            //delete user:
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}

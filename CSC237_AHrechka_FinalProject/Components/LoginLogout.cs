using CSC237_AHrechka_FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Components
{
    public class LoginLogout : ViewComponent
    {
        private SignInManager<User> signInManager { get; set; }
        public LoginLogout(SignInManager<User> signInMngr) => signInManager = signInMngr;

        //User parameter sent to Invoke() method is the User property of the View class
        //which is of type System.Security.Clames.ClaimsPrincipal
        public IViewComponentResult Invoke(ClaimsPrincipal user)
        {
            if (signInManager.IsSignedIn(user))
            {
                return View(true);
            }
            else
            {
                return View(false);
            }
        }

    }
}

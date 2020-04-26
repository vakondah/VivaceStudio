//CSC237
//Aliaksandra Hrechka
//04/19/2020
using CSC237_AHrechka_FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Controllers
{
    public class ChatController: Controller
    {
        private VivaceContext context;
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;


        public ChatController(VivaceContext ctx, UserManager<User> userMngr,
                                 SignInManager<User> signInMngr)
        {
            context = ctx;
            userManager = userMngr;
            signInManager = signInMngr;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Chatting Room";

            List<User> users = new List<User>();
            foreach (User user in userManager.Users)
            {
                users.Add(user);
            }

            User currentUser = await userManager.GetUserAsync(User);
            users.Remove(currentUser);
            ViewBag.CurrentUser = currentUser.FullName;

            return View(users);
        }

        
        
    }
}

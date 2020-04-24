//CSC237
//Aliaksandra Hrechka
//04/19/2020
using CSC237_AHrechka_FinalProject.Models;
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
        public ChatController(VivaceContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index(int id = 1)
        {
            ViewBag.Title = "Chatting Room";

            List<User> users = context.Users
                //.Include(u => u.Image)
                .OrderBy(u => u.LastName).ToList();
            User currentUser = context.Users.Find(id);
            users.Remove(currentUser);
            ViewBag.CurrentUser = currentUser.FullName;

                      
            return View(users);
        }

        
        
    }
}

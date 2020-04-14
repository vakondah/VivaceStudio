using CSC237_AHrechka_FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            ViewBag.Title = "Chatting Room";

            List<User> users = context.Users.OrderBy(u => u.LastName).ToList();
           
            return View(users);
        }
        
    }
}

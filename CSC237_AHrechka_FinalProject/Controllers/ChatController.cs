//CSC237
//Aliaksandra Hrechka
//05/08/2020
using CSC237_AHrechka_FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Controllers
{
    [Authorize]
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

        //This action displays last 5 messages from the chat.
        //List of users displayed by UsersWithImages View Component.
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Chatting Room";

            User currentUser = await userManager.GetUserAsync(User);
                        
            var messages = await context.Messages
                .OrderByDescending(m => m.MessageID)
                .Take(5)
                .ToListAsync();

            if (User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUser = currentUser.FullName;
            }

            return View(messages);
        }


        // This action saves message to the database:
        public async Task<IActionResult> CreateMessage(Message message)
        {
            User user = await userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                message.UserName = user.FullName;
                message.UserID = user.Id;
                await context.Messages.AddAsync(message);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        
        
    }
}

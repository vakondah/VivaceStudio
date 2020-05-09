using CSC237_AHrechka_FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CSC237_AHrechka_FinalProject.Components
{
    public class UsersWithImages : ViewComponent
    {
        private VivaceContext context;
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;


        public UsersWithImages(VivaceContext ctx, UserManager<User> userMngr,
                                 SignInManager<User> signInMngr)
        {
            context = ctx;
            userManager = userMngr;
            signInManager = signInMngr;
        }

        

        public IViewComponentResult Invoke()
        {
            List<User> users = new List<User>();
            foreach (User user in userManager.Users)
            {
                users.Add(user);
            }

            // getting current user id
            string id = userManager.GetUserId(Request.HttpContext.User);
            User currentUser = userManager.Users
                .FirstOrDefault(i => i.Id == id);

            // removing current user from the list of users
            users.Remove(currentUser);

            List<Image> images = context.Images.ToList();

            // creating dictionary that contains users and their pictures
            Dictionary<User, string> dict = new Dictionary<User, string>();

            foreach (var user in users)
            {
                string imageDataURL = "";
                foreach (var image in images)
                {
                    if (user.Id == image.UserID)
                    {
                        string imageBase64Data = Convert.ToBase64String(image.ImageData);
                        imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                    }
                }
                dict.Add(user, imageDataURL);
            }
            return View(dict);
        }
    }
}

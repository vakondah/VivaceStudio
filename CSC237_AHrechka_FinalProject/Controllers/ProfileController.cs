//CSC237
//Aliaksandra Hrechka
//04/19/2020
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CSC237_AHrechka_FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSC237_AHrechka_FinalProject.Controllers
{
    public class ProfileController : Controller
    {
        private VivaceContext context;
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        public ProfileController(VivaceContext ctx, UserManager<User> userMngr,
                                 SignInManager<User> signInMngr)
        {
            context = ctx;
            userManager = userMngr;
            signInManager = signInMngr;
        }

       
        // opens Personal Info page and passes users info from the db to view:
        [Route("Profile")]
        public async Task<IActionResult> PersonalInfo()
        {
            var user = await userManager.GetUserAsync(User);
           
            return View(user);
        }

        // opens view and fills out ViewBags to be passed to the view:
        [Route("Profile/School")]
        public async Task<IActionResult> SchoolInfo()
        {
            var user = await userManager.GetUserAsync(User);
            StoreLists();
           
            return View(user);
        }

        // opens personal student's card and passes student info:
        [Route("Profile/Card")]
        [HttpGet]
        public IActionResult Card(string id)
        {
            var user = context.Users
                .Include(s => s.School)
                .Include(i => i.Instrument)
                .FirstOrDefault(i => i.Id == id);
            Image img = context.Images
                .Where(i => i.UserID == id)
                .FirstOrDefault();
            
            if (img != null)
            {
                string imageBase64Data = Convert.ToBase64String(img.ImageData);
                string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                ViewBag.ImageDataUrl = imageDataURL;
            }
            return View(user);

        }

        [HttpGet]
        public async Task<IActionResult> ProfilePicture()
        {
            var user = await userManager.GetUserAsync(User);
            Image image = context.Images
                .Where(i => i.UserID == user.Id)
                .FirstOrDefault();
            if (image != null)
            {
                string imageBase64Data = Convert.ToBase64String(image.ImageData);
                string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                ViewBag.ImageDataUrl = imageDataURL;
                return View(image);
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> SaveImage(Image image)
        {
            var user = await userManager.GetUserAsync(User);

            foreach (var file in Request.Form.Files)
            {
                if (image.UserID == null)
                {
                    //Image object is created and its properties set
                    Image img2 = new Image
                    {
                        ImageTitle = file.FileName,
                        ImageID = image.ImageID,
                        UserID = user.Id
                    };

                    //To grab the image data the code creates a 
                    //MemoryStream and copies the uploaded image data into it using the CopyTo() method
                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);

                    //MemoryStream is converted into a byte array using its ToArray() method.
                    //This byte array is stored in the ImageData property of the Image object.
                    img2.ImageData = ms.ToArray();

                    ms.Close();
                    ms.Dispose();

                    context.Images.Add(img2);
                    context.SaveChanges();
                }
                else
                {
                    Image img2 = new Image
                    {
                        ImageTitle = file.FileName,
                        ImageID = image.ImageID,
                        UserID = image.UserID
                    };

                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);

                    img2.ImageData = ms.ToArray();

                    ms.Close();
                    ms.Dispose();

                    context.Images.Update(img2);
                    context.SaveChanges();
                }
            }

            Image img = context.Images.OrderByDescending(i => i.ImageID).FirstOrDefault();
            string imageBase64Data = Convert.ToBase64String(img.ImageData);
            string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
            ViewBag.ImageDataUrl = imageDataURL;

            return RedirectToAction("ProfilePicture");
        }

        // opens practice log settings page:
        [Route("Settings/Log")]
        public IActionResult PracticeLogSettings()
        {
            return View();
        }

        // opens chat settings page:
        [Route("Settings/Chat")]
        public IActionResult ChatSettings()
        {
            return View();
        }

       // opens account settings page:
       [Route("Settings/Account")]
        public IActionResult AccountSettings()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveSchoolInfo(User user)
        {
           
            if (ModelState.IsValid)
            {
                var newUser = await userManager.GetUserAsync(User);

                newUser.Id = user.Id;
                newUser.StudentNumber = user.StudentNumber;
                newUser.SchoolID = user.SchoolID;
                newUser.InstrumentID = user.InstrumentID;
                newUser.TeacherID = user.TeacherID;
                newUser.MyClasses = user.MyClasses;

                await userManager.UpdateAsync(newUser);
                context.SaveChanges();
                TempData["message"] = "Your school info was updated";
                return RedirectToAction("SchoolInfo");
            }
            else
            {
                StoreLists();
                return RedirectToAction("SchoolInfo", user);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> SavePersonalInfo(User user)
        {
            var newUser = await userManager.GetUserAsync(User);
           
            if (ModelState.IsValid)
            {
                newUser.Id = user.Id;
                newUser.FirstName = user.FirstName;
                newUser.LastName = user.LastName;
                newUser.DateOfBirth = user.DateOfBirth;
                newUser.FirstName = user.FirstName;
                newUser.Bio = user.Bio;
                newUser.Address = user.Address;
                newUser.Phone = user.Phone;

                await userManager.UpdateAsync(newUser);
                context.SaveChanges();

                TempData["message"] = "Your personal info was updated";
                return RedirectToAction("PersonalInfo");
            }
            else
            {
                return RedirectToAction("PersonalInfo", user);
            }
        }
        
        private void StoreLists()
        {
            ViewBag.Schools = context.Schools
                .OrderBy(s => s.SchoolName)
                .ToList();
            ViewBag.Instruments = context.Instruments
                .OrderBy(i => i.InstrumentName)
                .ToList();
            ViewBag.Teachers = context.Teachers
                .OrderBy(l => l.LastName)
                .ToList();
        }

        

    }
}
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CSC237_AHrechka_FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSC237_AHrechka_FinalProject.Controllers
{
    public class ProfileController : Controller
    {
        private VivaceContext context;
        public ProfileController(VivaceContext ctx)
        {
            context = ctx;
        }

        // opens Personal Info page and passes users info from the mock repository to view:
        [Route("Profile")]
        public IActionResult PersonalInfo(int id = 2)
        {
            var user = context.Users.Find(id);
            return View(user);
        }

        // opens view and fills out ViewBags to be passed to the view:
        [Route("Profile/School")]
        public IActionResult SchoolInfo(int id = 2)
        {
            ViewBag.Schools = context.Schools.OrderBy(s => s.SchoolName).ToList();// TODO: put them in a method!
            ViewBag.Instruments = context.Instruments.OrderBy(i => i.InstrumentName).ToList();
            ViewBag.Teachers = context.Teachers.OrderBy(l => l.LastName).ToList();
            var schoolInfo = context.Users
                .FirstOrDefault(i => i.UserID == id);
            return View(schoolInfo);
        }

        // opens personal student's card and passes student info:
        [Route("Profile/Card")]
        [HttpGet]
        public IActionResult Card(int id = 2)
        {
            var user = context.Users
                .Include(s => s.School)
                .Include(i => i.Instrument)
                .FirstOrDefault(i => i.UserID == id);
            Image img = context.Images.OrderByDescending(i => i.ImageID).FirstOrDefault();
            if (img != null)
            {
                string imageBase64Data = Convert.ToBase64String(img.ImageData);
                string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                ViewBag.ImageDataUrl = imageDataURL;
            }
            return View(user);

        }

        [HttpGet]
        public IActionResult ProfilePicture(int id = 2)
        {
            var image = context.Images
                .Include(i => i.User)
                .Where(i => i.UserID == id)
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
        public IActionResult SaveImage(Image image)
        {
            foreach (var file in Request.Form.Files)
            {
                //Image object is created and its ImageTitle properties set
                Image img2 = new Image
                {
                    ImageTitle = file.FileName,
                    ImageID = image.ImageID,
                    UserID = image.UserID
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

                context.Images.Update(img2);
                context.SaveChanges();
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
        public IActionResult SaveSchoolInfo(User user)
        {

            if (ModelState.IsValid)
            {
                context.Users.Update(user);
                context.SaveChanges();
                return RedirectToAction("SchoolInfo");
            }
            else
            {
                ViewBag.Schools = context.Schools.OrderBy(s => s.SchoolName).ToList();// TODO: put them in a method!
                ViewBag.Instruments = context.Instruments.OrderBy(i => i.InstrumentName).ToList();
                ViewBag.Teachers = context.Teachers.OrderBy(l => l.LastName).ToList();
                return RedirectToAction("SchoolInfo", user);
            }

            
        }
        
        

        

    }
}
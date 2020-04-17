﻿using CSC237_AHrechka_FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Controllers
{
    public class PracticeLogController: Controller
    {
        public DateTime test;
        private VivaceContext context;
        public PracticeLogController(VivaceContext ctx) => context = ctx;
        
        //opens Practice Log page:
        [Route("Log")]
        public IActionResult Index()
        {

            return View();
        }

        // creates PracticeLog object and saves it to the DB
        [HttpPost]
        public IActionResult Start(int id = 1)
        {
            PracticeLog pl = new PracticeLog
            {
                PracticeStartTime = DateTime.Now,
                UserID = id,
                Date = DateTime.Now,
                DayOfWeek = DateTime.Now.DayOfWeek
            };
            context.PracticeLog.Add(pl);
            context.SaveChanges();
            
            return RedirectToAction("Index", pl);
        }

        [HttpGet]
        public IActionResult Stop(int id = 1)
        {
            PracticeLog practice = context.PracticeLog
                .Where(p => p.UserID == id)
                .OrderByDescending(p => p.Date)
                .FirstOrDefault();

            practice.PracticeEndTime = DateTime.Now;
            TimeSpan span = practice.PracticeEndTime.Subtract(practice.PracticeStartTime);
            

            if (span.Hours > 0)
            {
                practice.Duration = $"{span.Hours} hours {span.Minutes} min";
            }
            else
            {
                practice.Duration = $"{span.Minutes} min {span.Seconds} sec";
            }

           
            return View("PracticeDetails", practice);
        }

        // saves practice details to the DB
        public IActionResult Save(PracticeLog practice)
        {
            if (ModelState.IsValid)
            {
                context.PracticeLog.Update(practice);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("PracticeDetails", practice);
            }
        }

    }
}

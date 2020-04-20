using CSC237_AHrechka_FinalProject.Models;
using Microsoft.AspNetCore.Http;
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
        public IActionResult Index(int id = 1)
        {
            ViewBag.Practices = context.PracticeLog
                            .Where(u => u.UserID == id)
                            .Where(u =>u.InProgress != true)
                            .OrderByDescending(u => u.PracticeLogID)
                            .ToList();
            ViewBag.InProgress = false;
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
                DayOfWeek = DateTime.Now.DayOfWeek,
                InProgress = true
            };

            // setting new session for started practice
            HttpContext.Session.SetInt32("logID", pl.PracticeLogID);
            
            context.PracticeLog.Add(pl);
            context.SaveChanges();
            ViewBag.InProgress = true;
            return RedirectToAction("Index", pl);
        }

        [HttpGet]
        public IActionResult Stop(int id = 1)
        {
            // here I am checking if start was clicked
            // and practice exists in the database:
            int? logID = HttpContext.Session.GetInt32("logID");

            if (logID != null)
            {
                PracticeLog practice = context.PracticeLog
                .Where(p => p.UserID == id)

                .OrderByDescending(p => p.Date)
                .FirstOrDefault();

                practice.InProgress = false;
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
            // if session is empty nothing happens
            // user cannot click stop without clicking start
            else
            {
                ViewBag.Practices = context.PracticeLog
                            .Where(u => u.UserID == id)
                            .Where(u => u.InProgress != true)
                            .OrderByDescending(u => u.PracticeLogID)
                            .ToList();
                return View("Index");
            }
                

            
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var practice = context.PracticeLog.Find(id);
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

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var practice = context.PracticeLog.Find(id);
            return View(practice);
        }

        [HttpPost]
        public RedirectToActionResult Delete(PracticeLog practice)
        {
           
            context.PracticeLog.Remove(practice);
            context.SaveChanges();
           
            return RedirectToAction("Index");
        }

    }
}

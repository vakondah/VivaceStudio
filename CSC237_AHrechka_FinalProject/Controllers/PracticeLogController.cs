﻿//CSC237
//Aliaksandra Hrechka
//04/19/2020
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
            //cheking if practice already started:
            string start = HttpContext.Session.GetString("start");
            if (start != null)
            {
                TempData["message"] = start;
            }


            ViewBag.Practices = context.PracticeLog
                            .Where(u => u.UserID == id)
                            .Where(u =>u.InProgress != true)
                            .OrderByDescending(u => u.PracticeLogID)
                            .ToList();

            var startTimes = context.PracticeLog
                 .Where(u => u.UserID == id)
                 .Where(u => u.InProgress == false)
                 .Select(u => u.PracticeStartTime)
                 .ToList();
            var endTimes = context.PracticeLog
                 .Where(u => u.UserID == id)
                 .Where(u => u.InProgress == false)
                 .Select(u => u.PracticeEndTime)
                 .ToList();

            List<TimeSpan> spans = new List<TimeSpan>();

            //combining startTimes and endTimes into one list:
            var startAndEnds = startTimes.Zip(endTimes, (s, e) => new { Start = s, End = e });

            //finding durations and adding them to the spans list:
            foreach ( var item in startAndEnds)
            {
                var span = item.End.Subtract(item.Start);
                spans.Add(span);
            }

            TimeSpan total = new TimeSpan();

            // calculating total
            foreach (var item in spans)
            {
                total += item;
            }

            // calculating average:
            var average = total / spans.Count();
            string averagePracticeTime = $"{average.Hours}h {average.Minutes}m {average.Seconds}s";
            ViewBag.Average = averagePracticeTime;

            int desiredTimeInSeconds = 30 * 60;
            int realTimeInSeconds = Convert.ToInt32(average.Hours*3600 + average.Minutes * 60 + average.Seconds);
            int progressBarValue = (realTimeInSeconds * 100) / desiredTimeInSeconds;

            ViewBag.Width = (progressBarValue*0.01).ToString("P0");

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

            // setting new sessions for started practice
            HttpContext.Session.SetInt32("logID", pl.PracticeLogID);
            HttpContext.Session.SetString("start", $"Practice started at {pl.PracticeStartTime.ToShortTimeString()}");
            
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

                string start = HttpContext.Session.GetString("start");
                if (start != null)
                {
                    HttpContext.Session.Remove("start");
                }

                TempData["message"] = "Your practice details were saved.";

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
            TempData["message"] = $"Practice was deleted.";
            context.PracticeLog.Remove(practice);
            context.SaveChanges();
            
            return RedirectToAction("Index");
        }

    }
}

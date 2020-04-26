//CSC237
//Aliaksandra Hrechka
//04/19/2020
using CSC237_AHrechka_FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Controllers
{
    public class PracticeLogController: Controller
    {
        
        private VivaceContext context;
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        public PracticeLogController(VivaceContext ctx, UserManager<User> userMngr,
                                 SignInManager<User> signInMngr)
        {
            context = ctx;
            userManager = userMngr;
            signInManager = signInMngr;
        }
        
        //opens Practice Log page:
        [Route("Log")]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);

            //cheking if practice already started:
            string start = HttpContext.Session.GetString("start");

            if (start != null)
            {
                TempData["message"] = start;
            }

            user.MyPractices = context.PracticeLog
                            .Where(u => u.UserID == user.Id)
                            .Where(u => u.InProgress != true)
                            .OrderByDescending(u => u.PracticeLogID)
                            .ToList();

            ViewBag.Practices = user.MyPractices;

            if (user.MyPractices.Any())
            {
                var startTimes = context.PracticeLog
                 .Where(u => u.UserID == user.Id)
                 .Where(u => u.InProgress == false)
                 .Select(u => u.PracticeStartTime)
                 .ToList();
                var endTimes = context.PracticeLog
                     .Where(u => u.UserID == user.Id)
                     .Where(u => u.InProgress == false)
                     .Select(u => u.PracticeEndTime)
                     .ToList();

                List<TimeSpan> spans = new List<TimeSpan>();

                //combining startTimes and endTimes into one list:
                var startAndEnds = startTimes.Zip(endTimes, (s, e) => new { Start = s, End = e });

                //finding durations and adding them to the spans list:
                foreach (var item in startAndEnds)
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
                int realTimeInSeconds = Convert.ToInt32(average.Hours * 3600 + average.Minutes * 60 + average.Seconds);
                int progressBarValue = (realTimeInSeconds * 100) / desiredTimeInSeconds;

                ViewBag.Width = (progressBarValue * 0.01).ToString("P0");
            }
            else
            {
                ViewBag.Average = 0;
                ViewBag.Width = 0;
            }


            return View();
        }

        // creates PracticeLog object and saves it to the DB
        [HttpPost]
        public async Task<IActionResult> Start()
        {
            var user = await userManager.GetUserAsync(User);

            PracticeLog pl = new PracticeLog();

            pl.PracticeLogID = Guid.NewGuid().ToString();
            pl.PracticeStartTime = DateTime.Now;
            pl.UserID = user.Id;
            pl.Date = DateTime.Now;
            pl.DayOfWeek = DateTime.Now.DayOfWeek;
            pl.InProgress = true;
            

            // setting new sessions for started practice
            HttpContext.Session.SetString("logID", pl.PracticeLogID);
            HttpContext.Session.SetString("start", $"Practice started at " +
                $"{pl.PracticeStartTime.ToShortTimeString()}");
            
            context.PracticeLog.Add(pl);
            context.SaveChanges();
           
            return RedirectToAction("Index", pl);
        }

        [HttpGet]
        public async Task<IActionResult> Stop()
        {
            var user = await userManager.GetUserAsync(User);

            // here I am checking if start was clicked
            // and practice exists in the database:
            string logID = HttpContext.Session.GetString("logID");

            if (logID != null)
            {
                PracticeLog practice = context.PracticeLog
                .Where(p => p.PracticeLogID == logID)
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
                            .Where(u => u.UserID == user.Id)
                            .Where(u => u.InProgress != true)
                            .OrderByDescending(u => u.PracticeLogID)
                            .ToList();
                return View("Index");
            }
            
        }

        [HttpGet]
        public IActionResult Edit(string id)
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
        public ViewResult Delete(string id)
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

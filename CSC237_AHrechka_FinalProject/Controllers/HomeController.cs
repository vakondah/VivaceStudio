﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CSC237_AHrechka_FinalProject.Models;

namespace CSC237_AHrechka_FinalProject.Controllers
{
    public class HomeController : Controller
    {
        // opens Index page:
        public IActionResult Index()
        {
            return View();
        }
        //opens catting room page:
        [Route("Chat")]
        public IActionResult Chat()
        {
            return View();
        }
        //opens Practice Log page:
        [Route("Log")]
        public IActionResult PracticeLog()
        {
            return View();
        }
        
    }
}

//CSC237
//Aliaksandra Hrechka
//04/19/2020
using System;
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
        
      
        
    }
}

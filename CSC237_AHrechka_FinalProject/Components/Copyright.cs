using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Components
{
    public class Copyright : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            int currentYear = DateTime.Today.Year;
            return View(currentYear);
        }
    }
}

using Microsoft.AspNetCore.Mvc;


namespace CSC237_AHrechka_FinalProject.Components
{
    public class Stopwatch : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

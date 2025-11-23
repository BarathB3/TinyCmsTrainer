using Microsoft.AspNetCore.Mvc;

namespace TinyCmsTrainer.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Rolam()
        {
            return View();
        }
        public IActionResult Szolgaltatasok()
        {
            return View();
        }

        public IActionResult Kapcsolat()
        {
            return View();
        }

    }
}



using Microsoft.AspNetCore.Mvc;

namespace TinyCmsTrainer.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TinyCmsTrainer.Data;
using TinyCmsTrainer.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;   // ← EZ a jó helye

namespace TinyCmsTrainer.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.Users
                .Include(u => u.Role)
                .ToList();

            return View(users);
        }

        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_context.Roles.ToList(), "Id", "RoleName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Roles = new SelectList(_context.Roles.ToList(), "Id", "RoleName");
            return View(user);
        }
    }
}

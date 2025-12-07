using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TinyCmsTrainer.Data;
using TinyCmsTrainer.Models;
using System.Linq;

namespace TinyCmsTrainer.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Felhasználók listázása
        public IActionResult Index()
        {
            var users = _context.Users
                .Include(u => u.Role)
                .ToList();

            return View(users);
        }

        // GET: új felhasználó létrehozása
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_context.Roles.ToList(), "Id", "RoleName");
            return View();
        }

        // POST: új felhasználó mentése
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                // Hibák naplózása konzolra
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    foreach (var error in state.Errors)
                    {
                        Console.WriteLine($"HIBA a(z) '{key}' mezőnél: {error.ErrorMessage}");
                    }
                }

                // Újratöltjük a szerepkörök listát
                ViewBag.Roles = new SelectList(_context.Roles.ToList(), "Id", "RoleName");
                return View(user);
            }

            // Ha minden OK, mentés adatbázisba
            _context.Users.Add(user);
            _context.SaveChanges();

            // Vissza a listához
            return RedirectToAction("Index");
        }
    }
}


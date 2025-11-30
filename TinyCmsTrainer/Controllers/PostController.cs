using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TinyCmsTrainer.Data;
using TinyCmsTrainer.Models;

namespace TinyCmsTrainer.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var posts = _context.Posts
                .Where(p => p.IsPublished)
                .OrderByDescending(p => p.PublishedAt)
                .ToList();

            return View(posts);
        }

        [HttpGet("/blog/{slug}")]
        public IActionResult Details(string slug)
        {
            var post = _context.Posts
                .FirstOrDefault(p => p.Slug == slug && p.IsPublished);

            if (post == null) return NotFound();

            ViewData["Title"] = post.Title;
            return View(post);
        }
    }
}

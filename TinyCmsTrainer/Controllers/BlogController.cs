using Microsoft.AspNetCore.Mvc;
using TinyCmsTrainer.Data;
using Microsoft.EntityFrameworkCore;

namespace TinyCmsTrainer.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Blog
        public async Task<IActionResult> Index()
        {
            var posts = await _context.Posts
                .Where(p => p.IsPublished)
                .OrderByDescending(p => p.PublishedAt)
                .ToListAsync();

            return View(posts);
        }
       
        // GET: /Blog/slug
        public async Task<IActionResult> Details(string slug)
        {
            var post = await _context.Posts
                .FirstOrDefaultAsync(p => p.Slug == slug && p.IsPublished);

            if (post == null)
                return NotFound();

            return View(post);
        }
    }
}

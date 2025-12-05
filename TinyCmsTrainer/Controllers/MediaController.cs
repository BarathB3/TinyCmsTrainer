using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using TinyCmsTrainer.Data;
using TinyCmsTrainer.Models;
using System;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace TinyCmsTrainer.Controllers
{
    public class MediaController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ApplicationDbContext _context;

        public MediaController(IWebHostEnvironment env, ApplicationDbContext context)
        {
            _env = env;
            _context = context;
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");

                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var uniqueName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
                var filePath = Path.Combine(uploadsFolder, uniqueName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                // MediaItem-et kell használni, nem MediaFile-t
                var media = new MediaItem
                {
                    FileName = uniqueName,
                    FilePath = "/uploads/" + uniqueName,
                    UploadedAt = DateTime.Now
                };

                _context.MediaLibrary.Add(media);
                _context.SaveChanges();

                ViewBag.Message = "Sikeres feltöltés!";
            }

            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            var files = _context.MediaLibrary
                .OrderByDescending(f => f.UploadedAt)
                .ToList();

            return View(files);
        }
    }
}

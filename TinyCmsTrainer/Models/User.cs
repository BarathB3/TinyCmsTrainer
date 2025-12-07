using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyCmsTrainer.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Szerepkör")]
        public int RoleId { get; set; }

        // Nullable legyen, hogy ne triggerelje a ModelState hibát
        [ForeignKey("RoleId")]
        public Role? Role { get; set; }

        // Ezeket is opcionálissá tesszük
        public ICollection<Page>? Pages { get; set; } = new List<Page>();
        public ICollection<Post>? Posts { get; set; } = new List<Post>();
        public ICollection<MediaItem>? MediaItems { get; set; } = new List<MediaItem>();
    }
}

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

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        // A következő mezők opcionálissá lettek téve
        public ICollection<Page>? Pages { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public ICollection<MediaItem>? MediaItems { get; set; }
    }
}

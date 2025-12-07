namespace TinyCmsTrainer.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<Page> Pages { get; set; } = new List<Page>();
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<MediaItem> MediaItems { get; set; } = new List<MediaItem>();
    }
}

namespace TinyCmsTrainer.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Excerpt { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? PublishedAt { get; set; }
        public bool IsPublished { get; set; }
        public int? AuthorId { get; set; }
        public User Author { get; set; }
    }
}

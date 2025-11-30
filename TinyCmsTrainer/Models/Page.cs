namespace TinyCmsTrainer.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public int? AuthorId { get; set; }
        public User Author { get; set; }
    }
}

namespace TinyCmsTrainer.Models
{
    public class ScheduledPost
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public DateTime ScheduledFor { get; set; }

        public Post Post { get; set; }
    }
}

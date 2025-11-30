namespace TinyCmsTrainer.Models
{
    public class MediaItem
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }

        public int? UploadedBy { get; set; }
        public User User { get; set; }
    }
}

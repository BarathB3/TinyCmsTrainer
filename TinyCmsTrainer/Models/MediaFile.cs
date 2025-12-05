using System;
using System.ComponentModel.DataAnnotations;

namespace TinyCmsTrainer.Models
{
    public class MediaFile
    {
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string FilePath { get; set; }

        public DateTime UploadedAt { get; set; }

        public int? UploadedBy { get; set; } 
    }
}

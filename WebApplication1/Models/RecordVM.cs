using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class RecordVM
    {
        public int RecordID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public int Longevity { get; set; }
        [Required]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        [Required]
        public string Teacher { get; set; }
        [Required]
        public string Auditorium { get; set; }
    }
}

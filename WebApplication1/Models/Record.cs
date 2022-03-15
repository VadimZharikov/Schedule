using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Record
    {
        [Key]
        public int RecordID { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Time { get; set; }
        [Required]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Teacher { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(3)")]
        public string Auditorium { get; set; }
    }
}

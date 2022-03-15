using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Hours { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public virtual IEnumerable<Record> Records { get; set; }
    }
}

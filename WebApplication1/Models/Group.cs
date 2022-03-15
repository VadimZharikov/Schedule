using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Group
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public virtual IEnumerable<Subject> Subjects { get; set; }
    }
}

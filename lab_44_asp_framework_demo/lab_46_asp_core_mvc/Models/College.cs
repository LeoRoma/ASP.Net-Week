using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_46_asp_core_mvc.Models
{
    public class College
    {
        public College()
        {
            Students = new HashSet<Student>();
        }
        public int CollegeId { get; set; }
        public string CollegeName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities.Instructor
{
    public class CourseModel
    {
        public int coid { get; set; }
        public int uid { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string details { get; set; }
        [Required]
        public double price { get; set; }
        public string thumbnail { get; set; }
    }
}

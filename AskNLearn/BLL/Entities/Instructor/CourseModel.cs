using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
        [Range(0, 9999999.99)]
        public double price { get; set; }
        //[Required]
        public string thumbnail { get; set; }

        //[Required]
        public HttpPostedFile ImageFile { get; set; }
        public Nullable<int> upVote { get; set; }
        public Nullable<int> downVote { get; set; }

    }
}

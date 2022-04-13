using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities.Instructor
{
    public class InstructorModel
    {
        public int uid { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "Name length must not exceed 150")]
        public string name { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public System.DateTime dob { get; set; }
        [Required]
        public string gender { get; set; }
        public string proPic { get; set; }
        public string userType { get; set; }
        public string approval { get; set; }
        //[Required]
        //public string eduInfo { get; set; }
        //[Required]
        //public string currentPosition { get; set; }
        //public int reputation { get; set; }
        //public System.DateTime dateTime { get; set; }
        //[NotMapped]
        //public HttpPostedFileBase ImageFile { get; set; }
    }
}

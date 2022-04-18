using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities.Admin
{
    public class AddUserModel
    {


        public int uid { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public System.DateTime dob { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string userType { get; set; }

        [Required]
        public string eduInfo { get; set; }
        [Required]
        public string currentPosition { get; set; }

    }
}

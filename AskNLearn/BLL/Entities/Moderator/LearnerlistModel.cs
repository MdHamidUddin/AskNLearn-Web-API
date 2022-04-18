using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities.Moderator
{
    public class LearnerlistModel
    {
        public int uid { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public System.DateTime dob { get; set; }
        public string gender { get; set; }
        public string userType { get; set; }
        public string approval { get; set; }
        public System.DateTime dateTime { get; set; }
        public string eduInfo { get; set; }
        public string currentPosition { get; set; }
        public int reputation { get; set; }


    }
}

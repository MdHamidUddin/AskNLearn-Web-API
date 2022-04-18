using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities.Admin
{
    public class UsersListModel
    {
        public int uid { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public System.DateTime dob { get; set; }
        public string gender { get; set; }
        public string userType { get; set; }
        public string proPic { get; set; }
        public string approval { get; set; }
        public System.DateTime dateTime { get; set; }

        public string eduInfo { get; set; }
        public string currentPosition { get; set; }
        public int reputation { get; set; }
    }
}

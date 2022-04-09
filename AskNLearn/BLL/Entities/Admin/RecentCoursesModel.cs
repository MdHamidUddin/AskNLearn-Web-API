using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities.Admin
{
    public class RecentCoursesModel
    {
       
        public int uid { get; set; }
        public int coid { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string title { get; set; }
        public string details { get; set; }
        public double price { get; set; }
        public Nullable<int> upVote { get; set; }
        public Nullable<int> downVote { get; set; }
    }
}

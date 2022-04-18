using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities.Instructor
{
    public class PostModel
    {
        public int pid { get; set; }
        public int uid { get; set; }
        public string PostedBy { get; set; }
        public string title { get; set; }
        public string details { get; set; }
        public Nullable<int> upVote { get; set; }
        public Nullable<int> downVote { get; set; }
        public System.DateTime dateTime { get; set; }
    }
}

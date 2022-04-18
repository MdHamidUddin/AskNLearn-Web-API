using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities.Moderator
{
    class PostCommentModel
    {
        public int pid { get; set; }
        public int uid { get; set; }
        public string title { get; set; }
        public string details { get; set; }
        public Nullable<int> upVote { get; set; }
        public Nullable<int> downVote { get; set; }
        public System.DateTime dateTime { get; set; }

        public int cid { get; set; }
        public string commentValue { get; set; }

    }
}

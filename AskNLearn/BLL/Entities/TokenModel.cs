using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class TokenModel
    {
        public int tid { get; set; }
        public int uid { get; set; }
        public string Token { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> ExpiredAt { get; set; }
    }
}

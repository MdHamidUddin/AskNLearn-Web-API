using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL.Entities.Instructor
{
    public class DocumentModel
    {
        public int did { get; set; }
        public int coid { get; set; }
        public string imageTitle { get; set; }
        public string image { get; set; }
        public HttpPostedFile ImageFile { get; set; }
        public string videoTitle { get; set; }
        public string videoLink { get; set; }
        public string docTitle { get; set; }
        public string docs { get; set; }
        public HttpPostedFile DocFile { get; set; }
    }
}

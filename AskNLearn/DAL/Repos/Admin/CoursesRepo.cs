using DAL.Interface.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DAL.Repos.Admin
{
    public class CoursesRepo : ICourses<Cours, int>
    {
        AskNLearnEntities dbObj;
        public CoursesRepo(AskNLearnEntities dbObj)
        {
            this.dbObj = dbObj;
        }
        public string RecentCourses()
        {
            var data = (from u in dbObj.Users
                        join ui in dbObj.Courses on u.uid equals ui.uid
                        where (u.uid.Equals(ui.uid))
                        select new { u.uid, u.name, u.username, u.email, ui.title, ui.details, ui.coid,ui.price,ui.thumbnail, ui.upVote, ui.downVote }).ToList();

            var data1 = new JavaScriptSerializer().Serialize(data);
            return data1;
        }
    }
}

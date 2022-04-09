using DAL.Interface.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DAL.Repos.Admin
{
    public class PostRepo : IPost<Post, int>
    {
        AskNLearnEntities dbObj;
        public PostRepo(AskNLearnEntities dbObj)
        {
            this.dbObj = dbObj;
        }
        public string Posts()
        {
            var data = (from u in dbObj.Users
                        join ui in dbObj.Posts on u.uid equals ui.uid
                        where (u.uid.Equals(ui.uid))
                        select new { u.uid, u.name, u.username, u.email, ui.title,ui.details,ui.pid,ui.upVote,ui.downVote}).ToList();

            var data1 = new JavaScriptSerializer().Serialize(data);
            return data1;
        }
    }
}

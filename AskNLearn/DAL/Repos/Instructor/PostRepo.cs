using DAL.Interface;
using DAL.Interface.Instructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DAL.Repos.Instructor
{
    public class PostRepo : IPost<Post, int>
    {
        AskNLearnEntities db;
        public PostRepo(AskNLearnEntities db)
        {
            this.db = db;
        }
        public bool Add(Post obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Post obj)
        {
            throw new NotImplementedException();
        }

        public Post Get(int id)
        {
            throw new NotImplementedException();
        }

        public string Get()
        {
            var posts = (from p in db.Posts
                         join u in db.Users on p.uid equals u.uid
                         select new{ 
                             u.name,
                             p.pid,
                             p.title,
                             p.details,
                             p.upVote,
                             p.downVote }).ToList();
            var data = new JavaScriptSerializer().Serialize(posts);
            return data;
        }
    }
}

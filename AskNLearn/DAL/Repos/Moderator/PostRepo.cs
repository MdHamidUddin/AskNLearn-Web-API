using DAL.Interface.Moderator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DAL.Repos.Moderator
{
    public class PostRepo : IModerator<Post, int>
    {
        AskNLearnEntities dbObj;
        public PostRepo(AskNLearnEntities dbObj)
        {
            this.dbObj = dbObj;
        }

        public string AddComment(Post x)
        {
            throw new NotImplementedException();
        }

        public string AddPost(Post x)
        {
            dbObj.Posts.Add(x);
            dbObj.SaveChanges();
            var User = new JavaScriptSerializer().Serialize(x);
            return User;
        }

        public string CourseList()
        {
            throw new NotImplementedException();
        }

        public string DeletePost(int id)
        {
            try
            {
                var data = dbObj.Posts.Find(id);
                var comments = dbObj.Comments.Where(value => value.pid == id).ToList();
                if (comments != null)
                {
                    foreach (var item in comments)
                    {
                        dbObj.Comments.Remove(item);
                        dbObj.SaveChanges();
                    }
                }
                dbObj.Posts.Remove(data);
                dbObj.SaveChanges();

                return "Post Deleted";
            }
            catch (Exception)
            {

                return "There Is A Problem Deleting The Post";
            }
        }

        public string Get(int uid)
        {
            throw new NotImplementedException();
        }

        public string Get()
        {
            throw new NotImplementedException();
        }

        public string InstructorsList()
        {
            throw new NotImplementedException();
        }

        public string LearnersList()
        {
            throw new NotImplementedException();
        }

        public string LearnersList(int id)
        {
            throw new NotImplementedException();
        }

        public string ModeratorsList()
        {
            throw new NotImplementedException();
        }

        public string PostList()
        {
            var data = (from u in dbObj.Users
                        join ui in dbObj.Posts on u.uid equals ui.uid
                        where (u.uid.Equals(ui.uid))
                        select new { u.uid, u.name, u.username, u.email, ui.title, ui.details, ui.pid, ui.upVote, ui.downVote }).ToList();

            var data1 = new JavaScriptSerializer().Serialize(data);
            return data1;
        }


        public string Posts()
        {
            var data = (from u in dbObj.Users
                        join ui in dbObj.Posts on u.uid equals ui.uid
                        where (u.uid.Equals(ui.uid))
                        select new { u.uid, u.name, u.username, u.email, ui.title, ui.details, ui.pid, ui.upVote, ui.downVote }).ToList();

            var data1 = new JavaScriptSerializer().Serialize(data);
            return data1;
        }

        public string UpdateComment(Post x)
        {
            throw new NotImplementedException();
        }

        public string UpdatePost(Post x)
        {
            try
            {
                var data = dbObj.Posts.Find(x.pid);
                data.title = x.title;
                data.details = x.details;
                data.dateTime = DateTime.Now;
                dbObj.Entry(data).State = EntityState.Modified;
                dbObj.SaveChanges();
                return "Post Updated";
            }
            catch (Exception)
            {

                return "There Is A Problem Updating The Post";
            }
        }
    }
}

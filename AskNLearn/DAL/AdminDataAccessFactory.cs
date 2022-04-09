
using DAL.Interface.Admin;
using DAL.Repos;
using DAL.Repos.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class AdminDataAccessFactory
    {
        static AskNLearnEntities dbObj = new AskNLearnEntities();

        public static IAdmin<User, int> GetUser()
        {
            return new UsersRepo(dbObj);
        }
        public static IPost<Post, int> GetRecentPost()
        {
            return new PostRepo(dbObj);
        }

        public static ICourses<Cours, int> GetRecentCourses()
        {
            return new CoursesRepo(dbObj);
        }


    }
}

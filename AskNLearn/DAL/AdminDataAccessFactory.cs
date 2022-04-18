using DAL.Interface.Admin;
using DAL.Interface.IUser;
using DAL.Repos;
using DAL.Repos.Admin;
using DAL.Repos.IUser;
using DAL.Repos.UserRepo;
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

        public static IAddUser<User,int> AddUser()
        {
            return new AddUserRepo(dbObj);
        }

        public static IAddUser<UsersInfo,int> AddUserInfo()
        {
            return new AddUserInfoRepo(dbObj);
        }

        public static IDeleteUser<User>DeleteUser()
        {
            return new Delete(dbObj);
        }

        public static IAdmin<User, int> GetUByType()
        {
            return new UsersRepo(dbObj);
        }


    }
}

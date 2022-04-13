using DAL.Interface;
using DAL.Repos;
using DAL.Repos.Instructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static AskNLearnEntities db = new AskNLearnEntities();
        public static IAuth AuthDataAccess()
        {
            return new AuthRepo(db);
        }
        public static IRepository<Cours, int> CoursDataAccess()
        {
            return new CourseRepo(db);
        }
        public static IRepository<User, int> InstructorDataAccess()
        {
            return new InstructorRepo(db);
        }
    }
}

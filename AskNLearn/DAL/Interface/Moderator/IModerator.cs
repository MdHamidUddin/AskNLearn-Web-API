using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Moderator
{
    public interface IModerator<X, ID>
    {
        string Get(ID uid);
        string Get();
        string ModeratorsList();
        string InstructorsList();
        string LearnersList();
        string LearnersList(ID id);
        string CourseList();
        string PostList();
        string AddPost(X x);
        string UpdatePost(X x);
        string DeletePost(int id);
        string AddComment(X x);
        string UpdateComment(X x);


    }
}

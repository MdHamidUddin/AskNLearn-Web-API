using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IAdmin<X, ID>
    {
        X GetUserById(ID uid);
        string Get(ID uid);
        string Get();
        //List<X> Get();

        X BlockUser( ID id);
        X UnBlockUser(ID id);
        string InstructorsList();
        string ModeratorsList();
        string LearnersList();

        string AdminsList();

        List<X> GetUserByType(string type);


    }
}

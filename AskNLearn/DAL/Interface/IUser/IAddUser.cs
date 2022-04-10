using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.IUser
{
    public interface IAddUser<X>
    {
        string AddUser(X x);
        string UpdateUser(X x);
    }
}

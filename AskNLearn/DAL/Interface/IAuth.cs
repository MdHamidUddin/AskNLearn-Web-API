using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IAuth
    {
        //TokenAccess Authenticate(string username, string password);
        TokenAccess Authenticate(string username, string password);
        bool IsAuthenticated(string token);
        bool Logout(int id);
    }
}

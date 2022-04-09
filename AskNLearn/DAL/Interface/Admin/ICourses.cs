using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Admin
{
    public interface ICourses<X, ID>
    {
        string RecentCourses();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Instructor
{
    public interface IPost<X, ID>
    {
        bool Add(X obj);
        bool Edit(X obj);
        X Get(ID id);
        string Get();
        bool Delete(ID id);
    }
}

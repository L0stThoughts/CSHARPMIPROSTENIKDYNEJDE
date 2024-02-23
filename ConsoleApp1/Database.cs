using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARPMIPROSTENIKDYNEJDE
{
    internal interface Database<T> where T : BaseClass
    {
        T? GetByID(int id);
        IEnumerable<T> GetAll();

        void Save(T element);
        void Delete(T element);
    }
}

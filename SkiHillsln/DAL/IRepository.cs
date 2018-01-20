using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<T>
    {
        void Add(T element);
        void Delete(T element);
        T GetElement(Func<T, bool> func);
        IEnumerable<T> GetElements(Func<T, bool> func);
        void Update(T element);
    }
}

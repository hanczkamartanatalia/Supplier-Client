using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Model
{
    internal interface IObjectService
    {
        public T FindById<T>(int id);
        public void RemoveById(int id);
        public void Add<T>(T obj);

        public List<T> GetAllToList<T>();
    }
}

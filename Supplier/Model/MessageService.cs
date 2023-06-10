using Product_OrderLibrary.DataDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Model
{
    internal class MessageService : IObjectService
    {
        public void Add<T>(T obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (typeof(T) != typeof(Message)) throw new Exception("Invaild type. It should by 'Message'");

            using (Data.ContextSupplier _context = new Data.ContextSupplier())
            {
                
                _context.Add(obj);
                _context.SaveChanges();
            }
        }

        public T FindById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAllToList<T>()
        {
            throw new NotImplementedException();
        }

        public void RemoveById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

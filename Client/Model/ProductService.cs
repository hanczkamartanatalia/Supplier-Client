using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    internal class ProductService: IObjectService
    {

        public void Add<T>(T obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (typeof(T) != typeof(Product_OrderLibrary.DataDB.Product)) throw new Exception("Invaild type. It should by 'Product'");

            using (Data.ContextClient _context = new Data.ContextClient())
            {
                _context.Add(obj);
                _context.SaveChanges();
            }
        }

        public T FindById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

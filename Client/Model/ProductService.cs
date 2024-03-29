﻿using Client.Data;
using Product_OrderLibrary.DataDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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

        public List<T> GetAllToList<T>()
        {
            if (typeof(T) != typeof(Product))
            {
                throw new Exception("Invaild type. It should by 'Product'");         
            }

            ContextClient context = new ContextClient();

            List<Product> products = Product_OrderLibrary.Service.ContextService.Products(() => context, "Products");
            List<T> result = products.Cast<T>().ToList();

            return result;
        }

        public void RemoveById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

using Product_OrderLibrary.DataDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Data
{
    internal class ContextSupplier : Context
    {
        private const string connect = "Server=DELL\\OPTIMA;Database=Supplier;Trusted_Connection=True;Encrypt=False;";
        public ContextSupplier() : base(connect)
        {
        }
    }
}

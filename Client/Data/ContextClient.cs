using Product_OrderLibrary.DataDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Data
{
    internal class ContextClient : Context
    {
        private const string connect = "Server=DELL\\OPTIMA;Database=Client;Trusted_Connection=True;Encrypt=False;";
        public ContextClient() : base(connect)
        {
        }
    }
}

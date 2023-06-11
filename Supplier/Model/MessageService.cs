using Product_OrderLibrary.DataDB;
using Supplier.Data;
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
            if (typeof(T) != typeof(Message))
            {
                throw new Exception("Invaild type. It should by 'Message'");
            }

            ContextSupplier context = new ContextSupplier();

            List<Message> messages = Product_OrderLibrary.Service.ContextService.Messages(() => context, "Message");
            List<T> result = messages.Cast<T>().ToList();

            return result;
        }

        public T GetLast<T>()
        {
            if (typeof(T) != typeof(Message))
            {
                throw new Exception("Invaild type. It should by 'Message'");
            }

            Message result = new Message();

            using (ContextSupplier context = new ContextSupplier())
            {
                List<Message> messages = GetAllToList<Message>();
                int max = 0;
                foreach(Message message in messages)
                {
                    if(message.IdMessage > max)
                    {
                        max = message.IdMessage;
                        result = message;
                    }    
                }
            }

            return (T)(object)result;
        }

        public void RemoveById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

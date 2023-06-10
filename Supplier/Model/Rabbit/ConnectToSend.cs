using QueueRabbitMQ.ConnectionService;
using QueueRabbitMQ.MessageService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Model.Rabbit
{
    internal class ConnectToSend : Connect
    {
        private const string queueName = "SupplierSend";
        private const string hostNameToConnect = "localhost";

        public ConnectToSend() : base(hostNameToConnect, queueName){}

        public void Send<T>(List<T>? list, T? obj)
        {
            if (list == null & obj == null) throw new ArgumentNullException("List and object are null");
            if(obj!= null)
            {
                list = new List<T>();
                list.Add(obj);
            }

            SendService service = new SendService();
            service.SendList(list,hostNameToConnect,queueName);
        }
    }
}

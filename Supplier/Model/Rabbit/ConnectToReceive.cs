using QueueRabbitMQ.ConnectionService;
using QueueRabbitMQ.MessageService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Model.Rabbit
{
    internal class ConnectToReceive : Connect
    {
        private const string queueName = "SupplierReceive";
        private const string hostNameToConnect = "localhost";

        public ConnectToReceive() : base(hostNameToConnect, queueName)
        {
        }

        public List<T> Receive<T>()
        {
            ReceiveService service = new ReceiveService();
            List<T> ts = service.ReceiveList<T>(queueName,hostNameToConnect);
            return ts;
        }

    }
}

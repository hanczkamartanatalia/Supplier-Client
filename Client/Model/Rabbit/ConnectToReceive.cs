using QueueRabbitMQ.ConnectionService;
using QueueRabbitMQ.MessageService;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueueRabbitMQ.ConvertService;
using RabbitMQ.Client.Events;
using System.Threading;

namespace Client.Model.Rabbit
{
    internal class ConnectToReceive : Connect
    {
        private const string queueName = "Client";
        private const string hostNameToConnect = "localhost";

        public ConnectToReceive() : base(hostNameToConnect, queueName)
        {
        }

        public List<T> Receive<T>()
        {
            ReceiveService service = new ReceiveService();
            List<T> ts = service.ReceiveList<T>(hostNameToConnect, queueName);
            return ts;
        }

    }
}

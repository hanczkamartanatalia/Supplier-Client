using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model.Rabbit
{
    internal class ConnectToReceive : QueueRabbitMQ.ConnectionService.Connect
    {
        private const string queueName = "ClientReceive";
        private const string hostNameToConnect = "localhost";

        public ConnectToReceive() : base(hostNameToConnect, queueName)
        {
            this.HostNameToConnect = hostNameToConnect;
            this.QueueName = queueName;
        }
    }
}

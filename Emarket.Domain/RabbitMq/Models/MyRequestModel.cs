using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emarket.Domain.RabbitMq.Models
{
    public class MyRequestModel
    {
        public string HostName { get; set; }
        public string Queue { get; set; }
        public string Message { get; set; }
        public string RoutingKey { get; set; }
    }
}

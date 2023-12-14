using Emarket.Domain.RabbitMq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Application.Services.RabbitMq.Services
{
    public interface IMqService
    {
        bool Send(MyRequestModel request);
        Task<string> GetAsync(string uri, string queue);
    }
}

using EMarket.Application.Services;
using Emarket.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Infrastructure.MediatR.MediatrForSmartphone
{
    public class CreateSmartphone : IRequest<Smartphone>
    {
        public string? Model { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }
    public class CreateSmartphoneHandler : IRequestHandler<CreateSmartphone, Smartphone>
    {
        private readonly ISmartphoneService _smartphoneService;
        public CreateSmartphoneHandler(ISmartphoneService smartphoneService) => _smartphoneService = smartphoneService;
        public async Task<Smartphone> Handle(CreateSmartphone request, CancellationToken cancellationToken)
        {
            Smartphone phone = new Smartphone()
            {
                Count = request.Count,
                Model = request.Model,
                Price = request.Price
            };
            await _smartphoneService.CreateAsync(phone);
            return phone;
        }
    }
}

using Emarket.Domain.Models;
using EMarket.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Application.MediatR
{
    public class SmartphoneCreate : IRequest<ResponseModel<Smartphone>>
    {
        public Smartphone smartphone { get; set; }
    }
    public class SmartphoneCreateHandler : IRequestHandler<SmartphoneCreate, ResponseModel<Smartphone>>
    {
        private readonly ISmartphoneService _smartphoneService;

        public SmartphoneCreateHandler(ISmartphoneService smartphoneService)
        {
            _smartphoneService = smartphoneService;
        }

        public async Task<ResponseModel<Smartphone>> Handle(SmartphoneCreate request, CancellationToken cancellationToken)
        {
            Smartphone phone = await _smartphoneService.CreateAsync(request.smartphone);
            return new(phone);
        }
    }
}

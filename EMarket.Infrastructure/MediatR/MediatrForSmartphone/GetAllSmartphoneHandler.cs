using Emarket.Domain.Models;
using EMarket.Application.Services;
using EMarket.Infrastructure.ConfigureService.ForSmartphone;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Infrastructure.MediatR.MediatrForSmartphone
{
    public class GetAllSmartphone : IRequest<IEnumerable<Smartphone>> { }
    public class GetAllSmartphoneHandler : IRequestHandler<GetAllSmartphone, IEnumerable<Smartphone>>
    {
        private readonly ISmartphoneService _service;
        public GetAllSmartphoneHandler(ISmartphoneService service) => _service = service;
        public Task<IEnumerable<Smartphone>> Handle(GetAllSmartphone request, CancellationToken cancellationToken)
        {
            return _service.GetAllAsync();
        }
    }
}

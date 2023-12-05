using Emarket.Domain.Models;
using EMarket.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Infrastructure.MediatR.MediatrForSmartphone
{
    public class GetByIdSmartphone : IRequest<Smartphone>
    {
        public int Id { get; set; }
    }
    public class GetByIdSmartphoneHandler : IRequestHandler<GetByIdSmartphone, Smartphone>
    {
        private readonly ISmartphoneService _service;
        public GetByIdSmartphoneHandler(ISmartphoneService service) => _service = service;
        public async Task<Smartphone> Handle(GetByIdSmartphone request, CancellationToken cancellationToken)
        {
            var phone = await _service.GetByIdAsync(request.Id);
            return phone;
        }
    }
}

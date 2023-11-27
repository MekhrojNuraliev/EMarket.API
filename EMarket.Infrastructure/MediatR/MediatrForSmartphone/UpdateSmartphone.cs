using Emarket.Domain.Models;
using EMarket.Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Infrastructure.MediatR.MediatrForSmartphone
{
    public class UpdateSmartphone : IRequest<string>
    {
        public int Id { get; set; }
        public string Model { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Count { get; set; }
    }
    public class UpdateSmartphoneHandler : IRequestHandler<UpdateSmartphone, string>
    {
        private readonly ISmartphoneService _service;
        public UpdateSmartphoneHandler(ISmartphoneService smartphoneService)
        {
            _service = smartphoneService;
        }
        public async Task<string> Handle(UpdateSmartphone request, CancellationToken cancellationToken)
        {
            Smartphone smartphone = new Smartphone()
            {
                Id = request.Id,
                Model = request.Model,
                Price = request.Price,
                Count = request.Count
            };
            var isUpdate = await _service.UpdateAsync(smartphone);
            return isUpdate ? "Smartphone has been updated!" : "Smartphone is not updated!";
        }
    }
}

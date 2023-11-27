using EMarket.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EMarket.Infrastructure.MediatR.MediatrForSmartphone
{
    public class DeleteSmartphone : IRequest<string>
    {
        public int Id { get; set; }
    }
    public class DeleteSmartphoneHandler : IRequestHandler<DeleteSmartphone, string>
    {
        private readonly ISmartphoneService _service;
        public DeleteSmartphoneHandler(ISmartphoneService service) => _service = service;
        public async Task<string> Handle(DeleteSmartphone request, CancellationToken cancellationToken)
        {
            var isDelete = await _service.DeleteAsync(request.Id);
            return isDelete ? "Smartphone has been deleted!" : "Smartphone is not deleted!";
        }
    }
}

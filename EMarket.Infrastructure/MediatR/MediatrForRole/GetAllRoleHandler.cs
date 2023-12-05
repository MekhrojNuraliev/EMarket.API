using Emarket.Domain.Entities;
using EMarket.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Infrastructure.MediatR.MediatrForRole
{
    public class GetAllRole : IRequest<IEnumerable<Role>> { }
    public class GetAllRoleHandler : IRequestHandler<GetAllRole, IEnumerable<Role>>
    {
        private readonly IRoleService _service;
        public GetAllRoleHandler(IRoleService service) => _service = service;
        public Task<IEnumerable<Role>> Handle(GetAllRole request, CancellationToken cancellationToken)
        {
            return _service.GetAllAsync();
        }
    }
}

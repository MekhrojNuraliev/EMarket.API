using EMarket.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Infrastructure.MediatR.MediatrForRole
{
    public class DeleteRole : IRequest<string>
    {
        public int Id { get; set; }
    }
    public class DeleteRoleHandler : IRequestHandler<DeleteRole, string>
    {
        private readonly IRoleService _service;
        public DeleteRoleHandler(IRoleService service) => _service = service;
        public async Task<string> Handle(DeleteRole request, CancellationToken cancellationToken)
        {
            var isDelete = await _service.DeleteAsync(request.Id);
            return isDelete ? "Role has been deleted!" : "Role is not deleted!";
        }
    }
}

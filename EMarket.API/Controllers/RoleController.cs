using Emarket.Domain.Models;
using EMarket.Application.Services;
using EMarket.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Emarket.Domain.Entities;
using MediatR;
using EMarket.Infrastructure.MediatR.MediatrForRole;
using EMarket.Infrastructure.MediatR.MediatrForSmartphone;

namespace EMarket.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Role>> Create(CreateRole role)
        {
            var res = await _mediator.Send(role);
            return Ok(res);
        }
        [HttpPut]
        public async Task<ActionResult<Role>> Update(UpdateRole role)
        {
            var res = await _mediator.Send(role);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<ActionResult<string>> Delete(DeleteRole role)
        {
            var res = await _mediator.Send(role);
            return Ok(res);
        }
        [HttpGet]
        public async Task<ActionResult<Role>> GetAll()
        {
            var res = await _mediator.Send(new GetAllRole());
            return Ok(res);
        }
        [HttpGet]
        public async Task<ActionResult<Role>> GetById(int id)
        {
            var res = await _mediator.Send(new GetByIdRole { Id = id });
            return Ok(res);
        }
    }
}

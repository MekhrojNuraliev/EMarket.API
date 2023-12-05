using Emarket.Domain.Entities;
using Emarket.Domain.Models;
using EMarket.Application.Services;
using EMarket.Infrastructure.MediatR.MediatrForAuth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMarket.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IMediator _mediatr;

        public UserController(IIdentityService identityService, IMediator mediatr)
        {
            _identityService = identityService;
            _mediatr = mediatr;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<GetUserModel>> Register(RegisterUser user)
        {
            var res = await _mediatr.Send(user);
            return Ok(res);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<Response<Token>> Login(Credential credentials)
            => await _identityService.LoginAsync(credentials);

        [HttpGet]
        public async Task<Response<bool>> LogOut()
            => await _identityService.LogoutAsync();
        [HttpPost]
        [AllowAnonymous]
        public async Task<Response<Token>> RefreshToken(Token tokens)
            => await _identityService.RefreshTokenAsync(tokens);

        [HttpDelete]
        public async Task<Response<bool>> Delete(int userId)
            => await _identityService.DeleteUserAsync(userId);

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public string[] GetAllStudent()
        {
            return new string[] { "ssss", "wwwww" };
        }
    }
}

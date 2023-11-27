using Emarket.Domain.Entities;
using Emarket.Domain.Models;
using EMarket.Application.Services;
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

        public UserController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<Response<GetUserModel>> Register(User user) 
            =>  await _identityService.RegisterAsync(user);

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
        [Authorize(Roles = "Teacher")]
        public string[] GetAllStudent()
        {
            return new string[] { "ssss", "wwwww" };
        }
    }
}

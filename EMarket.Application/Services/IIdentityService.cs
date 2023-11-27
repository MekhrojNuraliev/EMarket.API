using Emarket.Domain.Entities;
using Emarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Application.Services
{
    public interface IIdentityService
    {
        Task<Response<GetUserModel>> RegisterAsync(User user);
        Task<Response<Token>> LoginAsync(Credential credential);
        Task<Response<bool>> LogoutAsync();
        Task<Response<Token>> RefreshTokenAsync(Token token);
        Task<Response<bool>> DeleteUserAsync(int UserId);
        Task<bool> SaveRefreshTokenAsync(string refreshToken, User user);
        Task<bool> IsValidRefreshTokenAsync(string refreshToken, int userId);
    }
}

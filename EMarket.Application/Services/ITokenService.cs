using Emarket.Domain.Entities;
using Emarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Application.Services
{
    public interface ITokenService
    {
        Task<Token> GenerateTokenAsync(User user);
        Task<User> GetClaimsFromExpiredTokenAsync(string accessToken);
        Task<string> GenerateRefreshTokensAsync();
        Task<Token> GetNewTokenFromExpiredTokensAsync(Token tokens);
        string ComputeSHA256Hash(string sha256Hash);
    }
}

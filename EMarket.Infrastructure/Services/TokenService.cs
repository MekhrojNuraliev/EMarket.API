using Emarket.Domain.Entities;
using Emarket.Domain.Models;
using EMarket.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateRefreshTokensAsync()
        {
            return ComputeSHA256Hash(DateTime.Now.ToString() + "myKey");
        }

        public async Task<Token> GenerateTokenAsync(User user)
        {
            var roles = user.Roles;
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Name),
                new Claim("Id", user.Id.ToString())
        };
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
                //foreach (var permission in role.Permissions)
                //{
                //    claims.Add(new Claim(ClaimTypes.Role, permission.Name));
                //}
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            double accessTokenLifetime = double.Parse(_configuration["JWT:AccessTokenLifetimeInMinutes"]);

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(accessTokenLifetime),
                signingCredentials: credentials,
                claims: claims);

            string accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new() 
            {
                AccessToken = accessToken,
                RefreshToken = await GenerateRefreshTokensAsync()
            };
        }

        public async Task<User> GetClaimsFromExpiredTokenAsync(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();

            var jsonToken = handler.ReadToken(accessToken);
            
            var claims = (jsonToken as JwtSecurityToken)?.Claims;

            var userClaims = claims?.ToArray();

            return new()
            {
                Id = int.Parse(userClaims.First(x => x.Type.Equals("Id")).Value),
                Name = userClaims.First(X => X.Type.Equals(ClaimTypes.NameIdentifier)).Value
            };
        }

        public Task<Token> GetNewTokenFromExpiredTokensAsync(Token tokens)
        {
            throw new NotImplementedException();
        }
        public string ComputeSHA256Hash(string sha256Hash)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(sha256Hash);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);

            StringBuilder builder = new();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}

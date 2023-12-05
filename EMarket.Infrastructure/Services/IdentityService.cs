using Emarket.Domain.Entities;
using Emarket.Domain.Models;
using EMarket.Application.Services;
using EMarket.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Role = Emarket.Domain.Entities.Role;

namespace EMarket.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly ITokenService _tokenService;
        private readonly LoginDbContext _dbContext;
        private readonly int _refreshTokenLifetime;

        public IdentityService(ITokenService tokenService, LoginDbContext dbContext, IConfiguration configuration)
        {
            _tokenService = tokenService;
            _dbContext = dbContext;
            _refreshTokenLifetime = int.Parse(configuration["JWT:RefreshTokenLifetimeInMinutes"]);
        }

        public Task<Response<bool>> DeleteUserAsync(int UserId)
        {
            throw new NotImplementedException();
        }


        public async Task<Response<Token>> LoginAsync(Credential credential)
        {
            credential.Password = _tokenService.ComputeSHA256Hash(credential.Password);
            User? user = _dbContext.Users.Include(x => x.Roles)
                                         .ThenInclude(x => x.Permissions)
                                         .FirstOrDefault(x => x.UserName
                                         .Equals(credential.UserName) &&
                                         x.Password.Equals(credential.Password));
            if (user == null)
                return new("User not found!");

            Token userToken = await _tokenService.GenerateTokenAsync(user);

            bool isSuccess = await SaveRefreshTokenAsync(userToken.RefreshToken, user);

            return isSuccess ? new(userToken) : new("Failed to save refresh token");
        }

        public async Task<Response<bool>> LogoutAsync()
        {
            return new(true);
        }

        public async Task<Response<Token>> RefreshTokenAsync(Token token)
        {
            User user = await _tokenService.GetClaimsFromExpiredTokenAsync(token.AccessToken);

            if (!await IsValidRefreshTokenAsync(token.RefreshToken, user.Id))
                return new("Refresh token invalid!");

            Token newToken = await _tokenService.GenerateTokenAsync(user);
            bool isSuccess = await SaveRefreshTokenAsync(newToken.RefreshToken, user);
            return isSuccess ? new(newToken) : new("Failed");
        }

        public async Task<Response<GetUserModel>> RegisterAsync(User user)
        {
            user.Password = _tokenService.ComputeSHA256Hash(user.Password);
            await _dbContext.Users.AddAsync(user);

            int effectedRows = await _dbContext.SaveChangesAsync();

            user.Roles.Add(new Role()
            {
                Id = 2,
                Name = "Member"
            });
            _dbContext.Users.Update(user);
            var dto = _dbContext.Users.Where(x => x.Id == user.Id).Include(x => x.Roles)
                                         .Select(x=>x).FirstOrDefault();
            await _dbContext.SaveChangesAsync();
            if (effectedRows <= 0)
                return new("Operation failed");
                        
            Token token = await _tokenService.GenerateTokenAsync(dto);
            bool isSuccess =  await SaveRefreshTokenAsync(token.RefreshToken, user);
            GetUserModel getUserModel = new()
            {
                tokens = token,
                user = dto
            };
            return isSuccess? new(getUserModel) : new("Failed");
        }
        public async Task<bool> IsValidRefreshTokenAsync(string refreshToken, int userId)
        {
            RefreshToken? refreshTokenEntity;
            var res = _dbContext.RefreshTokens.Where(x => x.UserId.Equals(userId) &&
                                                          x.RefreshTokenValue.Equals(refreshToken));
            if (res.Count() != 1)
                return false;
            refreshTokenEntity = res.First();
            if(refreshTokenEntity.ExpireTime < DateTime.Now)
                return false;

            return true;
        }

        public async Task<bool> SaveRefreshTokenAsync(string refreshToken, User user)
        {
            if (string.IsNullOrEmpty(refreshToken))
                return false;

            RefreshToken? refreshTokenEntity;
            var res = _dbContext.RefreshTokens.Where(x => x.UserId.Equals(user.Id));
                                                              //x.RefreshTokenValue.Equals(refreshToken));
            if(res.Count() == 0)
            {
                refreshTokenEntity = new()
                {
                    ExpireTime = DateTime.Now.AddMinutes(_refreshTokenLifetime),
                    RefreshTokenValue = refreshToken,
                    UserId = user.Id,
                };
                await _dbContext.RefreshTokens.AddAsync(refreshTokenEntity);
            }
            else if (res.Count() == 1)
            {
                refreshTokenEntity = res.First();
                refreshTokenEntity.RefreshTokenValue = refreshToken;
                refreshTokenEntity.ExpireTime = DateTime.Now.AddMinutes(_refreshTokenLifetime);

                _dbContext.RefreshTokens.Update(refreshTokenEntity);
            }
            else 
                return false;
           
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}

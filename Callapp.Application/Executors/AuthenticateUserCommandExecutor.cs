using Callapp.Application.Commands;
using Callapp.Application.Dtos;
using Callapp.Domain.Aggregates;
using Callapp.Infrastructure.Migrations;
using Callapp.Infrastructure.Persistence;
using Callapp.Shared;
using Callapp.Shared.Results;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Callapp.Application.Executors
{
    public class AuthenticateUserCommandExecutor : Executor, IRequestHandler<AuthenticateUserCommand, Result>
    {

        private CallappDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthenticateUserCommandExecutor(CallappDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<Result> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == request.LoginUser.Email && x.Password == request.LoginUser.Password);

            if(user is not null)
            {

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var token = GetToken(authClaims);

                return Succeeded(new
                {
                    userId = user.Id,
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return Failed("Unauthorized");
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddHours(4).AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}

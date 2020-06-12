using Contoso.Store.Domain.Contexts.Queries.Security;
using Contoso.Store.Shared.Abstractions;
using Contoso.Store.Shared.Implementations;
using Contoso.Store.Shared.Security;
using FluentValidator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Contoso.Store.Application.Handlers.Login
{
    public class LoginQueryHandler
        : Notifiable,
        IQueryHandler<LoginQuery>
    {
        private readonly SigningConfigurations _signingConfigurations;
        private readonly JwtSettings _jwtSettings;

        public LoginQueryHandler(
            [FromServices] SigningConfigurations signingConfigurations,
            IOptions<JwtSettings> jwtSettings)
        {
            _signingConfigurations = signingConfigurations;
            _jwtSettings = jwtSettings.Value;
        }

        public IResult Handle(LoginQuery query)
        {
            if (string.IsNullOrEmpty(query.User) || string.IsNullOrEmpty(query.Password))
                AddNotification("User or Password", "User ou password está vazio");

            if (Invalid)
            {
                return new ApiContract(false,
                    "Erro, corrija os seguintes problemas:",
                    Notifications);
            }

            var claims = new List<Claim>();

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, query.User));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.ValidAt,
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.Expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var data = new
            {
                authenticated = true,
                created = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = tokenDescriptor.Expires.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor))
            };

            return new ApiContract(true, "Token gerado com sucesso", data);
        }
    }
}

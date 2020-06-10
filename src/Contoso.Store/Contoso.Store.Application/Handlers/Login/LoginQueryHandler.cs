using Contoso.Store.Domain.Contexts.Queries.Security;
using Contoso.Store.Shared.Abstractions;
using Contoso.Store.Shared.Implementations;
using Contoso.Store.Shared.Security;
using FluentValidator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace Contoso.Store.Application.Handlers.Login
{
    public class LoginQueryHandler
        : Notifiable,
        IQueryHandler<LoginQuery>
    {

        //Essas configs podem ser configuradas em settings do projeto
        private readonly string tokenIssuer = "localhost";
        private readonly string tokenAudience = "localhost";
        private readonly SigningConfigurations _signingConfigurations;
        public LoginQueryHandler([FromServices] SigningConfigurations signingConfigurations)
        {
            _signingConfigurations = signingConfigurations;
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

            //to-do: implementar sua lógica de busca aqui e enviar para o token criar
            //substituir o guid e login, se for o caso da sua lógica
            var token = GenerateToken(Guid.NewGuid(), "login", query.User, query.Password);

            return new ApiContract(true, string.Empty, token);
        }
        private object GenerateToken(Guid userId, string login, string userName, string email)
        {

            //TO-DO: Autenticar usuario, aqui estamos apenas retornando true
            var userExists = true;

            if (userExists)
            {
                var identity = new ClaimsIdentity(
                    new GenericIdentity(login, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, userId.ToString()),
                        new Claim("Email", email),
                        new Claim("NameUser", userName)
                    });

                var dateCreated = DateTime.Now;
                var dateExpiration = dateCreated.AddDays(1);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenIssuer,
                    Audience = tokenAudience,
                    SigningCredentials = _signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dateCreated,
                    Expires = dateExpiration
                });

                return new
                {
                    authenticated = true,
                    created = dateCreated.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dateExpiration.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = handler.WriteToken(securityToken),
                    message = "OK"
                };
            }

            return new
            {
                authenticated = false,
                message = "User does not exists!"
            };
        }

    }
}

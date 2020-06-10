using Contoso.Store.Application.Handlers.CustomerHandlers;
using Contoso.Store.Application.Handlers.Login;
using Microsoft.Extensions.DependencyInjection;

namespace Contoso.Store.Infrastructure.IoC.Application
{
    internal class ApplicationBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddTransient<CustomerCommandHandler, CustomerCommandHandler>();
            services.AddTransient<CustomerQueryHandler, CustomerQueryHandler>();
            services.AddTransient<LoginQueryHandler, LoginQueryHandler>();
        }
    }
}

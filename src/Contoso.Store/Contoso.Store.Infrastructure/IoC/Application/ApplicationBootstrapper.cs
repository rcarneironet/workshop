using Contoso.Store.Application.Handlers.CustomerHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace Contoso.Store.Infrastructure.IoC.Application
{
    internal class ApplicationBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddTransient<CustomerCommandHandler, CustomerCommandHandler>();
            services.AddTransient<CustomerQueryHandler, CustomerQueryHandler>();
        }
    }
}

using Contoso.Store.Application.Handlers.CustomerHandler;
using Microsoft.Extensions.DependencyInjection;

namespace Contoso.Store.Infrastructure.IoC.Application
{
    internal class ApplicationBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddTransient<CustomerHandler, CustomerHandler>();
        }
    }
}

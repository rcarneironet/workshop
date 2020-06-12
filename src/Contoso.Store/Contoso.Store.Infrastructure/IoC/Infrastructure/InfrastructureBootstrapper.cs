using Contoso.Store.Shared.Security;
using Microsoft.Extensions.DependencyInjection;

namespace Contoso.Store.Infrastructure.IoC.Infrastructure
{
    internal class InfrastructureBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddSingleton(new SigningConfigurations());
        }
    }
}

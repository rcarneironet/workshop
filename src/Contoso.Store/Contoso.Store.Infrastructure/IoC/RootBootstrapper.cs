using Contoso.Store.Infrastructure.IoC.Application;
using Contoso.Store.Infrastructure.IoC.Infrastructure;
using Contoso.Store.Infrastructure.IoC.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Contoso.Store.Infrastructure.IoC
{
    public class RootBootstrapper
    {
        public void BootStrapperRegisterServices(IServiceCollection services)
        {
            new ApplicationBootstrapper().ChildServiceRegister(services);

            new RepositoryBootstrapper().ChildServiceRegister(services);
            new MongoDbRepositoryBootstrapper().ChildServiceRegister(services);

            new InfrastructureBootstrapper().ChildServiceRegister(services);
        }
    }
}

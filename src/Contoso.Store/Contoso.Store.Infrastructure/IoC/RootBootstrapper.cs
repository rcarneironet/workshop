using Contoso.Store.Infrastructure.IoC.Application;
using Contoso.Store.Infrastructure.IoC.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Contoso.Store.Infrastructure.IoC
{
    public class RootBootstrapper
    {
        public void BootStrapperRegisterServices(IServiceCollection services)
        {
            //Servicos de Application            
            new ApplicationBootstrapper().ChildServiceRegister(services);
            
            //Servicos de Domain

            //Servicos de Repositorio
            new RepositoryBootstrapper().ChildServiceRegister(services);
        }
    }
}

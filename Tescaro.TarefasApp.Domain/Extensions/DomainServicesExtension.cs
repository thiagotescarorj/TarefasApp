using Microsoft.Extensions.DependencyInjection;
using Tescaro.TarefasApp.Domain.Interfaces.Services;
using Tescaro.TarefasApp.Domain.Services;
namespace Tescaro.TarefasApp.Domain.Extensions
{
    // <summary>
    /// Classe de extensão para configurar os serviços da camada de domínio do sistema
    /// </summary>

    public static class DomainServiceExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {         

            //registrando as interfaces/classe de serviço do domínio
            services.AddTransient<ITarefaDomainService, TarefaDomainService>();

            return services;
        }
    }
}

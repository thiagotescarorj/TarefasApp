using Microsoft.Extensions.DependencyInjection;
using Tescaro.TarefasApp.Application.Data;
using Tescaro.TarefasApp.Application.Interfaces;
using Tescaro.TarefasApp.Application.Services;

namespace Tescaro.TarefasApp.Application.Extensions
{
    /// <summary>
    /// Classe de extensão para configurar os serviços da camada de aplicação do sistema
    /// </summary>

    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            //Configuração do MediatR
            services.AddMediatR(x => 
            {
                x.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());            
            });

            //registrando a classe FakeDataStore
            services.AddSingleton<FakeDataStore>();

            //registrando as interfaces/classe de serviço da aplicação
            services.AddTransient<ITarefaAppService, TarefaAppService>();

            return services;
        }
    }
}

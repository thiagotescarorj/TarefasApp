using Microsoft.Extensions.DependencyInjection;
using Tescaro.TarefasApp.Application.Interfaces;
using Tescaro.TarefasApp.Application.Services;

namespace Tescaro.TarefasApp.Application.Extensions
{
    /// <summary>
    /// Classe de extensão para configurar os serviços da camada de aplicação do sistema
    /// </summary>


    /// <summary>
    /// Classe de extensão para configurar os serviços
    /// da camada de aplicação do sistema
    /// </summary>
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //configurando o MediatR
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            //configurando o AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //registrando as interfaces/classes de serviço da aplicação
            services.AddTransient<ITarefaAppService, TarefaAppService>();

            return services;
        }
    }

}


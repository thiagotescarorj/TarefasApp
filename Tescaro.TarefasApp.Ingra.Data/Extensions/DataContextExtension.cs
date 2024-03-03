using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tescaro.TarefasApp.Domain.Interfaces.Repositories;
using Tescaro.TarefasApp.Infra.Data.Context;
using Tescaro.TarefasApp.Infra.Data.Repositories;

namespace Tescaro.TarefasApp.Infra.Data.Extensions
{
    /// <summary>
    /// Classe de extensão para configurar as dependencias da infra de banco de dados
    /// </summary>
    public static class DataContextExtension
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            //injeção de dependência do DataContext
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("BDTarefasApp")));

            //injeção de dependência do UnitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }

}

using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Tescaro.TarefasApp.API.Extentions
{
    /// <summary>
    /// Classe de extenção para configuração do Swagger (OPEN API)
    /// </summary>
    public static class SwaggerDocExtension
    {
        /// <summary>
        /// Método de extensão para configurar as preferências do Swagger
        /// </summary>
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TarefasApp - Tescaro",
                    Description = "API para controle de tarefas de usuários.",
                    Version = "1.0"

                });

                //configuração para incluir os comentários na documentação
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);


            });

            return services;
        }

        /// <summary>
        /// Métodos para confgigurar a execução do Swagger
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSwaggerDoc(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "TarefasApp");
            });

            return app;


        }

    }
}

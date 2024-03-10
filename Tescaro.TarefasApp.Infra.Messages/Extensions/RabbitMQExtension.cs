﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.TarefasApp.Infra.Messages.Consumers;
using Tescaro.TarefasApp.Infra.Messages.Producers;
using Tescaro.TarefasApp.Infra.Messages.Services;
using Tescaro.TarefasApp.Infra.Messages.Settings;

namespace Tescaro.TarefasApp.Infra.Messages.Extensions
{
    public static class RabbitMQExtension
    {
        public static IServiceCollection AddRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            #region Definições para acesso ao RabbitMQ

            var rabbitMQSettings = new RabbitMQSettings();

            //ler as configurações do /appsettings.json
            new ConfigureFromConfigurationOptions<RabbitMQSettings>
                (configuration.GetSection("RabbitMQ")).Configure(rabbitMQSettings);

            services.AddSingleton(rabbitMQSettings);

            #endregion

            #region Definições para acesso ao servidor de emails

            var emailSettings = new EmailSettings();

            //ler as configurações do /appsettings.json
            new ConfigureFromConfigurationOptions<EmailSettings>
                (configuration.GetSection("Mail")).Configure(emailSettings);

            services.AddSingleton(emailSettings);

            #endregion

            services.AddTransient<MessageProducer>();
            services.AddTransient<EmailService>();
            services.AddHostedService<MessageConsumer>();


            return services;
        }
    }


}

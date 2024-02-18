using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.TarefasApp.Application.DTOs;
using Tescaro.TarefasApp.Application.Enumerators;

namespace Tescaro.TarefasApp.Application.Handlers.Notifications
{
    /// <summary>
    /// Modelo de dados para gerar a notificação
    /// </summary>
    public class TarefaNotification:INotification
    {
        public TarefaDTO? Tarefa { get; set; }
        public TarefaNotificationAction Action { get; set; }
    }

    

}

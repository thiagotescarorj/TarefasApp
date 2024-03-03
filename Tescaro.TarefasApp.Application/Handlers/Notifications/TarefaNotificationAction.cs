using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.TarefasApp.Application.Data;
using Tescaro.TarefasApp.Application.Enumerators;
using Tescaro.TarefasApp.Infra.Storage.Collections;
using Tescaro.TarefasApp.Infra.Storage.Persistence;

namespace Tescaro.TarefasApp.Application.Handlers.Notifications
{
    /// <summary>
    /// Classe para escutar as notificações de tarefas
    /// </summary>
    public class TarefaNotificationHandler:INotificationHandler<TarefaNotification>
    {
        //atributo
        private readonly TarefaPersistence _tarefaPersistence;
        private readonly IMapper _mapper;

        public TarefaNotificationHandler(TarefaPersistence tarefaPersistence, IMapper mapper)
        {
            _tarefaPersistence = tarefaPersistence;
            _mapper = mapper;
        }

        public async Task Handle(TarefaNotification notification, CancellationToken cancellationToken)
        {
            switch (notification.Action)
            {
                case TarefaNotificationAction.TarefaCriada:
                    _tarefaPersistence.Insert(_mapper.Map<TarefaCollection>(notification.Tarefa));
                    break;

                case TarefaNotificationAction.TarefaAlterada:
                    _tarefaPersistence.Update(_mapper.Map<TarefaCollection>(notification.Tarefa));
                    break;

                case TarefaNotificationAction.TarefaExcluida:
                    _tarefaPersistence.Delete(_mapper.Map<TarefaCollection>(notification.Tarefa));
                    break;
            }

            await Task.CompletedTask;
        }
    }
}

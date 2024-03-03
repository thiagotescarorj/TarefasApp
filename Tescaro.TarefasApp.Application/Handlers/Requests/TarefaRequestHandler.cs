﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.TarefasApp.Application.Commands;
using Tescaro.TarefasApp.Application.DTOs;
using Tescaro.TarefasApp.Application.Enumerators;
using Tescaro.TarefasApp.Application.Handlers.Notifications;
using Tescaro.TarefasApp.Domain.Entities;
using Tescaro.TarefasApp.Domain.Interfaces.Services;

namespace Tescaro.TarefasApp.Application.Handlers.Requests
{
    /// <summary>
    /// Classe para receber as requisições COMMANDS (CREATE, UPDATE e DELETE)
    /// </summary>
    public class TarefaRequestHandler:
        IRequestHandler<TarefaCreateCommand, TarefaDTO>,
        IRequestHandler<TarefaUpdateCommand, TarefaDTO>,
        IRequestHandler<TarefaDeleteCommand, TarefaDTO>
    {
        //atributo
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ITarefaDomainService _tarefaDomainService;

        //construtor para injeção de dependência
        public TarefaRequestHandler(IMediator mediator, IMapper mapper, ITarefaDomainService tarefaDomainService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _tarefaDomainService = tarefaDomainService;
        }

        public async Task<TarefaDTO> Handle(TarefaCreateCommand request, CancellationToken cancellationToken)
        {
            //Gravar os dados no domínio
            var tarefa = _mapper.Map<Tarefa>(request);
            await _tarefaDomainService.Add(tarefa);

            //Gerar uma notificação para que os dados
            //sejam replicados em um banco de consulta
            var tarefaDTO = _mapper.Map<TarefaDTO>(tarefa);
            var tarefaNotification = new TarefaNotification
            {
                Tarefa = tarefaDTO,
                Action = TarefaNotificationAction.TarefaCriada
            };

            await _mediator.Publish(tarefaNotification);
            return tarefaDTO;
        }

        public async Task<TarefaDTO> Handle(TarefaUpdateCommand request, CancellationToken cancellationToken)
        {
            //Atualizar os dados no domínio
            var tarefa = _mapper.Map<Tarefa>(request);
            await _tarefaDomainService.Update(tarefa);

            //Gerar uma notificação para que os dados
            //sejam replicados em um banco de consulta
            var tarefaDTO = _mapper.Map<TarefaDTO>(tarefa);
            var tarefaNotification = new TarefaNotification
            {
                Tarefa = tarefaDTO,
                Action = TarefaNotificationAction.TarefaAlterada
            };

            await _mediator.Publish(tarefaNotification);
            return tarefaDTO;
        }

        public async Task<TarefaDTO> Handle(TarefaDeleteCommand request, CancellationToken cancellationToken)
        {
            //Excluir os dados no domínio
            var tarefa = await _tarefaDomainService.GetById(request.Id.Value);
            await _tarefaDomainService.Delete(tarefa);

            //Gerar uma notificação para que os dados
            //sejam replicados em um banco de consulta
            var tarefaDTO = _mapper.Map<TarefaDTO>(tarefa);
            var tarefaNotification = new TarefaNotification
            {
                Tarefa = tarefaDTO,
                Action = TarefaNotificationAction.TarefaExcluida
            };

            await _mediator.Publish(tarefaNotification);
            return tarefaDTO;
        }
    }


}


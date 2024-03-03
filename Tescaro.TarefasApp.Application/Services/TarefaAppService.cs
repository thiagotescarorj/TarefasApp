using AutoMapper;
using MediatR;
using Tescaro.TarefasApp.Application.Commands;
using Tescaro.TarefasApp.Application.DTOs;
using Tescaro.TarefasApp.Application.Interfaces;
using Tescaro.TarefasApp.Infra.Storage.Persistence;

namespace Tescaro.TarefasApp.Application.Services
{
    /// <summary>
    /// Implementação dos serviços de tarefa da aplicação
    /// </summary>
    public class TarefaAppService:ITarefaAppService
    {
        //atributo
        private readonly TarefaPersistence _tarefaPersistence;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TarefaAppService(TarefaPersistence tarefaPersistence, IMediator mediator, IMapper mapper)
        {
            _tarefaPersistence = tarefaPersistence;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<TarefaDTO> Create(TarefaCreateCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<TarefaDTO> Update(TarefaUpdateCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<TarefaDTO> Delete(TarefaDeleteCommand command)
        {
            return await _mediator.Send(command);
        }

        public List<TarefaDTO>? GetAll()
        {
            var result = _tarefaPersistence.FindAll().Result;
            return _mapper.Map<List<TarefaDTO>>(result);
        }

        public TarefaDTO? GetById(Guid id)
        {
            var result = _tarefaPersistence.Find(id).Result;
            return _mapper.Map<TarefaDTO>(result);
        }
    }


}
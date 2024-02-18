using MediatR;
using Tescaro.TarefasApp.Application.Commands;
using Tescaro.TarefasApp.Application.Data;
using Tescaro.TarefasApp.Application.DTOs;
using Tescaro.TarefasApp.Application.Interfaces;

namespace Tescaro.TarefasApp.Application.Services
{
    /// <summary>
    /// Implementação do Serviço de Tarefa
    /// </summary>
    public class TarefaAppService:ITarefaAppService
    {
        private readonly IMediator _mediator;
        private readonly FakeDataStore _fakeDataStore;

        public TarefaAppService(IMediator mediator, FakeDataStore fakeDataStore)
        {
            _mediator = mediator;
            _fakeDataStore = fakeDataStore;
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
            return _fakeDataStore.GetAll();
        }

        public TarefaDTO? GetById(Guid id)
        {
            return _fakeDataStore.GetById(id);
        }

    }

}
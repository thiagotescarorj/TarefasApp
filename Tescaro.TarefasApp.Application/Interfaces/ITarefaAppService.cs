using Tescaro.TarefasApp.Application.Commands;
using Tescaro.TarefasApp.Application.DTOs;

namespace Tescaro.TarefasApp.Application.Interfaces
{
    /// <summary>
    /// Contrato dos métodos de serviço da aplicação
    /// </summary>
    public interface ITarefaAppService
    {
        Task<TarefaDTO> Create(TarefaCreateCommand command);
        Task<TarefaDTO> Update(TarefaUpdateCommand command);
        Task<TarefaDTO> Delete(TarefaDeleteCommand command);

        List<TarefaDTO>? GetAll();
        TarefaDTO? GetById(Guid id);

    }
}

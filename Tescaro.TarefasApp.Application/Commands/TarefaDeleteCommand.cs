using MediatR;
using Tescaro.TarefasApp.Application.DTOs;

namespace Tescaro.TarefasApp.Application.Commands
{
    public class TarefaDeleteCommand:IRequest<TarefaDTO>
    {
        public Guid? Id { get; set; }

    }
}

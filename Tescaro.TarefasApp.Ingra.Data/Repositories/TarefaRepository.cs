using Tescaro.TarefasApp.Domain.Entities;
using Tescaro.TarefasApp.Domain.Interfaces.Repositories;
using Tescaro.TarefasApp.Infra.Data.Context;

namespace Tescaro.TarefasApp.Infra.Data.Repositories
{
    /// <summary>
    /// Implementação do repositório de tarefas
    /// </summary>
    public class TarefaRepository:BaseRepository<Tarefa, Guid>, ITarefaRepository
    {
        private readonly DataContext? _dataContext;

        public TarefaRepository(DataContext? dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }

}

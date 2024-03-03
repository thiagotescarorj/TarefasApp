using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.TarefasApp.Domain.Entities;

namespace Tescaro.TarefasApp.Domain.Interfaces.Repositories
{
    public interface ITarefaRepository:IBaseRepository<Tarefa, Guid?>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.TarefasApp.Domain.Interfaces.Repositories;
using Tescaro.TarefasApp.Infra.Data.Context;

namespace Tescaro.TarefasApp.Infra.Data.Repositories
{
    /// <summary>
    /// Implementação da unidade de trabalho dos repositórios
    /// </summary>
    public class UnitOfWork:IUnitOfWork
    {
        private readonly DataContext? _dataContext;

        public UnitOfWork(DataContext? dataContext)
            => _dataContext = dataContext;

        public ITarefaRepository? TarefaRepository => new TarefaRepository(_dataContext);

        public async Task SaveChanges()
        {
            await _dataContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }

}

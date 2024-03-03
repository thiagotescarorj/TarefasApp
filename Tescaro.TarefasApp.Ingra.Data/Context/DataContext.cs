using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.TarefasApp.Infra.Data.Mappings;

namespace Tescaro.TarefasApp.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        /// <summary>
        /// Construtor para injeção de dependência
        /// </summary>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaMap());
        }

    }
}

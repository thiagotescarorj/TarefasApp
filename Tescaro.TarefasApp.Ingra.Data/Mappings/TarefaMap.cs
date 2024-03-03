﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.TarefasApp.Domain.Entities;

namespace Tescaro.TarefasApp.Infra.Data.Mappings
{
    public class TarefaMap:IEntityTypeConfiguration<Tarefa>
    {
        /// <summary>
        /// Classe de mapeamento ORM para a entidade tarefa
        /// </summary>

        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            //nome da tabela
            builder.ToTable("TAREFA");

            //chave primária
            builder.HasKey(t => t.Id);

            //mapeamento dos campos
            builder.Property(t => t.Id).HasColumnName("ID");
            builder.Property(t => t.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
            builder.Property(t => t.DataHora).HasColumnName("DATAHORA").IsRequired();
            builder.Property(t => t.Descricao).HasColumnName("DESCRICAO").HasMaxLength(250).IsRequired();
            builder.Property(t => t.Prioridade).HasColumnName("PRIORIDADE").IsRequired();
        }
    }

}

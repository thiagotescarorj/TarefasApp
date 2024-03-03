﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tescaro.TarefasApp.Infra.Storage.Collections
{
    /// <summary>
    /// Modelo de dados da collection do MongoDB
    /// </summary>

    public class TarefaCollection
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataHora { get; set; }
        public string? Descricao { get; set; }
        public int? Prioridade { get; set; }
        public DateTime? DataHoraCadastro { get; set; }

    }
}

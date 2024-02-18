﻿using Tescaro.TarefasApp.Application.DTOs;

namespace Tescaro.TarefasApp.Application.Data
{
    /// <summary>
    /// Classe para armazenar dados em memória
    /// </summary>
    /// <summary>
    /// Classe para armazenamento dos dados em memória
    /// </summary>
    public class FakeDataStore
    {
        //atributo
        private static List<TarefaDTO>? _tarefas;

        //construtor para inicializar o atributo
        public FakeDataStore() => _tarefas = new List<TarefaDTO>();

        //Adicionar tarefa
        public void Add(TarefaDTO dto)
        {
            _tarefas?.Add(dto);
        }

        //Atualizar tarefa
        public void Update(TarefaDTO dto)
        {
            var tarefa = _tarefas?.FirstOrDefault(t => t.Id == dto.Id);
            if (tarefa != null)
            {
                tarefa.Nome = dto.Nome;
                tarefa.DataHora = dto.DataHora;
                tarefa.Descricao = dto.Descricao;
                tarefa.Prioridade = dto.Prioridade;
            }
        }

        //Excluir tarefa
        public void Delete(Guid? id)
        {
            var tarefa = _tarefas?.FirstOrDefault(t => t.Id == id);
            if (tarefa != null)
                _tarefas?.Remove(tarefa);
        }

        //Consultar todas as tarefas
        public List<TarefaDTO>? GetAll()
            => _tarefas;

        //Consultar 1 tarefa através do id
        public TarefaDTO? GetById(Guid? id)
            => _tarefas?.FirstOrDefault(t => t.Id == id);
    }

}


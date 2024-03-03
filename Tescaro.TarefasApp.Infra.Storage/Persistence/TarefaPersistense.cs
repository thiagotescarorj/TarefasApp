﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.TarefasApp.Infra.Storage.Collections;
using Tescaro.TarefasApp.Infra.Storage.Context;

namespace Tescaro.TarefasApp.Infra.Storage.Persistence
{
    /// <summary>
    /// Classe para persistência de dados de tarefa
    /// </summary>
    public class TarefaPersistence
    {
        private readonly MongoDBContext _mongoDBContext;

        public TarefaPersistence(MongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
        }

        public async Task Insert(TarefaCollection tarefa)
        {
            await _mongoDBContext.Tarefa.InsertOneAsync(tarefa);
        }

        public async Task Update(TarefaCollection tarefa)
        {
            var filter = Builders<TarefaCollection>.Filter.Eq(t => t.Id, tarefa.Id);
            await _mongoDBContext.Tarefa.ReplaceOneAsync(filter, tarefa);
        }

        public async Task Delete(TarefaCollection tarefa)
        {
            var filter = Builders<TarefaCollection>.Filter.Eq(t => t.Id, tarefa.Id);
            await _mongoDBContext.Tarefa.DeleteOneAsync(filter);
        }

        public async Task<List<TarefaCollection>> FindAll()
        {
            var filter = Builders<TarefaCollection>.Filter.Where(t => true);
            var result = await _mongoDBContext.Tarefa.FindAsync(filter);
            return result.ToList();
        }

        public async Task<TarefaCollection>? Find(Guid id)
        {
            var filter = Builders<TarefaCollection>.Filter.Eq(t => t.Id, id);
            var result = await _mongoDBContext.Tarefa.FindAsync(filter);
            return result.FirstOrDefault();
        }
    }

}

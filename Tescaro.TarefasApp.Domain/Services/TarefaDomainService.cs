﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.TarefasApp.Domain.Entities;
using Tescaro.TarefasApp.Domain.Interfaces.Repositories;
using Tescaro.TarefasApp.Domain.Interfaces.Services;

namespace Tescaro.TarefasApp.Domain.Services
{
    /// <summary>
    /// Implementação dos serviços de dominio para Tarefa
    /// </summary>
    public class TarefaDomainService:BaseDomainService<Tarefa, Guid>, ITarefaDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TarefaDomainService(IUnitOfWork unitOfWork) : base(unitOfWork.TarefaRepository)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task Add(Tarefa entity)
        {
            _unitOfWork.TarefaRepository?.Add(entity);
            await _unitOfWork.SaveChanges();
        }

        public async override Task Update(Tarefa entity)
        {
            _unitOfWork.TarefaRepository?.Update(entity);
            await _unitOfWork.SaveChanges();
        }

        public async override Task Delete(Tarefa entity)
        {
            _unitOfWork.TarefaRepository?.Delete(entity);
            await _unitOfWork.SaveChanges();
        }
    }

}

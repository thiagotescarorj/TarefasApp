﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.TarefasApp.Application.Commands;
using Tescaro.TarefasApp.Application.DTOs;
using Tescaro.TarefasApp.Application.Enumerators;
using Tescaro.TarefasApp.Domain.Entities;
using Tescaro.TarefasApp.Infra.Storage.Collections;

namespace Tescaro.TarefasApp.Application.Mappings
{
    /// <summary>
    /// Classe para mapeamento de/para do automapper
    /// </summary>
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //TarefaCreateCommand > Tarefa
            CreateMap<TarefaCreateCommand, Tarefa>()
                .AfterMap((src, dest) => {
                    dest.Id = Guid.NewGuid();
                    dest.DataHora = DateTime.Parse($"{src.Data} {src.Hora}");
                });

            //TarefaUpdateCommand > Tarefa
            CreateMap<TarefaUpdateCommand, Tarefa>()
                .AfterMap((src, dest) => {
                    dest.DataHora = DateTime.Parse($"{src.Data} {src.Hora}");
                });


            //Tarefa > TarefaDTO
            CreateMap<Tarefa, TarefaDTO>()
                .AfterMap((src, dest) => {
                    dest.Prioridade = (Prioridade)src.Prioridade;
                });

            //Tarefa > TarefaCollection
            CreateMap<Tarefa, TarefaCollection>()
                .AfterMap((src, dest) =>
                {
                    dest.DataHoraCadastro = DateTime.Now;
                });

            //TarefaCollection > TarefaDTO
            CreateMap<TarefaCollection, TarefaDTO>()
                .AfterMap((src, dest) =>
                {
                    dest.Prioridade = (Prioridade)src.Prioridade;
                })
                .ReverseMap();
        }
    }


}

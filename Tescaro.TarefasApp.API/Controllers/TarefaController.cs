﻿using Microsoft.AspNetCore.Mvc;
using Tescaro.TarefasApp.Application.Commands;
using Tescaro.TarefasApp.Application.DTOs;
using Tescaro.TarefasApp.Application.Interfaces;

namespace Tescaro.TarefasApp.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController:ControllerBase
    {
        private readonly ITarefaAppService? _tarefaAppService;

        public TarefaController(ITarefaAppService? tarefaAppService)
        {
            _tarefaAppService = tarefaAppService;
        }

        /// <summary>
        /// Serviço para cadastro de tarefas.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(TarefaDTO), 201)]
        public async Task<IActionResult> Post(TarefaCreateCommand command)
        {
            var dto = await _tarefaAppService?.Create(command);
            return StatusCode(201, dto);
        }

        /// <summary>
        /// Serviço para atualização de tarefas.
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(TarefaDTO), 200)]
        public async Task<IActionResult> Put(TarefaUpdateCommand command)
        {
            var dto = await _tarefaAppService?.Update(command);
            return StatusCode(200, dto);
        }

        /// <summary>
        /// Serviço para exclusão(inativação) de tarefas.
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(TarefaDTO), 200)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new TarefaDeleteCommand { Id = id };
            var dto = await _tarefaAppService?.Delete(command);
            return StatusCode(200, dto);
        }

        /// <summary>
        /// Serviço para consulta de tarefas.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<TarefaDTO>), 200)]
        public IActionResult GetAll()
        {
            var dtos = _tarefaAppService.GetAll();
            return StatusCode(200, dtos);
        }

        /// <summary>
        /// Serviço para consulta de tarefa por id.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TarefaDTO), 200)]
        public IActionResult GetById(Guid id)
        {
            var dto = _tarefaAppService.GetById(id);
            return StatusCode(200, dto);
        }

    }



}


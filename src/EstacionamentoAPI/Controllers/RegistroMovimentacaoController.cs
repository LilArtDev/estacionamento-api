using EstacionamentoAPI.DTOs;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstacionamentoAPI.Controllers
{
    [ApiController]
    [Route("api/movimentacao")]
    public class RegistroMovimentacaoController : ControllerBase
    {
        private readonly IRegistroMovimentacaoService _service;

        public RegistroMovimentacaoController(IRegistroMovimentacaoService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todos os registros de movimentação", Description = "Retorna uma lista de todos os registros de movimentação")]
        [SwaggerResponse(200, "Lista de registros de movimentação", typeof(IEnumerable<RegistroMovimentacao>))]
        public async Task<ActionResult<IEnumerable<RegistroMovimentacao>>> GetAll()
        {
            var registros = await _service.GetAllAsync();
            return Ok(registros);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um registro de movimentação pelo ID", Description = "Retorna os detalhes de um registro de movimentação específico")]
        [SwaggerResponse(200, "Detalhes do registro de movimentação", typeof(RegistroMovimentacao))]
        [SwaggerResponse(404, "Registro de movimentação não encontrado", typeof(object))]
        public async Task<ActionResult<RegistroMovimentacao>> GetById(int id)
        {
            var registro = await _service.GetByIdAsync(id);
            if (registro == null)
            {
                return NotFound(new { message = "Registro de movimentação não encontrado" });
            }
            return Ok(registro);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um novo registro de movimentação", Description = "Cria um novo registro de movimentação com base nos dados fornecidos")]
        [SwaggerResponse(201, "Registro de movimentação criado com sucesso", typeof(RegistroMovimentacao))]
        [SwaggerResponse(400, "Dados inválidos")]
        public async Task<ActionResult> Add([FromBody] RegistroMovimentacaoDTO registroMovimentacaoDto)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var registroMovimentacao = new RegistroMovimentacao
                {
                    VeiculoId = registroMovimentacaoDto.VeiculoId,
                    EstabelecimentoId = registroMovimentacaoDto.EstabelecimentoId,
                    DataHora = registroMovimentacaoDto.DataHora,
                    Tipo = registroMovimentacaoDto.Tipo
                };


                await _service.AddAsync(registroMovimentacao);
                return CreatedAtAction(nameof(GetById), new { id = registroMovimentacao.Id }, registroMovimentacao);
            }
            catch (BadHttpRequestException error)
            {
                return BadRequest(new
                {
                    message = error.Message
                });
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um registro de movimentação", Description = "Atualiza os dados de um registro de movimentação existente")]
        [SwaggerResponse(204, "Registro de movimentação atualizado com sucesso")]
        [SwaggerResponse(400, "Dados inválidos")]
        public async Task<ActionResult> Update(int id, [FromBody] RegistroMovimentacaoDTO registroMovimentacaoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registroMovimentacao = new RegistroMovimentacao
            {
                Id = id,
                VeiculoId = registroMovimentacaoDto.VeiculoId,
                EstabelecimentoId = registroMovimentacaoDto.EstabelecimentoId,
                DataHora = registroMovimentacaoDto.DataHora,
                Tipo = registroMovimentacaoDto.Tipo
            };

            await _service.UpdateAsync(registroMovimentacao);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove um registro de movimentação", Description = "Remove um registro de movimentação pelo ID")]
        [SwaggerResponse(204, "Registro de movimentação removido com sucesso")]
        [SwaggerResponse(404, "Registro de movimentação não encontrado", typeof(object))]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Registro de movimentação não encontrado" });
            }
        }
    }
}
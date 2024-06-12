using EstacionamentoAPI.DTOs;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EstacionamentoAPI.Controllers
{
    [ApiController]
    [Route("api/movimentation")]
    public class MovimentationController : ControllerBase
    {
        private readonly IMovimentationService _service;

        public MovimentationController(IMovimentationService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todos os registros de movimentação", Description = "Retorna uma lista de todos os registros de movimentação")]
        [SwaggerResponse(200, "Lista de registros de movimentação", typeof(IEnumerable<Movimentation>))]
        public async Task<ActionResult<IEnumerable<Movimentation>>> GetAll()
        {
            var registros = await _service.GetAllAsync();
            return Ok(registros);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um registro de movimentação pelo ID", Description = "Retorna os detalhes de um registro de movimentação específico")]
        [SwaggerResponse(200, "Detalhes do registro de movimentação", typeof(Movimentation))]
        [SwaggerResponse(404, "Registro de movimentação não encontrado", typeof(object))]
        public async Task<ActionResult<Movimentation>> GetById(int id)
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
        [SwaggerResponse(201, "Registro de movimentação criado com sucesso", typeof(Movimentation))]
        public async Task<ActionResult> Add([FromBody] MovimentationDTO movimentationDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var movimentation = new Movimentation
                {
                    VehicleId = movimentationDto.VehicleId,
                    EstablishmentId = movimentationDto.EstablishmentId,
                    DateTime = movimentationDto.DateTime,
                    Type = movimentationDto.Type
                };


                await _service.AddAsync(movimentation);
                return CreatedAtAction(nameof(GetById), new { id = movimentation.Id }, movimentation);
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
        [SwaggerResponse(200, "Registro de movimentação atualizado com sucesso")]
        public async Task<ActionResult> Update(int id, [FromBody] MovimentationDTO movimentationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movimentation = new Movimentation
            {
                Id = id,
                VehicleId = movimentationDto.VehicleId,
                EstablishmentId = movimentationDto.EstablishmentId,
                DateTime = movimentationDto.DateTime,
                Type = movimentationDto.Type
            };

            await _service.UpdateAsync(movimentation);
            return Ok("Registro de movimentação atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove um registro de movimentação", Description = "Remove um registro de movimentação pelo ID")]
        [SwaggerResponse(200, "Registro de movimentação removido com sucesso")]
        [SwaggerResponse(404, "Registro de movimentação não encontrado")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok("Registro de movimentação removido com sucesso");
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Registro de movimentação não encontrado" });
            }
        }
    }
}
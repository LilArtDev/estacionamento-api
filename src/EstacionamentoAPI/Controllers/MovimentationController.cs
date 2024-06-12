using EstacionamentoAPI.DTOs;
using EstacionamentoAPI.DTOs.Requests;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EstacionamentoAPI.Controllers
{
    [ApiController]
    [Route("api/movimentations")]
    public class MovimentationController : ControllerBase
    {
        private readonly IMovimentationService _service;

        public MovimentationController(IMovimentationService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todos os registros de movimentação", Description = "Retorna uma lista de todos os registros de movimentação")]
        [SwaggerResponse(200, "Lista de registros de movimentação", typeof(IEnumerable<Movimentations>))]
        public async Task<ActionResult<IEnumerable<Movimentations>>> GetAll()
        {
            var registros = await _service.GetAllAsync();
            return Ok(registros);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um registro de movimentação pelo ID", Description = "Retorna os detalhes de um registro de movimentação específico")]
        [SwaggerResponse(200, "Detalhes do registro de movimentação", typeof(Movimentations))]
        [SwaggerResponse(404, "Registro de movimentação não encontrado", typeof(object))]
        public async Task<ActionResult<Movimentations>> GetById(int id)
        {
            var registro = await _service.GetByIdAsync(id);
            if (registro == null)
            {
                return NotFound(new { message = "Registro de movimentação não encontrado" });
            }
            return Ok(registro);
        }

        [HttpPost("checkIn")]
        [SwaggerOperation(Summary = "Adiciona um novo registro de movimentação", Description = "Cria um novo registro de movimentação com base nos dados fornecidos")]
        [SwaggerResponse(201, "Registro de movimentação criado com sucesso", typeof(Movimentations))]
        public async Task<ActionResult> CheckIn([FromBody] CheckInDto checkInDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var Movimentations = new Movimentations
                {
                    VehicleId = checkInDto.VehicleId,
                    EstablishmentId = checkInDto.EstablishmentId,
                    CheckInAt = checkInDto.DateTime ?? DateTime.Now,
                };


                await _service.CheckIn(Movimentations);
                return CreatedAtAction(nameof(GetById), new { id = Movimentations.Id }, Movimentations);
            }
            catch (BadHttpRequestException error)
            {
                return BadRequest(new
                {
                    message = error.Message
                });
            }
        }

        [HttpPost("checkOut")]
        [SwaggerOperation(Summary = "Adiciona um novo registro de movimentação", Description = "Cria um novo registro de movimentação com base nos dados fornecidos")]
        [SwaggerResponse(201, "Registro de movimentação criado com sucesso", typeof(Movimentations))]
        public async Task<ActionResult> CheckOut([FromBody] CheckInDto checkInDto)
        {   
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var Movimentations = new Movimentations
                {
                    VehicleId = checkInDto.VehicleId,
                    EstablishmentId = checkInDto.EstablishmentId,
                    CheckoutAt = checkInDto.DateTime ?? DateTime.Now,
                };


                await _service.CheckOut(Movimentations);
                return CreatedAtAction(nameof(GetById), new { id = Movimentations.Id }, Movimentations);
            }
            catch (BadHttpRequestException error)
            {
                return BadRequest(new
                {
                    message = error.Message
                });
            }
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
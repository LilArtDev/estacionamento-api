using EstacionamentoAPI.DTOs;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EstacionamentoAPI.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _service;

        public VehiclesController(IVehicleService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todos os veículos", Description = "Retorna uma lista de todos os veículos")]
        [SwaggerResponse(200, "Lista de veículos", typeof(IEnumerable<Establishment>))]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetAll()
        {
            var vehicles = await _service.GetAllAsync();
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um veículo pelo ID", Description = "Retorna os detalhes de um veículo específico")]
        [SwaggerResponse(200, "Detalhes do veículo", typeof(Vehicle))]
        [SwaggerResponse(404, "Veículo não encontrado")]

        public async Task<ActionResult<Vehicle>> GetById([FromRoute] int id)
        {
            var vehicle = await _service.GetByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um novo veículo", Description = "Cria um novo veículo com base nos dados fornecidos")]
        [SwaggerResponse(201, "Veículo criado com sucesso", typeof(Vehicle))]
        public async Task<ActionResult> Add([FromBody] VehicleDTO vehicleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = new Vehicle
            {
                Brand = vehicleDto.Brand,
                Color = vehicleDto.Color,
                LicensePlate = vehicleDto.LicensePlate,
                Model = vehicleDto.Model,
                Type = vehicleDto.Type,
            };

            await _service.AddAsync(vehicle);
            return CreatedAtAction(nameof(GetById), new { id = vehicle.Id }, vehicle);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um veículo", Description = "Atualiza os dados de um veículo existente")]
        [SwaggerResponse(204, "Veículo veículo com sucesso")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] VehicleDTO vehicleDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new { message = "Dados incorretos!" });

                var updatedVehicle = new Vehicle
                {
                    Brand = vehicleDto.Brand,
                    Color = vehicleDto.Color,
                    LicensePlate = vehicleDto.LicensePlate,
                    Model = vehicleDto.Model,
                    Type = vehicleDto.Type,
                };

                await _service.UpdateAsync(id, updatedVehicle);
                return Ok(new { message = "Dados atualizados com sucesso!" });
            }
            catch (KeyNotFoundException error)
            {
                return BadRequest(new { message = error.Message });

            }
            catch (BadHttpRequestException error)
            {
                return BadRequest(new { message = error.Message });
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove um veículo", Description = "Remove um veículo pelo ID")]
        [SwaggerResponse(204, "Veículo removido com sucesso")]
        [SwaggerResponse(404, "Veículo não encontrado")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok(new { message = "Veículo deletado com sucesso!" });

            }
            catch (KeyNotFoundException error)
            {
                return NotFound(new { message = error.Message });
            }

        }
    }
}

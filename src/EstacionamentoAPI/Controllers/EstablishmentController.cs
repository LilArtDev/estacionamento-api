using EstacionamentoAPI.DTOs;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EstacionamentoAPI.Controllers
{
    [ApiController]
    [Route("api/establishment")]
    public class EstablishmentsController : ControllerBase
    {
        private readonly IEstablishmentService _service;

        public EstablishmentsController(IEstablishmentService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todos os estabelecimentos", Description = "Retorna uma lista de todos os estabelecimentos")]
        [SwaggerResponse(200, "Lista de estabelecimentos", typeof(IEnumerable<Establishment>))]
        public async Task<ActionResult<IEnumerable<Establishment>>> GetAll()
        {
            var establishments = await _service.GetAllAsync();
            return Ok(establishments);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um estabelecimento pelo ID", Description = "Retorna os detalhes de um estabelecimento específico")]
        [SwaggerResponse(200, "Detalhes do estabelecimento", typeof(Establishment))]
        [SwaggerResponse(404, "Estabelecimento não encontrado")]
        public async Task<ActionResult<Establishment>> GetById([FromRoute] int id)
        {
            try
            {
                var establishment = await _service.GetByIdAsync(id);

                return Ok(establishment);
            }
            catch (KeyNotFoundException error)
            {
                return NotFound(new { message = error.Message });
            }

        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um novo estabelecimento", Description = "Cria um novo estabelecimento com base nos dados fornecidos")]
        [SwaggerResponse(201, "Estabelecimento criado com sucesso", typeof(Establishment))]
        public async Task<ActionResult> Add(EstablishmentDTO establishmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var establishment = new Establishment
            {
                Name = establishmentDto.Name,
                Document = establishmentDto.Document,
                Address = establishmentDto.Address,
                Telephone = establishmentDto.Telephone,
                MotorcycleSpaces = establishmentDto.MotorcycleSpaces,
                CarSpaces = establishmentDto.CarSpaces
            };

            await _service.AddAsync(establishment);
            return CreatedAtAction(nameof(GetById), new { id = establishment.Id }, establishment);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um estabelecimento", Description = "Atualiza os dados de um estabelecimento existente")]
        [SwaggerResponse(204, "Estabelecimento atualizado com sucesso")]
        public async Task<ActionResult> Update(int id, EstablishmentDTO establishmentDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new { message = "Dados incorretos!" });

                var updatedEstablishment = new Establishment
                {
                    Name = establishmentDto.Name,
                    Document = establishmentDto.Document,
                    Address = establishmentDto.Address,
                    Telephone = establishmentDto.Telephone,
                    MotorcycleSpaces = establishmentDto.MotorcycleSpaces,
                    CarSpaces = establishmentDto.CarSpaces
                };

                await _service.UpdateAsync(id, updatedEstablishment);
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
        [SwaggerOperation(Summary = "Remove um estabelecimento", Description = "Remove um estabelecimento pelo ID")]
        [SwaggerResponse(204, "Estabelecimento removido com sucesso")]
        [SwaggerResponse(404, "Estabelecimento não encontrado")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok(new { message = "Estabelecimento deletado com sucesso!" });

            }
            catch (KeyNotFoundException error)
            {
                return NotFound(new { message = error.Message });
            }

        }
    }
}
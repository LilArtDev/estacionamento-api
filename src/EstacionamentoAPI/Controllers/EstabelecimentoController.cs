using EstacionamentoAPI.DTOs;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EstacionamentoAPI.Controllers
{
    [ApiController]
    [Route("api/estabelecimentos")]
    public class EstabelecimentosController : ControllerBase
    {
        private readonly IEstabelecimentoService _service;

        public EstabelecimentosController(IEstabelecimentoService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todos os estabelecimentos", Description = "Retorna uma lista de todos os estabelecimentos")]
        [SwaggerResponse(200, "Lista de estabelecimentos", typeof(IEnumerable<Estabelecimento>))]
        public async Task<ActionResult<IEnumerable<Estabelecimento>>> GetAll()
        {
            var estabelecimentos = await _service.GetAllAsync();
            return Ok(estabelecimentos);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um estabelecimento pelo ID", Description = "Retorna os detalhes de um estabelecimento específico")]
        [SwaggerResponse(200, "Detalhes do estabelecimento", typeof(Estabelecimento))]
        [SwaggerResponse(404, "Estabelecimento não encontrado")]
        public async Task<ActionResult<Estabelecimento>> GetById(int id)
        {
            try
            {
                var estabelecimento = await _service.GetByIdAsync(id);

                return Ok(estabelecimento);
            }
            catch (KeyNotFoundException error)
            {
                return NotFound(new { message = error.Message });
            }

        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um novo estabelecimento", Description = "Cria um novo estabelecimento com base nos dados fornecidos")]
        [SwaggerResponse(201, "Estabelecimento criado com sucesso", typeof(Estabelecimento))]
        public async Task<ActionResult> Add(EstabelecimentoDTO estabelecimentoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estabelecimento = new Estabelecimento
            {
                Nome = estabelecimentoDto.Nome,
                Cnpj = estabelecimentoDto.Cnpj,
                Endereco = estabelecimentoDto.Endereco,
                Telefone = estabelecimentoDto.Telefone,
                VagasMotos = estabelecimentoDto.VagasMotos,
                VagasCarros = estabelecimentoDto.VagasCarros
            };

            await _service.AddAsync(estabelecimento);
            return CreatedAtAction(nameof(GetById), new { id = estabelecimento.Id }, estabelecimento);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um estabelecimento", Description = "Atualiza os dados de um estabelecimento existente")]
        [SwaggerResponse(204, "Estabelecimento atualizado com sucesso")]
        public async Task<ActionResult> Update(int id, EstabelecimentoDTO estabelecimentoDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new { message = "Dados incorretos!" });

                var estabelecimentoAtualizado = new Estabelecimento
                {
                    Nome = estabelecimentoDto.Nome,
                    Cnpj = estabelecimentoDto.Cnpj,
                    Endereco = estabelecimentoDto.Endereco,
                    Telefone = estabelecimentoDto.Telefone,
                    VagasMotos = estabelecimentoDto.VagasMotos,
                    VagasCarros = estabelecimentoDto.VagasCarros
                };

                await _service.UpdateAsync(id, estabelecimentoAtualizado);
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
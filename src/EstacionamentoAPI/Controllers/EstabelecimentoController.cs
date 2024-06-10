using EstacionamentoAPI.Models;
using EstacionamentoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstabelecimentosController : ControllerBase
    {
        private readonly IEstabelecimentoService _service;

        public EstabelecimentosController(IEstabelecimentoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estabelecimento>>> GetAll()
        {
            var estabelecimentos = await _service.GetAllAsync();
            return Ok(estabelecimentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estabelecimento>> GetById(int id)
        {
            var estabelecimento = await _service.GetByIdAsync(id);
            if (estabelecimento == null)
            {
                return NotFound();
            }
            return Ok(estabelecimento);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Estabelecimento estabelecimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.AddAsync(estabelecimento);
            return CreatedAtAction(nameof(GetById), new { id = estabelecimento.Id }, estabelecimento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Estabelecimento estabelecimento)
        {
            if (id != estabelecimento.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(estabelecimento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
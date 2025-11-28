using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.DTOs;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _service;

        public ProdutosController(ProdutoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CriarProdutoDto dto)
        {
            try
            {
                _service.CadastrarProduto(dto);
                return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.ListarTodos());
        }

        [HttpPut("{id}/preco")]
        public IActionResult AtualizarPreco(int id, [FromBody] decimal novoPreco)
        {
            try
            {
                _service.AtualizarPreco(id, novoPreco);
                return Ok("Preço atualizado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
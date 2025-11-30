using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.DTOs;
using Application.ProdutoInterface;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutosController(IProdutoService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult Post([FromBody] CriarProdutoDto dto)
        {
            try
            {
                _service.CadastrarProduto(dto);
                return Ok("Produto cadastrado com sucesso");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_service.ListarTodos());
        }

        [HttpPut("{id}/preco")]
        public IActionResult AtualizarPreco(Guid id, [FromBody] decimal novoPreco)
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
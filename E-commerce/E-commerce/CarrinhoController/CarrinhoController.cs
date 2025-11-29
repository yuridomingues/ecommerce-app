using Application.CarrinhoDTO;
using Application.CarrinhoInterfaces;
using Application.Dtos;
using E_commerce.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.CarrinhoController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoService _service;

        public CarrinhoController(ICarrinhoService service)
        {
            _service = service;
        }
        [HttpPost("{clienteid}/AdicionarProdutoCarrinho")]
        public ActionResult CadastrarCliente(Guid clienteid, [FromBody] AdicionarProdutoCarrinhoDTO dto)
        {
            try
            {
                _service.AdicionarProdutoCarrinho(dto, clienteid);
                return Ok("Produto adicionado ao carrinho com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }

}

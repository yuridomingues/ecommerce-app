using Application.CarrinhoDTO;
using Application.CarrinhoInterfaces;
using Application.Dtos;
using E_commerce.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;

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
                return Ok(new { mensagem = "Produto adicionado ao carrinho com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });

            }
        }

        [HttpGet("{clienteid}/listarCarrinho")]

        public ActionResult ListarCliente([FromRoute] Guid clienteid)
        {
            try
            {
                return Ok(_service.ListarItensCarrinho(clienteid));
            }
            catch(Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{clienteid}/removerproduto")]

        public ActionResult RemoverProduto([FromRoute] Guid clienteid, [FromBody] RemoverProdutoDTO dto)
        {
            try
            {
                _service.RemoverProduto(clienteid, dto);
                return Ok(new { mensagem = "Item Removido com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpPut("{clienteid}/atualizarquantidade")]
        public ActionResult AtualizarQuantidade([FromRoute] Guid clienteid, [FromBody] AtualizarQuantidadeDTO dto)
        {
            try
            {
                _service.AtualizarQuantidade(dto, clienteid);
                return Ok(new { mensagem = "Quantidade de itens atualizada" });
            }
            catch(Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpPut("{clienteid}/esvaziarcarrinho")]
        public ActionResult EsvaziarCarrinho(Guid clienteid)
        {
            try
            {
                _service.EsvaziarCarrinho(clienteid);
                return Ok(new { mensagem = "Carrinho vazio" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("{clienteid}/subtotal")]

        public ActionResult SubTotal(Guid clienteid)
        {
            try
            {
                return Ok(_service.ObterSubTotal(clienteid));

            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }

}

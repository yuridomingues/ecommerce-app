using Domain;
using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers;

[ApiController]
[Route("[controller]")]
public class PagamentoController : ControllerBase
{
    [HttpPost("processar")]
    public IActionResult Processar([FromBody] PagamentoRequest request)
    {
        if (request.Itens == null || request.Itens.Count == 0)
        {
            return BadRequest(new { mensagem = "Nenhum item informado para pagamento." });
        }

        decimal total = request.Itens.Sum(i => i.Preco * i.Quantidade);

        var pagamento = new Pagamento(request.NomeCliente, request.FormaPagamento, total);

        if (pagamento.Aprovado)
        {
            return Ok(new
            {
                mensagem = "Pagamento aprovado!",
                cliente = pagamento.NomeCliente,
                formaPagamento = pagamento.FormaPagamento,
                valorTotal = pagamento.ValorTotal
            });
        }

        return BadRequest(new
        {
            mensagem = "Pagamento recusado.",
            valorTotal = pagamento.ValorTotal
        });
    }
}

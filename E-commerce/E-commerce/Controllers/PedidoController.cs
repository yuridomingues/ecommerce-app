using Microsoft.AspNetCore.Mvc;
using Application;
using Domain;
using Domain.DTOs;
using Domain.Entities;
using AutoMapper;
using Domain.Services;

namespace E_commerce.Controllers;
    
[ApiController]
[Route("api/[controller]")]

public class PedidoController: ControllerBase
{ 

    private PedidoService pedidoService;

    public PedidoController(PedidoService pedidoService)
    {
        this.pedidoService = pedidoService;
    }

    [HttpPost("criarPedido/{clienteId}")]
    public ActionResult CriarPedido(Guid clienteId, [FromBody] EnderecoDTO enderecoDTO)
    {
        try
        {
            pedidoService.CriarPedido(clienteId, enderecoDTO);
            return Ok(new { mensagem = "Pedido criado com sucesso" });
        }
        catch (Exception erro)
        {
            return StatusCode(500, new { error = erro.Message });
        }

    }


    [HttpPut("finalizarPedido")]
    public ActionResult FinalizarPedido([FromBody]PedidoDTO pedidoFinalizado)
    {

        try
        {
            var pedido = pedidoService.BuscarPedido(pedidoFinalizado.Id);

            if (pedido == null)
            {
                return NotFound(new { error = "Pedido inexistente" });
            }

            if (pedido.Status == true)
            {
                return BadRequest(new { error = "Pedido já finalizado" });
            }

            pedidoService.FinalizarPedido(pedidoFinalizado);
            return Ok(new { mensagem = "Pedido entregue com sucesso" });

        }
        catch(Exception erro)
        {
            return StatusCode(500, new { error = erro.Message });
        }    
        
    }


    [HttpDelete("excluirPedido")]
    public ActionResult ExcluirPedido([FromBody] PedidoDTO pedidoExcluido)
    {
        if (pedidoExcluido == null)
        {
            return BadRequest(new { error = "Dados do pedido são obrigatórios" });
        }
        
        try
        {
            if (pedidoService.BuscarPedido(pedidoExcluido.Id) == null)
            {
                return NotFound(new { error = "Este pedido não existe" });

            }
            else
            {
                pedidoService.ExcluirPedido(pedidoExcluido);
                return Ok(new { mensagem = "Pedido excluído com sucesso" });
            }
        }
        catch(Exception erro)
        {
            return StatusCode(500, new { error = erro.Message });
        }
        

    }


    [HttpGet("listarPedidos")]
    public ActionResult ListarPedidos()
    {
        try
        {
            return Ok(pedidoService.ListarPedidos());
        }
        catch(Exception erro)
        {
            return StatusCode(500, new { error = erro.Message });
        }

    }


    [HttpPut("alterarEndereco/{id}")]
    public ActionResult AlterarEndereco([FromBody] EnderecoDTO novoEndereco, Guid id)
    {
        if (novoEndereco == null)
        {
            return BadRequest(new { error = "Dados do endereço são obrigatórios" });
        }

        try
        {
            var pedido = pedidoService.BuscarPedido(id);

            if (pedido == null)
            {
                return NotFound(new { error = "Pedido inexistente" });
            }

            if (pedido.Status == true)
            {
                return BadRequest(new { error = "Pedido já finalizado" });
            }

            pedidoService.AlterarEndereco(novoEndereco, id);
            return Ok(new { mensagem = "Endereço alterado com sucesso" });

        }catch(Exception erro)
        {
            return StatusCode(500, new { error = erro.Message });
        }
        
    }

    [HttpPut("{id}/pagamento")]
    public ActionResult DefinirPagamento(Guid id, [FromBody] DefinirPagamentoDTO dto)
    {
        try
        {
            var pedido = pedidoService.BuscarPedidoEntidade(id);

            if (pedido == null)
            {
                return NotFound(new { error = "Pedido inexistente" });
            }

            if (pedido.Status == true)
            {
                return BadRequest(new { error = "Pedido já finalizado" });
            }

            decimal valorTotal = pedido.SubTotal;

            Pagamento pagamento = dto.TipoPagamento.ToLower() switch
            {
                "pix" => new PagamentoPix(valorTotal, dto.ChavePix ?? throw new ArgumentException("ChavePix é obrigatória")),
                "cartao" => new PagamentoCartao(valorTotal, dto.NumeroCartao ?? throw new ArgumentException("NumeroCartao é obrigatório"), dto.Parcelas ?? 1),
                _ => throw new ArgumentException("Tipo de pagamento inválido. Use 'pix' ou 'cartao'")
            };

            pedido.DefinirPagamento(pagamento);
            pedidoService.AtualizarPedido(pedido);

            return Ok(new { 
                mensagem = "Pagamento definido com sucesso",
                tipoPagamento = pagamento.ObterDescricao(),
                taxas = pagamento.CalcularTaxas(),
                valorTotal = pagamento.ObterValorTotal()
            });
        }
        catch (Exception erro)
        {
            return BadRequest(new { error = erro.Message });
        }
    }

}
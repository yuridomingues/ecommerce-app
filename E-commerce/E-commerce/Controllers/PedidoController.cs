using Microsoft.AspNetCore.Mvc;
using Application;
using Domain;
using Domain.DTOs;

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

    [HttpPost("criarPedido")]
    public ActionResult CriarPedido([FromBody] PedidoDTO novoPedido)
    {
        pedidoService.CriarPedido(novoPedido);
        return Ok(novoPedido);
    } 


    [HttpPut("finalizarPedido")]
    public ActionResult FinalizarPedido([FromBody]PedidoDTO pedidoFinalizado)
    {
        if (pedidoService.BuscarPedido(pedidoFinalizado.Id) == null)
        {
            return NotFound("Este pedido não existe");

        }
        else if(pedidoService.BuscarPedido(pedidoFinalizado.Id).Status == true)
        {
            return BadRequest("Pedido já finalizado");
        }
        else
        {
            pedidoService.FinalizarPedido(pedidoFinalizado);
            return Ok("Pedido entregue.");
        }

    }


    [HttpDelete("excluirPedido")]
    public ActionResult ExcluirPedido([FromBody] PedidoDTO pedidoExcluido)
    {
        if (pedidoService.BuscarPedido(pedidoExcluido.Id) == null)
        {
            return NotFound("Este pedido não existe");

        }
        else
        {
            pedidoService.ExcluirPedido(pedidoExcluido);
            return Ok("Pedido excluído com sucesso");
        }

    }


    [HttpGet("listarPedidos")]
    public ActionResult ListarPedidos()
    {
        return Ok(pedidoService.ListarPedidos());
    }


    [HttpPut("alterarEndereco/{id}")]
    public ActionResult AlterarEndereco([FromBody] EnderecoDTO novoEndereco, int id)
    {
        
        if (pedidoService.BuscarPedido(id) == null)
        {

            return NotFound("Pedido inexistente");

        }
        else if(pedidoService.BuscarPedido(id).Status == true)
        {

            return BadRequest("Pedido já finalizado");

        }
        else
        {

            pedidoService.AlterarEndereco(novoEndereco, id);
            return Ok();

        }

    }

}
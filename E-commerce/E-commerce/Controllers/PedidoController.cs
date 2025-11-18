using Microsoft.AspNetCore.Mvc;
using Application;
using Domain;

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
    public ActionResult CriarPedido([FromBody] Pedido novoPedido)
    {
        pedidoService.CriarPedido(novoPedido);
        return Ok(novoPedido);
    } 


    [HttpPut("finalizarPedido/{id}")]
    public ActionResult FinalizarPedido(int id)
    {
        if (pedidoService.BuscarPedido(id) == null)
        {
            return NotFound();

        }
        else if(pedidoService.BuscarPedido(id).Status == true)
        {
            return BadRequest("Pedido já finalizado");
        }
        else
        {
            pedidoService.FinalizarPedido(id);
            return Ok();
        }

    }


    [HttpPost("adicinarItem/{id}")]
    public ActionResult AdicionarItem([FromBody] ItemPedido novoItem, [FromHeader] int id)
    {
        Pedido pedido = pedidoService.BuscarPedido(id);

        if(pedido == null)
        {
            return NotFound("Pedido inexistente");
        }

        pedidoService.AdicionarItem(novoItem, pedido);
        return Ok(pedido);
    }


    [HttpDelete("excluirPedido/{id}")]
    public ActionResult ExcluirPedido(int id)
    {
        if (pedidoService.BuscarPedido(id) == null)
        {
            return NotFound();

        }
        else
        {
            pedidoService.ExcluirPedido(id);
            return Ok();
        }

    }


    [HttpGet("listarPedidos")]
    public ActionResult ListarPedidos()
    {
        return Ok(pedidoService.ListarPedidos());
    }


    [HttpPut("alterarEndereco/{id}")]
    public ActionResult AlterarEndereco([FromBody] Endereco novoEndereco, int id)
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

            Pedido pedido = pedidoService.BuscarPedido(id);

            pedidoService.AlterarEndereco(novoEndereco, pedido);
            return Ok();

        }

    }

}
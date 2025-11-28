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
        if (novoPedido == null)
        {
            return BadRequest("Dados do pedido são obrigatórios");
        }
        
        try
        {
            pedidoService.CriarPedido(novoPedido);
            return Created("", "Pedido criado com sucesso");  
        }
        catch(Exception erro)
        {
            return StatusCode(500, erro.Message);
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
                return NotFound("Pedido inexistente");
            }

            if (pedido.Status == true)
            {
                return BadRequest("Pedido já finalizado");
            }

            pedidoService.FinalizarPedido(pedidoFinalizado);
            return Ok("Pedido entregue com sucesso");

        }
        catch(Exception erro)
        {
            return StatusCode(500, erro.Message);
        }    
        
    }


    [HttpDelete("excluirPedido")]
    public ActionResult ExcluirPedido([FromBody] PedidoDTO pedidoExcluido)
    {
        if (pedidoExcluido == null)
        {
            return BadRequest("Dados do pedido são obrigatórios");
        }
        
        try
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
        catch(Exception erro)
        {
            return StatusCode(500, erro.Message);
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
            return StatusCode(500, erro.Message);
        }

    }


    [HttpPut("alterarEndereco/{id}")]
    public ActionResult AlterarEndereco([FromBody] EnderecoDTO novoEndereco, Guid id)
    {
        if (novoEndereco == null)
        {
            return BadRequest("Dados do endereço são obrigatórios");
        }

        try
        {
            var pedido = pedidoService.BuscarPedido(id);

            if (pedido == null)
            {
                return NotFound("Pedido inexistente");
            }

            if (pedido.Status == true)
            {
                return BadRequest("Pedido já finalizado");
            }

            pedidoService.AlterarEndereco(novoEndereco, id);
            return Ok("Endereço alterado com sucesso");

        }catch(Exception erro)
        {
            return StatusCode(500, erro.Message);
        }
        
    }

}
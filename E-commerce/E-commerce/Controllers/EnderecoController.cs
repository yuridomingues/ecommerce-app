using Application;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers;

[ApiController]
[Route("api/[controller]")]

public class EnderecoController : ControllerBase
{
    private EnderecoService enderecoService;

    public EnderecoController(EnderecoService enderecoService)
    {
        this.enderecoService = enderecoService;
    }

    [HttpPut("atualizarEndereco/{id}")]
    public ActionResult AtualizarEndereco([FromBody] EnderecoDTO novoEndereco, Guid id)
    {
        if (enderecoService.BuscarEndereco(id) == null)
        {
            return BadRequest("Endereço não encontrado");
        }
        else
        {
            enderecoService.AtualizarEndereco(novoEndereco, id);
            return Ok("Endereço atualizado com sucesso");
        }
    }


}

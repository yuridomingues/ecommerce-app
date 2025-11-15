using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.ClienteService;
using Application.Dtos;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpPost("Cadastrar")]
        public ActionResult CadastrarCliente([FromBody] CadastroClienteDto dto)
        {
            try
            {
                _service.CadastrarCliente(dto);
                return Ok("Conta Cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

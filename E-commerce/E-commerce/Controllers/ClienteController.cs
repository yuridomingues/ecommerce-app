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
        [HttpGet("Listar")]

        public ActionResult ListarClientes()
        {
            try
            {
               
                return Ok(_service.ListarClientes());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Excluir")]

        public ActionResult RemoverCliente([FromBody] RemoverClienteDTO dto)
        {
            try
            {
                _service.RemoverCliente(dto);
                return Ok("Cliente excluído com sucesso");
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("AlterarNome")]
        public ActionResult AlterarNome([FromBody] NovoNomeClienteDTO dto)
        {
            try
            {
                _service.AlterarNome(dto);
                return Ok("Nome alterado com sucesso");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("AlterarSenha")]

        public ActionResult AlterarSenha([FromBody] AlterarSenhaDTO dto)
        {
            try
            {
                _service.AlterarSenha(dto);
                return Ok("Senha alterada com sucesso");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

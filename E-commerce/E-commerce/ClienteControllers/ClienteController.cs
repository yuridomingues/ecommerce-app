using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.ClienteService;
using Application.Dtos;
using System.Diagnostics;
using Application.EnderecoDTO;
using Application.EnderecoService;
using Application.EnderecoInterfaces;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;
        private readonly IEnderecoService _Eservice;

        public ClienteController(IClienteService service, IEnderecoService _ENservice)
        {
            _service = service;
            _Eservice = _ENservice;
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
        [HttpPut("AlterarEmail")]
        public ActionResult AlterarEmail([FromBody] AlterarEmailDTO dto)
        {
            try
            {
                _service.AlterarEmail(dto);
                return Ok("Email Alterado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("BuscarCliente")]

        public ActionResult BuscarClienteEspecifico([FromBody] BuscarClienteEntradaDTO dto)
        {
            try
            {
               return Ok (_service.BuscarClienteEspecifico(dto));
                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost("{clienteid}/AdicionarEndereço")]
        
        public ActionResult AdicionarEndereco(Guid clienteid, [FromBody] CadastrarEnderecoDTO dto)
        {
            try
            {
                _Eservice.CadastrarEndereco(dto, clienteid);
                return Ok("Endereço adicionado ao cliente com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

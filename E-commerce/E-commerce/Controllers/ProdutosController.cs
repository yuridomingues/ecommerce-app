using Domain;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutosController : ControllerBase
{
    // Lista fixa só pra exemplo
    private static readonly List<Produto> _produtos = new()
    {
        new Produto { Id = 1, Nome = "Camiseta", Preco = 20.0m },
        new Produto { Id = 2, Nome = "Boné", Preco = 15.0m }
    };

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_produtos);
    }
}

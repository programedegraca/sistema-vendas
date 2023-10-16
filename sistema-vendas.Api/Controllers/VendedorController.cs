using Microsoft.AspNetCore.Mvc;

namespace sistema_vendas.Controllers;

[ApiController]
[Route("[controller]")]
public class VendedorController : ControllerBase
{
    /*private static readonly string[] Summaries = new[]
    {
        "Nome do Vendedor 1", "Nome do Vendedor 1", "Nome do Vendedor 3", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };*/

    private readonly ILogger<VendedorController> _logger;

    public VendedorController(ILogger<VendedorController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var listaVendedores = new List<Vendedor> 
        {
            new Vendedor
            {
                Nome = "Vendedor 1",
                CPF = 123456789,
                Email = "email@gmail.com",
                Telefone = "(31) 9 9999-9999"           
            }
        };

        return Ok(listaVendedores);
    }

    [HttpPost]
    public void Post()
    {


    }

    [HttpPut]
    public void Put()
    {


    }

    [HttpDelete]
    public void Delete()
    {


    }
}

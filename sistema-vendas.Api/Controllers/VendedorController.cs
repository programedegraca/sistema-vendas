using Microsoft.AspNetCore.Mvc;

namespace sistema_vendas.Controllers;

[ApiController]
[Route("[controller]")]
public class VendedorController : ControllerBase
{
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
                Nome = "Vendedor 1 Alterado",
                CPF = 123456789,
                Email = "emailVendedor1@gmail.com",
                Telefone = "(31) 9 5555-9999"           
            },
             new Vendedor
            {
                Nome = "Vendedor 2",
                CPF = 888888888,
                Email = "emailVendedor2@gmail.com",
                Telefone = "(31) 9 9999-0115"           
            },
            new Vendedor
            {
                Nome = "Vendedor 3",
                CPF = 999999999,
                Email = "emailVerndedor3@gmail.com",
                Telefone = "(31) 9 9999-9999"           
            },
            new Vendedor
            {
                Nome = "Vendedor 4",
                CPF = 999999999,
                Email = "emailVerndedor4@gmail.com",
                Telefone = "(31) 9 9999-9999"           
            }
        };

        return Ok(listaVendedores);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Vendedor modelo)
    {
        // O atributo [FromBody] indica que os dados da solicitação HTTP devem ser lidos e desserializados no objeto "modelo"
        
        if (modelo == null)
        {
            // Se o modelo for nulo, isso significa que os dados não foram fornecidos corretamente na solicitação
            return BadRequest("Dados inválidos");
        }

        // Faça algo com o objeto "modelo", como salvá-lo no banco de dados

        // Retorne uma resposta de sucesso (código HTTP 200) ou outra resposta apropriada
        return Ok("Operação de criação bem-sucedida");
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

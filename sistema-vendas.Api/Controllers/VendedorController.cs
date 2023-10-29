using Microsoft.AspNetCore.Mvc;

namespace sistema_vendas.Controllers;

[ApiController]
[Route("[controller]")]
public class VendedorController : ControllerBase
{
    private readonly ILogger<VendedorController> _logger;
    private readonly ApplicationDbContext _dbContext; 

    public VendedorController(ILogger<VendedorController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
         _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var listaVendedores = _dbContext.Vendedores.ToList();
        return Ok(listaVendedores);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Vendedor vendedor)
    {
        // O atributo [FromBody] indica que os dados da solicitação HTTP devem ser lidos e desserializados no objeto "modelo"
        
        _logger.LogInformation("Dentro do POST. {vendedor.Nome}");

        if (vendedor == null)
        {
            // Se o modelo for nulo, isso significa que os dados não foram fornecidos corretamente na solicitação
            return BadRequest("Dados inválidos");
        }

        _logger.LogInformation("Dentro do POST. {vendedor.Nome}", vendedor.Nome);
        // Faça algo com o objeto "vendedor", como salvá-lo no banco de dados

        // Add the new entity to the DbSet
        _dbContext.Vendedores.Add(vendedor);

        // Save the changes to the database
        _dbContext.SaveChanges();

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

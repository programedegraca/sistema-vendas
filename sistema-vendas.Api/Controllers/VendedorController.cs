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
        var validator = new VendedorValidator();
        var resultadoValidacao = validator.Validate(vendedor);

        // O atributo [FromBody] indica que os dados da solicitação HTTP devem ser lidos e desserializados no objeto "modelo"
        
        if (vendedor == null || !resultadoValidacao.IsValid)
        {
            var mensagensDeErro = resultadoValidacao.Errors.Select(erro => erro.ErrorMessage).ToList();

            // A entrada de dados é inválida
            foreach (var erro in resultadoValidacao.Errors)
            {
                _logger.LogError("Mensagem de erro: {id}", erro.ErrorMessage);
            }

            // Se o modelo for nulo, isso significa que os dados não foram fornecidos corretamente na solicitação
            return BadRequest(new { MensagensDeErro = mensagensDeErro });
        }
        
        // Adiciona a nova entitidade no DbSet
        _dbContext.Vendedores.Add(vendedor);

        // Salva as mudanças no banco de dados.
        _dbContext.SaveChanges();

        // Retorna uma resposta de sucesso (código HTTP 200) ou outra resposta apropriada
        return Ok("Operação de criação bem-sucedida");
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Vendedor vendedorAtualizado)
    {
        _logger.LogInformation("Dentro do PUT. ID: {id}", id);

        if (vendedorAtualizado == null)
        {
            return BadRequest("Dados inválidos");
        }

        // Procure o vendedor existente no banco de dados com base no ID
        var vendedorExistente = _dbContext.Vendedores.Find(id);

        if (vendedorExistente == null)
        {
            // Se o vendedor não existe, retorne um status "Not Found" (404)
            return NotFound("Vendedor não encontrado");
        }

        // Atualize as propriedades do vendedor existente com os dados fornecidos na solicitação
        vendedorExistente.CPF = vendedorAtualizado.CPF;
        vendedorExistente.Nome = vendedorAtualizado.Nome;
        vendedorExistente.Telefone = vendedorAtualizado.Telefone;
        vendedorExistente.Email = vendedorAtualizado.Email;
        vendedorExistente.Idade = vendedorAtualizado.Idade;

        // Salve as alterações no banco de dados
        _dbContext.SaveChanges();

        // Retorne uma resposta de sucesso (código HTTP 200) ou outra resposta apropriada
        return Ok("Operação de atualização bem-sucedida");
    }


    [HttpDelete]
    public void Delete()
    {


    }
}

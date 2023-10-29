using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace sistema_vendas;

public class Vendedor 
{
    [Key]
    [SwaggerSchema(ReadOnly = true)]
    public int Id { get; set;}
    public string CPF { get; set; }

    public string Nome { get; set; }

    public string Telefone { get; set; }

    public string Email { get; set; }
}

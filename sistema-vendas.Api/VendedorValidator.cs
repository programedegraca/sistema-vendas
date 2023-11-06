using FluentValidation;

namespace sistema_vendas;

public class VendedorValidator : AbstractValidator<Vendedor> 
{
  public VendedorValidator() 
  {
    RuleFor(p => p.CPF)
    .NotEmpty()
    .WithMessage("O CPF não pode estar vazio.");

    RuleFor(p => p.Nome)
    .NotEmpty()
    .WithMessage("O nome não pode estar vazio.");

    RuleFor(p => p.Telefone)
    .NotEmpty()
    .WithMessage("O Telefone não pode estar vazio.");

    RuleFor(p => p.Email)
    .NotEmpty()
    .WithMessage("O Email não pode estar vazio.");

    RuleFor(p => p.Idade)
    .InclusiveBetween(18, 100)
    .WithMessage("A idade deve estar entre 18 e 100 anos.");
  }
}
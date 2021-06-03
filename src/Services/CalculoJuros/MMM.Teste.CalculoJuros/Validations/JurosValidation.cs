using FluentValidation;
using MMM.Teste.CalculoJuros.Models;

namespace MMM.Teste.CalculoJuros.Validations
{
    public class JurosValidation : AbstractValidator<Juros>
    {
        public JurosValidation()
        {
            RuleFor(prop => prop.CapitalAplicado)
                .NotEmpty().WithMessage("Valor do capital aplicado não informado")
                .GreaterThan(0).WithMessage("Valor do capital aplicado deve ser maior que zero");

            RuleFor(prop => prop.TaxaJuros)
                .NotEmpty().WithMessage("Valor da taxa de juros não informado")
                .GreaterThan(0).WithMessage("Valor da taxa de juros deve ser maior que zero");

            RuleFor(prop => prop.TempoMeses)
                .NotEmpty().WithMessage("Valor de tempo em meses não informado")
                .GreaterThan(0).WithMessage("Valor de tempo em meses deve ser maior que zero");
        }
    }
}

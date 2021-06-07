using FluentValidation;
using MMM.Teste.CalculoJuros.Models;

namespace MMM.Teste.CalculoJuros.Validations
{
    public class JurosCompostosValidation : AbstractValidator<JurosCompostos>
    {
        public JurosCompostosValidation()
        {
            RuleFor(prop => prop.ValorInicial)
                .NotEmpty().WithMessage("Valor inicial não informado!")
                .GreaterThan(0).WithMessage("Valor inicial deve ser maior que zero!");

            RuleFor(prop => prop.TaxaJuros)
                .NotEmpty().WithMessage("Valor da taxa de juros não informado!")
                .GreaterThan(0).WithMessage("Valor da taxa de juros deve ser maior que zero!");

            RuleFor(prop => prop.TempoMeses)
                .NotEmpty().WithMessage("Valor de tempo em meses não informado!")
                .GreaterThan(0).WithMessage("Valor de tempo em meses deve ser maior que zero!");
        }
    }
}

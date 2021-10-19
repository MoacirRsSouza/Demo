using Demo.Prova.Core.Entities;
using FluentValidation;

namespace Demo.Prova.Common.Validators
{
    public class MoedasValidator : AbstractValidator<Moedas>
    {
        public MoedasValidator()
        {
            RuleFor(c => c.Moeda)
                .NotEmpty().WithMessage("Por favor insira o tipo da moeda.")
                .NotNull().WithMessage("Por favor insira o tipo da moeda.");

            RuleFor(c => c.Data_Inicio)
                .NotEmpty().WithMessage("Por favor insira a data de inicio.")
                .NotNull().WithMessage("Por favor insira a data de inicio.");

            RuleFor(c => c.Data_Fim)
                .NotEmpty().WithMessage("Por favor insira a data final.")
                .NotNull().WithMessage("Por favor insira a data final.");
        }
    }
}

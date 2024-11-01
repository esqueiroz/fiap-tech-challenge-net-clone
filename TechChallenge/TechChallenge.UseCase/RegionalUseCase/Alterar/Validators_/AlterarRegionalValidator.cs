using FluentValidation;

namespace TechChallenge.UseCase.RegionalUseCase.Alterar.Validators
{
    public class AlterarRegionalValidator : AbstractValidator<AlterarRegionalDto>
    {
        public AlterarRegionalValidator()
        {
            RuleFor(x => x.Ddd)
                .Must(x => x > 0 && x <= 99)
                .WithMessage("DDD deve pertencer ao intervalo [1-99]");

            RuleFor(x => x.Estado)
                .NotEmpty()
                .WithMessage("Estado não pode ser nulo ou vazio")
                .MaximumLength(2)
                .WithMessage("Foi atingido o número máximo de caracteres (2)");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome não pode ser nulo ou vazio")
                .MaximumLength(100)
                .WithMessage("Foi atingido o número máximo de caracteres (100)");

            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .NotEqual(x => Guid.Empty)
                .WithMessage("Não é um GUID válido");
        }
    }
}

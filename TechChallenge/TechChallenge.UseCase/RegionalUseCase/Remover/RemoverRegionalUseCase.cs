using FluentValidation;
using TechChallenge.Domain.Interfaces;
using TechChallenge.UseCase.Interfaces;

namespace TechChallenge.UseCase.RegionalUseCase.Remover
{
    public class RemoverRegionalUseCase : IRemoverRegionalUseCase
    {
        private readonly IRegionalRepository _regionalRepository;
        private readonly IValidator<RemoverRegionalDto> _validator;

        public RemoverRegionalUseCase(IRegionalRepository regionalRepository, IValidator<RemoverRegionalDto> validator)
        {
            _regionalRepository = regionalRepository;
            _validator = validator;
        }

        public void Remover(RemoverRegionalDto removerRegionalDto)
        {
            if (!_validator.Validate(removerRegionalDto).IsValid)
            {
                throw new Exception("Falha ao adicionar Regional");
            }


        }
    }
}

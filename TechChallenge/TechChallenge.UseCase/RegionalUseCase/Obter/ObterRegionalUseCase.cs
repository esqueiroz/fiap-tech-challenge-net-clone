using FluentValidation;
using TechChallenge.Domain.Interfaces;
using TechChallenge.UseCase.Interfaces;

namespace TechChallenge.UseCase.RegionalUseCase.Obter
{
    public class ObterRegionalUseCase : IObterRegionalUseCase
    {
        private readonly IRegionalRepository _regionalRepository;
        private readonly IValidator<ObterRegionalDto> _validator;

        public ObterRegionalUseCase(IRegionalRepository regionalRepository, IValidator<ObterRegionalDto> validator)
        {
            _regionalRepository = regionalRepository;
            _validator = validator;
        }

        public RegionalObtidaDto ObterPorId(ObterRegionalDto obterRegionalDto)
        {
            if (!_validator.Validate(obterRegionalDto).IsValid)
            {
                throw new Exception("Falha ao recuperar Regional por ID");
            }

            var regional = _regionalRepository.ObterPorId(obterRegionalDto.Id);

            if (regional is null)
            {
                throw new Exception("Regional não encontrada");
            }

            return new RegionalObtidaDto
            {
                Ddd = regional.Ddd,
                Estado = regional.Estado,
                Nome = regional.Nome
            };
        }


    }
}

using FluentValidation;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.RegionalAggregate;
using TechChallenge.UseCase.Interfaces;

namespace TechChallenge.UseCase.RegionalUseCase.Adicionar
{
    public class AdicionarRegionalUseCase : IAdicionarRegionalUseCase
    {
        private readonly IRegionalRepository _regionalRepository;
        private readonly IValidator<AdicionarRegionalDto> _validator;

        public AdicionarRegionalUseCase(IRegionalRepository regionalRepository, IValidator<AdicionarRegionalDto> validator)
        {
            _regionalRepository = regionalRepository;
            _validator = validator;
        }

        public RegionalAdicionadaDto Adicionar(AdicionarRegionalDto adicionarRegionalDto)
        {
            if (!_validator.Validate(adicionarRegionalDto).IsValid)
            {
                throw new Exception("Falha ao adicionar Regional");
            }

            var regional = Regional.Criar(adicionarRegionalDto.Ddd, adicionarRegionalDto.Estado, adicionarRegionalDto.Nome);

            _regionalRepository.Cadastrar(regional);

            return new RegionalAdicionadaDto
            {
                Id = regional.Id
            };
        }
    }
}

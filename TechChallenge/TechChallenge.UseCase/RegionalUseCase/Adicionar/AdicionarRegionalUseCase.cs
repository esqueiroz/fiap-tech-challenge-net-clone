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
            var validacao = _validator.Validate(adicionarRegionalDto);
            if (!validacao.IsValid)
            {
                string mensagemValidacao = string.Empty;
                foreach (var item in validacao.Errors)
                {
                    mensagemValidacao = string.Concat(mensagemValidacao, item.ErrorMessage, "/n");
                }

                throw new Exception(mensagemValidacao);
            }

            var regional = Regional.Criar(adicionarRegionalDto.Ddd, adicionarRegionalDto.Estado, adicionarRegionalDto.Nome);

            _regionalRepository.Adicionar(regional);

            return new RegionalAdicionadaDto
            {
                Id = regional.Id
            };
        }
    }
}

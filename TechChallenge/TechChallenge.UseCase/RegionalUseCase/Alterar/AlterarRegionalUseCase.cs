using FluentValidation;
using TechChallenge.Domain.Interfaces;
using TechChallenge.UseCase.Interfaces;

namespace TechChallenge.UseCase.RegionalUseCase.Alterar
{
    public class AlterarRegionalUseCase : IAlterarRegionalUseCase
    {
        private readonly IRegionalRepository _regionalRepository;
        private readonly IValidator<AlterarRegionalDto> _validator;

        public AlterarRegionalUseCase(IRegionalRepository regionalRepository, IValidator<AlterarRegionalDto> validator)
        {
            _regionalRepository = regionalRepository;
            _validator = validator;
        }

        public void Alterar(AlterarRegionalDto alterarRegionalDto)
        {
            var validacao = _validator.Validate(alterarRegionalDto);
            if (!validacao.IsValid)
            {
                string mensagemValidacao = string.Empty;
                foreach (var item in validacao.Errors)
                {
                    mensagemValidacao = string.Concat(mensagemValidacao, item.ErrorMessage, "/n");
                }

                throw new Exception(mensagemValidacao);
            }

            var regional = _regionalRepository.ObterPorId(alterarRegionalDto.Id);

            if (regional is null)
            {
                throw new Exception("Regional não encontrada");
            }

            regional.Alterar(alterarRegionalDto.Ddd, alterarRegionalDto.Estado, alterarRegionalDto.Nome);

            _regionalRepository.Alterar(regional);
        }
    }
}

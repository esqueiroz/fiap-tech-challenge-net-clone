using FluentValidation;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.RegionalAggregate;
using TechChallenge.UseCase.Interfaces;

namespace TechChallenge.UseCase.ContatoUseCase.Adicionar
{
    public class AdicionarContatoUseCase : IAdicionarContatoUseCase
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IValidator<AdicionarContatoDto> _validator;

        public AdicionarContatoUseCase(IContatoRepository contatoRepository, IValidator<AdicionarContatoDto> validator)
        {
            _contatoRepository = contatoRepository;
            _validator = validator;
        }

        public ContatoAdicionadoDto Adicionar(AdicionarContatoDto adicionarContatoDto)
        {
            if (!_validator.Validate(adicionarContatoDto).IsValid)
            {
                throw new Exception("Falha ao adicionar Contato");
            }

            var contato = Contato.Criar(adicionarContatoDto.Nome, adicionarContatoDto.Telefone, adicionarContatoDto.Email, adicionarContatoDto.RegionalId);

            _contatoRepository.Cadastrar(contato);

            return new ContatoAdicionadoDto
            {
                Id = contato.Id,
            };
        }
    }
}

using FluentValidation;
using TechChallenge.Domain.Interfaces;
using TechChallenge.UseCase.ContatoUseCase.Adicionar;
using TechChallenge.UseCase.Interfaces;

namespace TechChallenge.UseCase.ContatoUseCase.Alterar
{
    public class AlterarContatoUseCase : IAlterarContatoUseCase
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IValidator<AlterarContatoDto> _validator;

        public AlterarContatoUseCase(IContatoRepository contatoRepository, IValidator<AlterarContatoDto> validator)
        {
            _contatoRepository = contatoRepository;
            _validator = validator;
        }

        public void Alterar(AlterarContatoDto alterarContatoDto)
        {
            if (!_validator.Validate(alterarContatoDto).IsValid)
            {
                throw new Exception("Falha ao alterar Contato");
            }

            var contato = _contatoRepository.ObterPorId(alterarContatoDto.Id);

            if (contato == null)
            {
                throw new Exception("Contato não encontrado");
            }

            contato.Alterar(alterarContatoDto.Nome, alterarContatoDto.Telefone, alterarContatoDto.Email, alterarContatoDto.RegionalId);

            _contatoRepository.Alterar(contato);
        }
    }
}

using FluentValidation;
using TechChallenge.Domain.Interfaces;
using TechChallenge.UseCase.Interfaces;

namespace TechChallenge.UseCase.ContatoUseCase.Obter
{
    public class ObterContatoUseCase : IObterContatoUseCase
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IValidator<ObterContatoDto> _validator;

        public ObterContatoUseCase(IContatoRepository contatoRepository, IValidator<ObterContatoDto> obterContatoValidator)
        {
            _contatoRepository = contatoRepository;
            _validator = obterContatoValidator;
        }

        public ContatoObtidoDto ObterPorId(ObterContatoDto obterContatoDto)
        {
            if (!_validator.Validate(obterContatoDto).IsValid)
            {
                throw new Exception("Falha ao obter Contato");
            };

            var contato = _contatoRepository.ObterPorId(obterContatoDto.Id);

            if (contato == null)
            {
                throw new Exception("Contato não encontrado");
            }

            return new ContatoObtidoDto
            {
                Nome = contato.Nome,
                Telefone = contato.Telefone,
                Email = contato.Email,
                Regional = new Shared.RegionaisListadasDto
                {
                    Id = contato.Regional.Id,
                    Ddd = contato.Regional.Ddd,
                    Estado = contato.Regional.Estado,
                    Nome = contato.Regional.Nome
                }
            };
        }
    }
}

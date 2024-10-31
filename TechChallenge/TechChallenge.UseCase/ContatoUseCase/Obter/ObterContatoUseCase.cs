using TechChallenge.Domain.Interfaces;
using TechChallenge.UseCase.Interfaces;

namespace TechChallenge.UseCase.ContatoUseCase.Obter
{
    public class ObterContatoUseCase : IObterContatoUseCase
    {
        private readonly IContatoRepository _contatoRepository;

        public ObterContatoUseCase(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public ContatoObtidoDto ObterPorId(Guid id)
        {
            var contato = _contatoRepository.ObterPorId(id);

            if (contato is null)
            {
                throw new Exception("Contato não encontrado");
            }

            return new ContatoObtidoDto
            {
                Nome = contato.Nome,
                Telefone = contato.Telefone,
                Email = contato.Email,
                Regional = new Shared.RegionalDto
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

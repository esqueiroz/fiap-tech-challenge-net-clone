using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.RegionalAggregate;
using TechChallenge.UseCase.Interfaces;

namespace TechChallenge.UseCase.ContatoUseCase.Listar
{
    public class ListarContatosUseCase : IListarContatoUseCase
    {
        private readonly IContatoRepository _contatoRepository;

        public ListarContatosUseCase(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public IList<ContatosListadosDto> Listar()
        {
            return _contatoRepository.ObterTodos().Select(x => Mapper(x)).ToList();
        }

        private ContatosListadosDto Mapper(Contato contato)
        {
            return new ContatosListadosDto
            {
                Id = contato.Id,
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

using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.RegionalAggregate;
using TechChallenge.UseCase.Interfaces;
using TechChallenge.UseCase.Shared;

namespace TechChallenge.UseCase.RegionalUseCase.Listar
{
    public class ListarRegionalUseCase : IListarRegionalUseCase
    {
        private readonly IRegionalRepository _regionalRepository;
        private readonly IContatoRepository _contatoRepository;

        public ListarRegionalUseCase(IRegionalRepository repository, IContatoRepository contatoRepository)
        {
            _regionalRepository = repository;
            _contatoRepository = contatoRepository;
        }

        public IList<RegionalDto> Listar()
        {
            return _regionalRepository.Listar().Select(x => Mapper(x)).ToList();
        }

        public IList<ContatosPorRegionalDto> ListarContatosPorRegionalId(Guid id)
        {
            var regional = _regionalRepository.ObterPorId(id);

            if (regional is null)
            {
                throw new Exception("Regional não encontrada");
            }

            var contatos = _contatoRepository.ListarPorRegional(regional.Id);

            if (contatos is null || contatos.Count == 0)
            {
                throw new Exception("Regional não possui contatos vinculados");
            }

            return contatos.Select(x => Mapper(x)).ToList();
        }

        public IList<ContatosPorRegionalDto> ListarContatosPorDdd(int ddd)
        {
            var regional = _regionalRepository.ObterPorDdd(ddd);

            if (regional is null)
            {
                throw new Exception("Regional não encontrada");
            }

            var contatos = _contatoRepository.ListarPorRegional(regional.Id);

            if (contatos is null || contatos.Count == 0)
            {
                throw new Exception("Regional não possui contatos vinculados");
            }

            return contatos.Select(x => Mapper(x)).ToList();
        }

        private RegionalDto Mapper(Regional regional)
        {
            return new RegionalDto
            {
                Id = regional.Id,
                Ddd = regional.Ddd,
                Estado = regional.Estado,
                Nome = regional.Nome
            };
        }

        private ContatosPorRegionalDto Mapper(Contato regional)
        {
            return new ContatosPorRegionalDto
            {
                Id = regional.Id,
                Nome = regional.Nome,
                Telefone = regional.Telefone,
                Email = regional.Email
            };
        }
    }
}

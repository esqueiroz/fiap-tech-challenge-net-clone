using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.RegionalAggregate;
using TechChallenge.UseCase.Interfaces;

namespace TechChallenge.UseCase.RegionalUseCase.Listar
{
    public class ListarRegionalUseCase : IListarRegionalUseCase
    {
        private readonly IRegionalRepository _repository;

        public ListarRegionalUseCase(IRegionalRepository repository)
        {
            _repository = repository;
        }

        public IList<RegionaisListadasDto> Listar()
        {
            return _repository.ObterTodos().Select(x => Mapper(x)).ToList();
        }

        private RegionaisListadasDto Mapper(Regional regional)
        {
            return new RegionaisListadasDto
            {
                Id = regional.Id,
                Ddd = regional.Ddd,
                Estado = regional.Estado,
                Nome = regional.Nome
            };
        }
    }
}

using TechChallenge.UseCase.RegionalUseCase.Listar;
using TechChallenge.UseCase.Shared;

namespace TechChallenge.UseCase.Interfaces
{
    public interface IListarRegionalUseCase : IListarUseCase<RegionalDto>
    {
        IList<ContatosPorRegionalDto> ListarContatosPorRegionalId(Guid id);
        IList<ContatosPorRegionalDto> ListarContatosPorDdd(int ddd);
    }
}

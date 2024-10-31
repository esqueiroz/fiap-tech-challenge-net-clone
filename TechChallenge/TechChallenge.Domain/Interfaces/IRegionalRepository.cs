using TechChallenge.Domain.RegionalAggregate;

namespace TechChallenge.Domain.Interfaces
{
    public interface IRegionalRepository : IRepository<Regional>
    {
        Regional ObterPorDdd(int ddd);
    }
}

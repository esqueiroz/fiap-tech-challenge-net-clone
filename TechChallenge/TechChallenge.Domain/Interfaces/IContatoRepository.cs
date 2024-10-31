using TechChallenge.Domain.RegionalAggregate;

namespace TechChallenge.Domain.Interfaces
{
    public interface IContatoRepository : IRepository<Contato>
    {
        IList<Contato> ListarPorRegional(Guid regionalId);
    }
}

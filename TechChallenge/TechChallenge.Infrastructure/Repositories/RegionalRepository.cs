using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.RegionalAggregate;

namespace TechChallenge.Infrastructure.Repositories
{
    public class RegionalRepository : EFRepository<Regional>, IRegionalRepository
    {
        public RegionalRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

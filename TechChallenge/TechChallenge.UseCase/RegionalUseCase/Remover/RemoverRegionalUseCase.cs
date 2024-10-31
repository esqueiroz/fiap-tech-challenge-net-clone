using TechChallenge.Domain.Interfaces;
using TechChallenge.UseCase.Interfaces;

namespace TechChallenge.UseCase.RegionalUseCase.Remover
{
    public class RemoverRegionalUseCase : IRemoverRegionalUseCase
    {
        private readonly IRegionalRepository _regionalRepository;
        private readonly IContatoRepository _contatoRepository;

        public RemoverRegionalUseCase(IRegionalRepository regionalRepository, IContatoRepository contatoRepository)
        {
            _regionalRepository = regionalRepository;
            _contatoRepository = contatoRepository;
        }

        public void Remover(Guid id)
        {
            var regional = _regionalRepository.ObterPorId(id);

            if (regional is null)
            {
                throw new Exception("Regional não encontrada");
            }

            var contatos = _contatoRepository.ListarPorRegional(regional.Id);

            if (contatos is not null && contatos.Count > 0)
            {
                throw new Exception("Regional possui contatos vinculados");
            }

            _regionalRepository.Remover(regional);
        }
    }
}

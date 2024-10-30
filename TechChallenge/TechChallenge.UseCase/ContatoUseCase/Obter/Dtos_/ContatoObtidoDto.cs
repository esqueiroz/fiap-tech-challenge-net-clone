using TechChallenge.Domain.RegionalAggregate;
using TechChallenge.UseCase.Shared;

namespace TechChallenge.UseCase.ContatoUseCase.Obter
{
    public class ContatoObtidoDto
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public RegionaisListadasDto Regional {  get; set; }
        
    }
}

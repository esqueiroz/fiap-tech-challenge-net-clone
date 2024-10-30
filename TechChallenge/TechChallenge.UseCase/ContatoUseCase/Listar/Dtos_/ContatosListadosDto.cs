using TechChallenge.UseCase.Shared;

namespace TechChallenge.UseCase.ContatoUseCase.Listar
{
    public class ContatosListadosDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public RegionaisListadasDto Regional { get; set; }
    }
}

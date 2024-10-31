using TechChallenge.UseCase.Shared;

namespace TechChallenge.UseCase.ContatoUseCase.Listar
{
    public class ContatosListadosDto
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Telefone { get; set; }
        public required string Email { get; set; }
        public required RegionalDto Regional { get; set; }
    }
}

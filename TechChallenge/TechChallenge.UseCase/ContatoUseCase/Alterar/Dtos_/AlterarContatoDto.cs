namespace TechChallenge.UseCase.ContatoUseCase.Alterar
{
    public class AlterarContatoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Guid RegionalId { get; set; }
    }
}

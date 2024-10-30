namespace TechChallenge.UseCase.ContatoUseCase.Adicionar
{
    public class AdicionarContatoDto
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Guid RegionalId { get; set; }
    }
}

namespace TechChallenge.UseCase.RegionalUseCase.Alterar
{
    public class AlterarRegionalDto
    {
        public Guid Id { get; set; }
        public int Ddd { get; set; }
        public required string Estado { get; set; }
        public required string Nome { get; set; }
    }
}

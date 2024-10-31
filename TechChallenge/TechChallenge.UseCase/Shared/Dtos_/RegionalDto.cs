namespace TechChallenge.UseCase.Shared
{
    public class RegionalDto
    {
        public Guid Id { get; set; }
        public int Ddd { get; set; }
        public required string Estado { get; set; }
        public required string Nome { get; set; }
    }
}

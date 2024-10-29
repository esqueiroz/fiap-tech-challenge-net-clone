namespace TechChallenge.UseCase.Interfaces
{
    public interface IListarUseCase<TOutput>
    {
        IList<TOutput> Listar();
    }
}

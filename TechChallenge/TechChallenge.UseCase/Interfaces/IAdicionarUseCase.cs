namespace TechChallenge.UseCase.Interfaces
{
    public interface IAdicionarUseCase<TInput, TOutput>
    {
        TOutput Adicionar(TInput input);
    }
}

namespace TechChallenge.UseCase.Interfaces
{
    public interface IObterUseCase<TInput, TOutput>
    {
        TOutput ObterPorId(TInput intput);
    }
}

namespace TechChallenge.Domain.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        IList<T> ObterTodos();
        T ObterPorId(Guid id);
        void Cadastrar(T entidade);
        void Alterar(T entidade);
        void Deletar(Guid id);
    }
}

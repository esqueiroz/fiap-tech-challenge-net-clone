namespace TechChallenge.Domain.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        IList<T> Listar();
        T ObterPorId(Guid id);
        void Adicionar(T entidade);
        void Alterar(T entidade);
        void Remover(T entidade);
    }
}

namespace TechChallenge.Domain.RegionalAggregate
{
    public class Regional : EntityBase
    {
        public int Ddd { get; set; }
        public string Estado { get; set; }
        public string Nome { get; set; }

        protected Regional(int ddd, string estado, string nome)
        {
            Ddd = ddd;
            Estado = estado;
            Nome = nome;
        }

        public static Regional Criar(int ddd, string estado, string nome)
        {
            if (ddd <= 0 || ddd > 99)
                throw new ArgumentException("DDD inválido");

            if (String.IsNullOrWhiteSpace(estado) || estado.Length > 2)
                throw new ArgumentException("Estado inválido");

            if (String.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome da Regional inválido");

            return new Regional(ddd, estado, nome);
        }

        public Regional Alterar(int ddd, string estado, string nome)
        {
            Ddd = ddd;
            Estado = estado;
            Nome = nome;

            return this;
        }
    }
}

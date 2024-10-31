using Bogus;
using TechChallenge.Domain.RegionalAggregate;

namespace TechChallenge.UnitTest.UseCase.ContatoUseCase.Shared
{
    public class ContatoBuilder
    {
        private Contato _contato;

        public ContatoBuilder()
        {
            _contato = new Faker<Contato>("pt_BR")
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.Nome, f => f.Person.FullName)
                .RuleFor(x => x.Telefone, f => f.Phone.PhoneNumber("9####-####"))
                .RuleFor(x => x.Email, f => f.Internet.Email())
                .RuleFor(x => x.RegionalId, f => f.Random.Guid());
        }
        public ContatoBuilder WithId(Guid id)
        {
            _contato.Id = id;
            return this;
        }

        public Contato Build()
        {
            return _contato;
        }
    }
}


using FluentValidation;
using Moq;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.RegionalAggregate;
using TechChallenge.UseCase.ContatoUseCase.Adicionar;
using TechChallenge.UseCase.Interfaces;

namespace TechChallenge.UnitTest.UseCase.ContatoUseCase.Adicionar
{
    public class AdicionarContatoUseCaseTest
    {
        private readonly AdicionarContatoDtoBuilder _builder;
        private readonly Mock<IContatoRepository> _contatoRepository;
        private readonly Mock<IValidator<AdicionarContatoDto>> _validator;
        private readonly IAdicionarContatoUseCase _adicionarContatoUseCase;

        public AdicionarContatoUseCaseTest()
        {
            _validator = new Mock<IValidator<AdicionarContatoDto>>();
            _contatoRepository = new Mock<IContatoRepository>();
            _builder = new AdicionarContatoDtoBuilder();

            _adicionarContatoUseCase = new AdicionarContatoUseCase(_contatoRepository.Object, _validator.Object);

        }

        [Fact]
        public void AdicionarContatoUseCase_Adicionar_Sucesso()
        {
            // Arrange

            var adicionarContatoDto = _builder.Default().Build();

            _validator.Setup(s => s.Validate(It.IsAny<AdicionarContatoDto>()))
                    .Returns(new FluentValidation.Results.ValidationResult());

            _contatoRepository.Setup(s => s.Adicionar(It.IsAny<Contato>()));


            // Act

            var result = _adicionarContatoUseCase.Adicionar(adicionarContatoDto);


            // Assert

            Assert.True(result.Id != default);

        }

        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        public void AdicionarContatoUseCase_Adicionar_ErroValidacaoNome(string nome)
        {
            // Arrange
            var adicionarContatoDto = _builder.Default().WithName(nome).Build();


            _validator.Setup(s => s.Validate(It.IsAny<AdicionarContatoDto>()))
                    .Returns(new FluentValidation.Results.ValidationResult());

            _contatoRepository.Setup(s => s.Adicionar(It.IsAny<Contato>()));


            // Act

            var result = Assert.Throws<ArgumentException>(() => _adicionarContatoUseCase.Adicionar(adicionarContatoDto));


            // Assert

            Assert.Equal("Nome do Contato inválido", result.Message);

        }

        [Theory]
        [InlineData("12345-6789")]
        [InlineData("08645-6441")]
        [InlineData("34887037")]
        [InlineData("999999999")]
        [InlineData("")]
        [InlineData("     ")]
        public void AdicionarContatoUseCase_Adicionar_ErroValidacaoTelefone(string telefone)
        {
            // Arrange
            var adicionarContatoDto = _builder.Default().WithTelefone(telefone).Build();


            _validator.Setup(s => s.Validate(It.IsAny<AdicionarContatoDto>()))
                    .Returns(new FluentValidation.Results.ValidationResult());

            _contatoRepository.Setup(s => s.Adicionar(It.IsAny<Contato>()));


            // Act

            var result = Assert.Throws<ArgumentException>(() => _adicionarContatoUseCase.Adicionar(adicionarContatoDto));


            // Assert

            Assert.Equal("Telefone inválido", result.Message);

        }

        [Theory]
        [InlineData("testedeemail")]
        [InlineData("email@@gmail.com")]
        [InlineData("teste@live")]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData("testetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetesteteste" +
            "@testetestetestetestetestetestetestetestetestetestetesteteste")]
        public void AdicionarContatoUseCase_Adicionar_ErroValidacaoEmail(string email)
        {
            // Arrange
            var adicionarContatoDto = _builder.Default().WithEmail(email).Build();


            _validator.Setup(s => s.Validate(It.IsAny<AdicionarContatoDto>()))
                    .Returns(new FluentValidation.Results.ValidationResult());

            _contatoRepository.Setup(s => s.Adicionar(It.IsAny<Contato>()));


            // Act

            var result = Assert.Throws<ArgumentException>(() => _adicionarContatoUseCase.Adicionar(adicionarContatoDto));


            // Assert

            Assert.Equal("E-mail inválido", result.Message);

        }
    }
}

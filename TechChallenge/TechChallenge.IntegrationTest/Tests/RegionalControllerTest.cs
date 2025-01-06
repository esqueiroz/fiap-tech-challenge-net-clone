using System.Net.Http.Json;
using TechChallenge.IntegrationTest.Factories;
using TechChallenge.IntegrationTest.Fixtures;
using TechChallenge.UseCase.RegionalUseCase.Adicionar;
using TechChallenge.UseCase.RegionalUseCase.Alterar;
using TechChallenge.UseCase.RegionalUseCase.Obter;
using TechChallenge.UseCase.Shared;

namespace TechChallenge.IntegrationTest.Tests
{
    public class RegionalControllerTest : IClassFixture<DatabaseFixture>
    {
        private readonly HttpClient _client;

        public RegionalControllerTest(DatabaseFixture databaseFixture)
        {            
            var factory = new CustomWebApplicationFactory(databaseFixture.Container.GetConnectionString());
            _client = factory.CreateClient();            
        }

        [Fact]
        public async Task RegionalController_ListarRegionais_Sucesso()
        {
            //Arrange
            //Act            
            var response = await _client.GetAsync("/regional");

            //Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseString);
        }

        [Fact]
        public async Task RegionalController_ObterPorIdRegional_Sucesso()
        {
            //Arrange
            var responseGetAll = await _client.GetAsync("/regional");
            var responseGetAllData = await responseGetAll.Content.ReadFromJsonAsync<List<RegionalDto>>();
            var regional = responseGetAllData.First();

            //Act            
            var response = await _client.GetAsync($"/regional/{regional.Id}");

            //Assert
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadFromJsonAsync<RegionalObtidaDto>();
            Assert.NotNull(responseData);
            Assert.Equal(regional.Ddd, responseData.Ddd);
            Assert.Equal(regional.Estado, responseData.Estado);
            Assert.Equal(regional.Nome, responseData.Nome);
        }

        [Fact]
        public async Task RegionalController_AdicionarRegional_Sucesso()
        {
            //Arrange
            var regional = new AdicionarRegionalDto { Ddd = 31, Estado = "MG", Nome = "Regional Teste"};

            //Act            
            var response = await _client.PostAsJsonAsync($"/regional", regional);

            //Assert
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadFromJsonAsync<RegionalAdicionadaDto>();
            Assert.NotNull(responseData);
            Assert.NotEqual(Guid.Empty, responseData.Id);
        }

        [Fact]
        public async Task RegionalController_AlterarRegional_Sucesso()
        {
            //Arrange
            var responseGetAll = await _client.GetAsync("/regional");
            var responseGetAllData = await responseGetAll.Content.ReadFromJsonAsync<List<RegionalDto>>();
            var regional = responseGetAllData.First();
            var regionalAlterada = new AlterarRegionalDto { Id = regional.Id, Ddd = regional.Ddd, Estado = regional.Estado, Nome = "Regional Teste" };

            //Act            
            var response = await _client.PutAsJsonAsync($"/regional", regionalAlterada);

            //Assert
            response.EnsureSuccessStatusCode() ;

            var responseGetById = await _client.GetAsync($"/regional/{regional.Id}");

            var responseData = await responseGetById.Content.ReadFromJsonAsync<RegionalObtidaDto>();
            Assert.NotNull(responseData);
            Assert.Equal(regionalAlterada.Ddd, responseData.Ddd);
            Assert.Equal(regionalAlterada.Estado, responseData.Estado);
            Assert.Equal(regionalAlterada.Nome, responseData.Nome);

        }

        [Fact]
        public async Task RegionalController_RemoverRegional_Sucesso()
        {
            //Arrange
            var responseGetAll = await _client.GetAsync("/regional");
            var responseGetAllData = await responseGetAll.Content.ReadFromJsonAsync<List<RegionalDto>>();
            var regional = responseGetAllData.First();

            //Act            
            var response = await _client.DeleteAsync($"/regional/{regional.Id}");

            //Assert
            response.EnsureSuccessStatusCode();
            var responseGetById = await _client.GetAsync($"/regional/{regional.Id}");            
            var mensagemErro = await responseGetById.Content.ReadAsStringAsync();
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, responseGetById.StatusCode);
            Assert.Equal("Regional não encontrada", mensagemErro);
        }
    }
}

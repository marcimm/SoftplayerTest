using FluentAssertions;
using MMM.IntegrationTests.Configurations;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace MMM.IntegrationTests.Api
{
    public class ApiCalculoJurosTest : IClassFixture<CustomWebApplicationFactory<StartupCalculoJurosTest>>
    {
        private readonly CustomWebApplicationFactory<StartupCalculoJurosTest> _factory;

        public ApiCalculoJurosTest(CustomWebApplicationFactory<StartupCalculoJurosTest> factory)
        {
            _factory = factory;
        }

        [Theory(DisplayName = "Status Code 200 OK para todos os endpoints")]
        [InlineData("/")]
        [InlineData("v1/showmethecode")]
        [InlineData("v1/calculajuros")]
        public async Task Api_EndpointsReturnSuccess(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "Retorno correto do endpoint v1/showmethecode")]
        [Trait("ApiTest", "Retorna GitHub Url")]
        public async Task ApiTest_CalculoJuros_RetornarGitHubUrl()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("v1/showmethecode");
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            responseString.Should().Contain("Url Projeto: https://github.com/marcimm");
        }
    }
}

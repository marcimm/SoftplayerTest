using FluentAssertions;
using MMM.Teste.CalculoJuros.Models;
using Xunit;
using Xunit.Abstractions;

namespace MMM.UnitTests
{
    public class JurosTest
    {
        private readonly ITestOutputHelper _outputHelper;

        [Fact(DisplayName = "Calcular Juros Compostos")]
        [Trait("Juros", "Cálculo de Juros")]
        public void Juros_CalcularJurosCompostos()
        {
            // Arrange
            var valorInicial = 100;
            var taxaJuros = 0.01M;
            var tempoMeses = 12;

            // Act
            JurosCompostos jurosCompostos = new JurosCompostos(valorInicial, taxaJuros, tempoMeses);
            
            // Assert
            Assert.Equal(112.68250301319700M, jurosCompostos.ValorFinal);
        }

        [Theory(DisplayName = "Validação do Cálculo")]
        [Trait("Juros", "Validação Juros Compostos ")]
        [InlineData(100, 0.05, 2, 110.2500)]
        [InlineData(1845, 0.1, 3, 2455.695)]
        [InlineData(5789, 1, 4, 92624)]
        [InlineData(100000, 2, 5, 24300000)]
        public void Juros_CalcularJurosCompostos_ValidarValorFinal(int valorInicial, decimal taxaJuros, int tempoMeses, decimal valorFinal)
        {
            // Act
            JurosCompostos jurosCompostos = new JurosCompostos(valorInicial, taxaJuros, tempoMeses);

            // Assert
            jurosCompostos.ValorFinal.Should().Be(valorFinal);
        }
    }
}


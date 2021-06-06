using AutoMapper;
using FluentAssertions;
using MMM.Teste.CalculoJuros.Application.Services;
using MMM.Teste.CalculoJuros.Application.ViewModels;
using MMM.Teste.CalculoJuros.Models;
using Moq.AutoMock;
using System.Threading.Tasks;
using Xunit;

namespace MMM.UnitTests.Services
{
    //100 0.05M 2 110.2500M
    //1845 0.1M 3 2455.695M
    //5789 1M 4 92624M
    //100000 2M 5 24300000M

    public class CalculoJurosServiceTest
    {
        private readonly IMapper _mapper;

        public CalculoJurosServiceTest()
        {
            // AutoMapper Config
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<JurosCompostosViewModel, JurosCompostos>().ReverseMap();
            });
            _mapper = config.CreateMapper();
        }

        [Fact(DisplayName = "Servico de Cálculo de Juros Compostos")]
        [Trait("Servico Juros", "Cálculo de Juros Compostos")]
        public async Task Juros_CalcularJurosCompostos()
        {
            // Arrange            
            decimal valorInicial = 100;
            int tempoMeses = 12;

            // AutoMocker IoC
            var mocker = new AutoMocker();
            mocker.Use<ITaxaJurosService>(x => x.GetTaxaJuros().Result == 0.01M);
            mocker.Use<IMapper>(_mapper);

            var calculoJurosService = mocker.CreateInstance<CalculoJurosService>();

            // Act
            var result = await calculoJurosService.CalcularJuros(valorInicial, tempoMeses);

            // Assert
            result.ValorFinal.Should().Be(112.68250301319700M);
        }
    }
}

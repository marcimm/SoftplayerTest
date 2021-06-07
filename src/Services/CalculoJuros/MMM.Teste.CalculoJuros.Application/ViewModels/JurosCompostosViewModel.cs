using MMM.Test.Core.Extensions;
using Newtonsoft.Json;

namespace MMM.Teste.CalculoJuros.Application.ViewModels
{
    public class JurosCompostosViewModel
    {
        public JurosCompostosViewModel()
        { }

        [JsonProperty("valorFinal")]
        [JsonConverter(typeof(DecimalF2FormatConverter))]
        public decimal ValorFinal { get; set; }
    }
}

using Newtonsoft.Json;
using System;

namespace MMM.Teste.CalculoJuros.Application.ViewModels
{
    public class ErrorDetailsViewModel
    {
        [JsonProperty("timeStamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? TimeStamp { get; set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { set; get; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        [JsonProperty("exceptionType", NullValueHandling = NullValueHandling.Ignore)]
        public string ExceptionType { get; set; }

        [JsonProperty("additionalInformation", NullValueHandling = NullValueHandling.Ignore)]
        public string AdditionalInformation { set; get; }
    }
}

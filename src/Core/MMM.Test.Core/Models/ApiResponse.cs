using Newtonsoft.Json;
using System.Collections.Generic;

namespace MMM.Test.Core.Models
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        { }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("response", NullValueHandling = NullValueHandling.Ignore)]
        public T Response { get; set; }

        [JsonProperty("messages", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Messages { get; set; }
    }
}

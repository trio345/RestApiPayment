using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiTO.Wrapper
{
    public class GeneralResponseModel<T>
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        
        [JsonProperty("status")]
        public bool Status { get; set; } = true;

        [JsonProperty("data")]
        public T Data { get; set; }

        public GeneralResponseModel(T data)
        {
            Data = data;
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callapp.Shared.Results
{
    public class Error
    {
        [JsonProperty("message")]
        public string Message { get; }

        [JsonProperty("occuredDate")]
        public DateTime OccuredDate { get; }

        public Error(string message)
        {
            Message = message;
            OccuredDate = DateTime.UtcNow.AddHours(4);
        }
    }
}

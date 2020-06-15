using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarsLibraryApi.Models
{
    public class LogModel
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("requestBody")]
        public string RequestBody { get; set; }
        [JsonProperty("requestStatus")]
        public string Status { get; set; }
        [JsonProperty("requestStart")]
        public DateTime RequestStart { get; set; }
        [JsonProperty("requestEnd")]
        public DateTime RequestEnd { get; set; }

        [JsonProperty("timeDoRequest")]
        public long TimeRequest { get; set; }
    }
}

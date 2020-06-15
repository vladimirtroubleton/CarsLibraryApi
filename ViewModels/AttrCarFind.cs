using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarsLibraryApi.ViewModels
{
    public class AttrCarFind
    {
        [JsonProperty("attrKey")]
        public string AttrKey { get; set; }

        [JsonProperty("attrValues")]
        public string AttrValues { get; set; }
    }
}

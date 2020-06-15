using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarsLibraryApi.Models
{
    public class CarModel
    {
        [Key]
        [JsonProperty("numberCar")]
        public string Number { get; set; }
        [JsonProperty("typeCar")]
        public string Type { get; set; }
        [JsonProperty("modelCar")]
        public string Model { get; set; }
        [JsonProperty("releaseYear")]
        public int ReleaseYear { get; set; }
        [JsonProperty("ownerName")]
        public string OwnerName { get; set; }
        [JsonProperty("countHourseForces")]
        public string CountHourseForces { get; set; }
    }
}

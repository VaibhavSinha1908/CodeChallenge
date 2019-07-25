using Newtonsoft.Json;

namespace CodeTask.API.Models
{
    public class PremiumCalculationRequest
    {
        [JsonProperty("name")]
        public string userName { get; set; }

        [JsonProperty("dateOfBirth")]
        public string dateOfBirth { get; set; }

        [JsonProperty("occupation")]
        public string Occupation { get; set; }

        public int age { get; set; }

        [JsonProperty("sumInsured")]
        public string sumIssured { get; set; }

        public string Rating { get; set; }
        public decimal Factor { get; set; }
    }
}

using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestJson
{
    public class RootObject
    {
        public List<Team> Team { get; set; }
    }

    public class Team
    {
        public string v1 { get; set; }
        [JsonProperty("eighty_min_score")]
        public string EightyMinScore { get; set; }
        [JsonProperty("home_or_away")]
        public string HomeOrAway { get; set; }
        [JsonProperty("score")]
        public string Score { get; set; }
        [JsonProperty("team_id")]
        public string TeamId { get; set; }
    }
}

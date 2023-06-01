using Newtonsoft.Json;
using System.Collections.Generic;

namespace FootballLeagueTable.JsonObjects
{
    public class Round
    {
        [JsonProperty("RoundNumber")]
        public int RoundNumber { get; set; }

        [JsonProperty("Matches")]
        public IEnumerable<Match> Matches { get; set; }
    }
}

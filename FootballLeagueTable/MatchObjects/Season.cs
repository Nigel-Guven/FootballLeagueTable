using Newtonsoft.Json;
using System.Collections.Generic;

namespace FootballLeagueTable.JsonObjects
{
    public class Season
    {
        [JsonProperty("Season")]
        public IEnumerable<Round> Rounds { get; set; }
    }
}

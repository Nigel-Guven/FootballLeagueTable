using Newtonsoft.Json;

namespace FootballLeagueTable.JsonObjects
{
    public class Match
    {
        [JsonProperty("HomeTeam")]
        public string HomeTeam { get; set; }

        [JsonProperty("AwayTeam")]
        public string AwayTeam { get; set; }

        [JsonProperty("HomeTeamScore")]
        public int HomeTeamScore { get; set; }

        [JsonProperty("AwayTeamScore")]
        public int AwayTeamScore { get; set; }
    }
}

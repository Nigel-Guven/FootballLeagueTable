using Newtonsoft.Json;
using System;

namespace FootballLeagueTable.Table
{
    public class Team : IComparable<Team>
    {
        [JsonProperty("TeamName")]
        public string TeamName { get; set; }

        [JsonProperty("Points")]
        public int Points { get; set; }

        [JsonProperty("GoalsFor")]
        public int GoalsFor { get; set; }

        [JsonProperty("GoalsAgainst")]
        public int GoalsAgainst { get; set; }

        public int CompareTo(Team other)
        {
            if (other == null)
                return -1;
            if(this.Points)
            if (this.Points > other.Points && this.GoalsFor == other.GoalsFor && this.GoalsAgainst < other.GoalsAgainst)
                return -1;
            if (this.Points == other.Points && this.GoalsFor > other.GoalsFor && this.GoalsAgainst < other.GoalsAgainst)
                return -1;
            if (this.Points > other.Points && this.GoalsFor > other.GoalsFor && this.GoalsAgainst < other.GoalsAgainst)
                return -1;
            if (this.Points > other.Points && this.GoalsFor < other.GoalsFor && this.GoalsAgainst > other.GoalsAgainst)
                return -1;
            else
                return 0;
        }
    }
}
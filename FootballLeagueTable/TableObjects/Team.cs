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
            if (int.Parse((this.Points).ToString() + (this.GoalsFor).ToString() + (this.GoalsAgainst).ToString()) 
                > int.Parse((other.Points).ToString() + (other.GoalsFor).ToString() + (other.GoalsAgainst).ToString()))
                return -1;
            else if (int.Parse((this.Points).ToString() + (this.GoalsFor).ToString() + (this.GoalsAgainst).ToString()) 
                < int.Parse((other.Points).ToString() + (other.GoalsFor).ToString() + (other.GoalsAgainst).ToString()))
                return 1;
            else
                return 0;
        }
    }
}
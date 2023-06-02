using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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

        [JsonProperty("Performance")]
        public string Performance { get; set; }

        public int CompareTo(Team other)
        {
            // Other is NULL
            if (other == null)
                return -1;

            // Points are greater
            if (this.Points > other.Points)
                return -1;
            // Points are lesser
            if (this.Points < other.Points)
                return 1;

            // Points Equal Goals For Equal, Goals Against Equal
            if (this.Points == other.Points && this.GoalsFor == other.GoalsFor && this.GoalsAgainst == other.GoalsAgainst)
                return 0;

            // Points Equal Goals For More, Goals Against More
            if (this.Points == other.Points && this.GoalsFor > other.GoalsFor && this.GoalsAgainst > other.GoalsAgainst)
                return -1;
            // Points Equal Goals For More, Goals Against Equal
            if (this.Points == other.Points && this.GoalsFor > other.GoalsFor && this.GoalsAgainst == other.GoalsAgainst)
                return -1;
            // Points Equal Goals For More, Goals Against Less
            if (this.Points == other.Points && this.GoalsFor > other.GoalsFor && this.GoalsAgainst < other.GoalsAgainst)
                return -1;
            // Points Equal Goals For Equal, Goals Against Less
            if (this.Points == other.Points && this.GoalsFor == other.GoalsFor && this.GoalsAgainst < other.GoalsAgainst)
                return -1;

            // Points Equal Goals For Equal, Goals Against More
            if (this.Points == other.Points && this.GoalsFor == other.GoalsFor && this.GoalsAgainst > other.GoalsAgainst)
                return 1;
            // Points Equal Goals For Less, Goals Against More
            if (this.Points == other.Points && this.GoalsFor < other.GoalsFor && this.GoalsAgainst > other.GoalsAgainst)
                return 1;
            // Points Equal Goals For Less, Goals Against Equal
            if (this.Points == other.Points && this.GoalsFor < other.GoalsFor && this.GoalsAgainst == other.GoalsAgainst)
                return 1;
            // Points Equal Goals For Less, Goals Against Less
            if (this.Points == other.Points && this.GoalsFor < other.GoalsFor && this.GoalsAgainst < other.GoalsAgainst)
                return 1;
            // Else Equal
            else
                return 0;
        }
    }
}
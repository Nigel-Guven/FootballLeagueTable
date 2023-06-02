using FootballLeagueTable.Extensions;
using FootballLeagueTable.JsonObjects;
using FootballLeagueTable.Table;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace FootballLeagueTable
{
    public class Program
    {
        static void Main(string[] args)
        {
            //List teams that are playing in the league
            List<string> teams = new List<string>
                {
                    "Algeria",
                    "Angola",
                    "Austria",
                    "Cameroon",
                    "Canada",
                    "Chile",
                    "Costa Rica",
                    "Czechia",
                    "Ecuador",
                    "Egypt",
                    "Hungary",
                    "Ireland",
                    "Ivory Coast",
                    "Japan",
                    "New Zealand",
                    "Nigeria",
                    "Norway",
                    "Paraguay",
                    "Peru",
                    "Romania",
                    "Saudi Arabia",
                    "Scotland",
                    "Tunisia",
                    "Turkey"
            };

            //Prevent Overwriting each time
            if(DataEx.CheckIfFileIsEmpty(@"../../MatchFiles/LeagueMatches.json"))
            {
                Season season = DataEx.GenerateSeason(teams);
                string jsonPayload = JsonConvert.SerializeObject(season);
                File.WriteAllText(@"../../MatchFiles/LeagueMatches.json", jsonPayload);
            }

            var matchData = JsonEx.LoadMatchesJson();
            var teamData = JsonEx.LoadTeamsJson();

            var season2 = JsonConvert.DeserializeObject<Season>(matchData);
            var table = JsonConvert.DeserializeObject<GroupTable>(teamData);
            MatchEx.CalculateTable(season2, table);
        }
    }
}

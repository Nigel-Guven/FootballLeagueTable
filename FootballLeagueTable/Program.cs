using FootballLeagueTable.JsonObjects;
using FootballLeagueTable.Table;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Data;
using System.IO;

namespace FootballLeagueTable
{
    public class Program
    {
        static void Main(string[] args)
        {
            var matchData = LoadMatchesJson();
            var teamData = LoadTeamsJson();

            var season = JsonConvert.DeserializeObject<Season>(matchData);
            var table = JsonConvert.DeserializeObject<GroupTable>(teamData);

            CalculateTable(season, table);

        }

        private static void CalculateTable(Season season, GroupTable table)
        {
            foreach(Round round in season.Rounds)
            {
                foreach(Match match in round.Matches)
                {
                    //Console.WriteLine(match.HomeTeam + " " + match.HomeTeamScore +  " - " + match.AwayTeamScore + " " + match.AwayTeam);
                    if (match.HomeTeamScore > match.AwayTeamScore)
                    {
                        table.UpdateTableHomeWin(match);
                    }
                    else if (match.HomeTeamScore < match.AwayTeamScore)
                    {
                        table.UpdateTableAwayWin(match);
                    }
                    else
                        table.UpdateTableDraw(match);
                }
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");

                table.SortList();

                table.PrintTable();
            }
        }



        public static string LoadMatchesJson()
        {
            string json = "";
            using (StreamReader r = new StreamReader("../../MatchFiles/GroupB/GroupBMatches.json"))
            {
                json = r.ReadToEnd();
            }

            return json;
        }

        public static string LoadTeamsJson()
        {
            string json = "";
            using (StreamReader r = new StreamReader("../../MatchFiles/GroupB/GroupBTeams.json"))
            {
                json = r.ReadToEnd();
            }

            return json;
        }
    }
}

using FootballLeagueTable.JsonObjects;
using FootballLeagueTable.Table;
using System;

namespace FootballLeagueTable.Extensions
{
    public class MatchEx
    {
        public static void CalculateTable(Season season, GroupTable table)
        {
            foreach (Round round in season.Rounds)
            {
                foreach (Match match in round.Matches)
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
    }
}

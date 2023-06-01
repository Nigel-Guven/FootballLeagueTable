using FootballLeagueTable.JsonObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FootballLeagueTable.Table
{
    public class GroupTable
    {
        [JsonProperty("Table")]
        public List<Team> Teams { get; set; }

        public void UpdateTableHomeWin(Match match)
        {
            var homeTeam = Teams.Find(r => r.TeamName == match.HomeTeam);
            var awayTeam = Teams.Find(r => r.TeamName == match.AwayTeam);

            homeTeam.Points += 3;
            homeTeam.GoalsFor += match.HomeTeamScore;
            homeTeam.GoalsAgainst += match.AwayTeamScore;

            awayTeam.GoalsFor += match.AwayTeamScore;
            awayTeam.GoalsAgainst += match.HomeTeamScore;
        }

        public void UpdateTableAwayWin(Match match)
        {
            var homeTeam = Teams.Find(r => r.TeamName == match.HomeTeam);
            var awayTeam = Teams.Find(r => r.TeamName == match.AwayTeam);
          
            homeTeam.GoalsFor += match.HomeTeamScore;
            homeTeam.GoalsAgainst += match.AwayTeamScore;

            awayTeam.Points += 3;
            awayTeam.GoalsFor += match.AwayTeamScore;
            awayTeam.GoalsAgainst += match.HomeTeamScore;
        }

        public void UpdateTableDraw(Match match)
        {
            var homeTeam = Teams.Find(r => r.TeamName == match.HomeTeam);
            var awayTeam = Teams.Find(r => r.TeamName == match.AwayTeam);

            homeTeam.Points += 1;
            homeTeam.GoalsFor += match.HomeTeamScore;
            homeTeam.GoalsAgainst += match.AwayTeamScore;

            awayTeam.Points += 1;
            awayTeam.GoalsFor += match.AwayTeamScore;
            awayTeam.GoalsAgainst += match.HomeTeamScore;
        }
        public void PrintTable()
        {
            Console.WriteLine("Team || Points || Goals For || Goals Against");
            foreach(Team team in Teams)
            {
                if(team.TeamName.Length >= 12)
                    Console.WriteLine($"{team.TeamName} \t {team.Points,3} {team.GoalsFor,3} {team.GoalsAgainst, 3}");
                else if(team.TeamName.Length > 8)
                    Console.WriteLine($"{team.TeamName} \t {team.Points,3} {team.GoalsFor,3} {team.GoalsAgainst,3}");
                else if (team.TeamName.Length > 6)
                    Console.WriteLine($"{team.TeamName} \t {team.Points,3} {team.GoalsFor,3} {team.GoalsAgainst,3}");
                else
                    Console.WriteLine($"{team.TeamName} \t\t {team.Points,3} {team.GoalsFor,3} {team.GoalsAgainst,3}");
            }
        }

        public void SortList()
        {
            Teams.Sort();
        }
    }
}

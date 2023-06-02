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

            homeTeam.Performance = homeTeam.Performance.Remove(0,1);
            homeTeam.Performance += "W";

            awayTeam.Performance = awayTeam.Performance.Remove(0, 1);
            awayTeam.Performance += "L";

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

            homeTeam.Performance = homeTeam.Performance.Remove(0, 1);
            homeTeam.Performance += "L";

            awayTeam.Performance = awayTeam.Performance.Remove(0, 1);
            awayTeam.Performance += "W";

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

            homeTeam.Performance = homeTeam.Performance.Remove(0, 1);
            homeTeam.Performance += "D";

            awayTeam.Performance = awayTeam.Performance.Remove(0, 1);
            awayTeam.Performance += "D";

            homeTeam.Points += 1;
            homeTeam.GoalsFor += match.HomeTeamScore;
            homeTeam.GoalsAgainst += match.AwayTeamScore;

            awayTeam.Points += 1;
            awayTeam.GoalsFor += match.AwayTeamScore;
            awayTeam.GoalsAgainst += match.HomeTeamScore;
        }
        public void PrintTable(Round round)
        {
            Console.WriteLine("Team || Points || Goals For || Goals Against");
            foreach(Team team in Teams)
            {
                if(team.TeamName.Length >= 12)
                    Console.WriteLine($"{team.TeamName} \t {team.Points,3} {team.GoalsFor,3} {team.GoalsAgainst, 3} \t {team.Performance,3} \t {PrintStatus(team, round),3}");
                else if(team.TeamName.Length > 8)
                    Console.WriteLine($"{team.TeamName} \t {team.Points,3} {team.GoalsFor,3} {team.GoalsAgainst,3} \t {team.Performance,3} \t {PrintStatus(team, round),3}");
                else if (team.TeamName.Length > 6)
                    Console.WriteLine($"{team.TeamName} \t {team.Points,3} {team.GoalsFor,3} {team.GoalsAgainst,3} \t {team.Performance,3} \t {PrintStatus(team, round),3}");
                else
                    Console.WriteLine($"{team.TeamName} \t\t {team.Points,3} {team.GoalsFor,3} {team.GoalsAgainst,3} \t {team.Performance,3} \t {PrintStatus(team, round),3}");
            }
        }

        public string PrintStatus(Team team, Round round)
        {
            int totalRounds = 22;
            int maxPointsLeft = (totalRounds - round.RoundNumber) * 3;

            Console.WriteLine(maxPointsLeft);
            if (team.Points > Teams[1].Points + maxPointsLeft
                && team == Teams[0])
                return "WINS LEAGUE";
            else if (team.Points + maxPointsLeft < Teams[19].Points)
                return "RELEGATED";
            else
                return "";
        }

        public void SortList()
        {
            Teams.Sort();
        }
    }
}

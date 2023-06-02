using FootballLeagueTable.Algorithm;
using FootballLeagueTable.JsonObjects;
using System;
using System.Collections.Generic;
using System.IO;

namespace FootballLeagueTable.Extensions
{
    public class DataEx
    {
        public static Season GenerateSeason(List<string> teams)
        {
            var x = FixtureCreator.ListMatches(teams);
            int i = 1;
            
            List<Round> rounds = new List<Round>();
            foreach (List<Tuple<string, string>> valueX in x)
            {
                Round round = new Round();
                List<Match> matches = new List<Match>();
                foreach (Tuple<string, string> valueY in valueX)
                {
                    Match match = new Match();
                    match.HomeTeam = valueY.Item1;
                    match.AwayTeam = valueY.Item2;
                    match.HomeTeamScore = 0;
                    match.AwayTeamScore = 0;

                    
                    matches.Add(match);
                }
                round.RoundNumber = i;
                round.Matches = matches;
                i++;
                rounds.Add(round);
            }

            Season season = new Season
            {
                Rounds = rounds
            };

            return season;
        }

        public static bool CheckIfFileIsEmpty(string filePath)
        {
            var file = new FileInfo(filePath);
            return file.Length == 0;
        }
    }
}

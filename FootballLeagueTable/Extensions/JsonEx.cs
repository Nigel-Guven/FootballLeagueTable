using System.IO;

namespace FootballLeagueTable.Extensions
{
    public class JsonEx
    {
        public static string LoadMatchesJson()
        {
            string json = "";
            using (StreamReader r = new StreamReader("../../MatchFiles/LeagueMatches.json"))
            {
                json = r.ReadToEnd();
            }

            return json;
        }

        public static string LoadTeamsJson()
        {
            string json = "";
            using (StreamReader r = new StreamReader("../../MatchFiles/LeagueTeams.json"))
            {
                json = r.ReadToEnd();
            }

            return json;
        }
    }
}

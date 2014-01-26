using DataModel.Football;
using System.Collections.Generic;
using System.Text;

namespace EPortfolio.Helpers
{
    public static class FootballHelper
    {
        public static string DisplayPlayerRanking(List<PlayerRanking> playerRankingList)
        {
            StringBuilder str = new StringBuilder();

            str.Append(@"<table class=""table table-bordered"">");
            str.Append(@"<tr><td>Rank</td><td>Player</td><td>Goal</td><td>Match</td></tr>");

            foreach (var item in playerRankingList)
            {
                str.Append(string.Format(@"<tr><td>{0}</td><td><img {1} /> {2}</td><td>{3}</td><td>{4}</td></tr>",
                                         item.Rank, item.Image, item.PlayerName, item.Goal, item.Match));
            }

            str.Append("</table>");

            return str.ToString();
        }

        public static string DisplayTeamRanking(List<TeamRanking> teamRanking)
        {
            StringBuilder str = new StringBuilder();

            str.Append(@"<table class=""table table-bordered"">");
            str.Append(@"<tr><td>Rank</td><td>Team</td><td>Point</td><td>Day</td><td>Diff</td></tr>");

            foreach (var item in teamRanking)
            {
                str.Append(string.Format(@"<tr><td>{0}</td><td><img {1} /> {2}</td><td>{3}</td><td>{4}</td><td>{5}</td></tr>",
                                         item.Rank, item.Image, item.TeamName, item.Point, item.Day, item.Difference));
            }

            str.Append("</table>");

            return str.ToString();
        }

        public static string DisplayTeamResult(List<TeamResult> teamResult)
        {
            StringBuilder str = new StringBuilder();

            str.Append(@"<table class=""table table-bordered"">");

            foreach (var item in teamResult)
            {
                str.Append(string.Format(@"<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>",
                                         item.TeamName1, item.Score, item.TeamName2));
            }

            str.Append("</table>");

            return str.ToString();
        }
    }
}
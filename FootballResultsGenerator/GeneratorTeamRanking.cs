using DataModel.Football;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FootballResultsGenerator
{
    public static class GeneratorTeamRanking
    {
        public static void Generate(Football football, List<string> pageContentList)
        {
            football.teamRankingFrance = GetTeamRanking(pageContentList[5]);
            football.teamRankingEngland = GetTeamRanking(pageContentList[6]);
            football.teamRankingSpain = GetTeamRanking(pageContentList[7]);
            football.teamRankingGermany = GetTeamRanking(pageContentList[8]);
            football.teamRankingItalia = GetTeamRanking(pageContentList[9]);
        }

        private static List<TeamRanking> GetTeamRanking(string pageContent)
        {
            var sectionContent = Regex.Match(pageContent, @"<div id=""CONT"">(.*?)<div id=""col-droite""", RegexOptions.IgnoreCase);

            var teamList = Regex.Matches(sectionContent.Value, @"<strong>(.*?)</strong></a>", RegexOptions.IgnoreCase);
            var imageList = Regex.Matches(sectionContent.Value, @"<img(.*?)>", RegexOptions.IgnoreCase);
            var pointList = Regex.Matches(sectionContent.Value, @"<div class=""points"">(.*?)</div>", RegexOptions.IgnoreCase);
            var dayList = Regex.Matches(sectionContent.Value, @"<div class=""j"">(.*?)</div>", RegexOptions.IgnoreCase);
            var differenceList = Regex.Matches(sectionContent.Value, @"<div class=""diff"">(.*?)</div>", RegexOptions.IgnoreCase);

            List<TeamRanking> teamRankingList = new List<TeamRanking>();

            for (int i = 0; i < teamList.Count; i++)
            {
                teamRankingList.Add(new TeamRanking
                {
                    Rank = i + 1,
                    TeamName = teamList[i].Groups[1].ToString(),
                    Image = imageList[i].Groups[1].ToString(),
                    Point = pointList[i].Groups[1].ToString(),
                    Day = dayList[i].Groups[1].ToString(),
                    Difference = differenceList[i].Groups[1].ToString()
                });
            }

            foreach (var item in teamRankingList)
            {
                item.TeamName = item.TeamName.Remove(0, item.TeamName.IndexOf("<strong>") + 8);
            }

            return teamRankingList;
        }
    }
}
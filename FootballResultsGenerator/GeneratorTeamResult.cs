using DataModel.Football;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FootballResultsGenerator
{
    public static class GeneratorTeamResult
    {
        public static void Generate(Football football, List<string> pageContentList)
        {
            football.resultsFrance = GetResults(pageContentList[0]);
            football.resultsEngland = GetResults(pageContentList[1]);
            football.resultsSpain = GetResults(pageContentList[2]);
            football.resultsGermany = GetResults(pageContentList[3]);
            football.resultsItalia = GetResults(pageContentList[4]);
        }

        private static List<TeamResult> GetResults(string pageContent)
        {
            var sectionContent = Regex.Match(pageContent, @"<div id=""CONT"">(.*?)<div id=""col-droite""", RegexOptions.IgnoreCase);

            var team1List = Regex.Matches(sectionContent.Value, @"<div class=""equipeDom"">(.*?)</div>", RegexOptions.IgnoreCase);
            var team2List = Regex.Matches(sectionContent.Value, @"<div class=""equipeExt"">(.*?)</div>", RegexOptions.IgnoreCase);
            var score = Regex.Matches(sectionContent.Value, @"<div class=""score"">(.*?)</div>", RegexOptions.IgnoreCase);

            List<TeamResult> resultList = new List<TeamResult>();

            for (int i = 0; i < score.Count; i++)
            {
                resultList.Add(new TeamResult
                {
                    TeamName1 = team1List[i].Groups[1].ToString(),
                    TeamName2 = team2List[i].Groups[1].ToString(),
                    Score = score[i].Groups[1].ToString()
                });
            }

            foreach (var item in resultList)
            {
                item.TeamName1 = item.TeamName1.Remove(0, item.TeamName1.IndexOf("class=\"\">") + 9);
                item.TeamName1 = item.TeamName1.Remove(item.TeamName1.IndexOf("</a>"));

                item.TeamName2 = item.TeamName2.Remove(0, item.TeamName2.IndexOf("class=\"\">") + 9);
                item.TeamName2 = item.TeamName2.Remove(item.TeamName2.IndexOf("</a>"));

                item.Score = item.Score.Remove(0, item.Score.IndexOf(">") + 1);
                item.Score = item.Score.Remove(item.Score.IndexOf("</a>"));
            }

            return resultList;
        }
    }
}
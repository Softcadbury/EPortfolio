using Softox.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Softox.Controllers
{
    public class ProjectsController : Controller
    {
        #region Football

        public ActionResult Football()
        {
            List<string> pageContentList = GetPageContentList();

            Football football = new Football();
            InitResults(football, pageContentList);
            InitTeamRanking(football, pageContentList);
            InitPlayerRanking(football, pageContentList);

            return View("Football/Index", football);
        }

        #region Pages task

        private static List<string> GetPageContentList()
        {
            using (HttpClient client = new HttpClient())
            {
                List<Task<string>> pageTaskList = new List<Task<string>>();

                // Results
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-angleterre-resultats.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/ligue-1-resultats.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-espagne-resultats.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-italie-resultats.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-allemagne-resultats.html"));

                // Team ranking
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/ligue-1-classement.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-angleterre-classement.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-espagne-classement.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-italie-classement.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-allemagne-classement.html"));

                // Player ranking
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/FootballClassementChampionnat1760_BUT_1.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/FootballClassementChampionnat1786_BUT_1.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/FootballClassementChampionnat1799_BUT_1.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/FootballClassementChampionnat1814_BUT_1.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/FootballClassementChampionnat1789_BUT_1.html"));

                Task.WaitAll(pageTaskList.ToArray());
                return pageTaskList.Select(t => t.Result).ToList();
            }
        }

        #endregion Pages task

        #region Results

        private static void InitResults(Football football, List<string> pageContentList)
        {
            football.resultsFrance = GetResults(pageContentList[10]);
            football.resultsEngland = GetResults(pageContentList[11]);
            football.resultsSpain = GetResults(pageContentList[12]);
            football.resultsGermany = GetResults(pageContentList[13]);
            football.resultsItalia = GetResults(pageContentList[14]);
        }

        private static List<Result> GetResults(string pageContent)
        {
            var sectionContent = Regex.Match(pageContent, @"<div id=""cont"">(.*?)Chrono"">", RegexOptions.IgnoreCase);

            //var dayList = Regex.Matches(pageContent.Value, @"#<div class=""intitule""><span>(.*?)</span></div>", RegexOptions.IgnoreCase);

            //preg_match_all('#<div class="intitule"><span>(.*?)</span></div>#i', $content[1], $journee);

            //preg_match_all('#class="score">(.*?)</a>#i', $content[1], $score);
            //for ($i=0; $i < count($score[1]); $i++) {
            //    preg_match('#" >(.*?)</a>#i', $score[0][$i], $tmp);
            //    if (count($tmp) == 0)
            //        $score2[$i] = "x-x";
            //    else
            //        $score2[$i] = $tmp[1];
            //}

            //preg_match_all('#class="equipeDom">(.*?)&nbsp;#i', $content[1], $equipe1);
            //for ($i=0; $i < count($equipe1[1]); $i++) {
            //    preg_match('#<img src="(.*?)">#i', $equipe1[0][$i], $tmp);
            //    $equipe1_src[$i] = $tmp[0];

            //    preg_match('#class="">(.*?)&nbsp;#i', str_replace('gagne', '', $equipe1[0][$i]), $tmp);
            //    $equipe1_nom[$i] = $tmp[1];
            //}

            //preg_match_all('#class="equipeExt">(.*?)&nbsp;#i', $content[1], $equipe2);
            //for ($i=0; $i < count($equipe2[1]); $i++) {
            //    preg_match('#<img src="(.*?)">#i', $equipe2[0][$i], $tmp);
            //    $equipe2_src[$i] = $tmp[0];

            //    preg_match('#class="">(.*?)&nbsp;#i', str_replace('gagne', '', $equipe2[0][$i]), $tmp);
            //    $equipe2_nom[$i] = $tmp[1];
            //}

            List<Result> resultList = new List<Result>();

            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Result
                {
                    //da = rankList[i].Groups[1].ToString(),
                });
            }

            return resultList;
        }

        #endregion Results

        #region Team ranking

        private static void InitTeamRanking(Football football, List<string> pageContentList)
        {
            football.teamRankingFrance = GetTeamRanking(pageContentList[0]);
            football.teamRankingEngland = GetTeamRanking(pageContentList[1]);
            football.teamRankingSpain = GetTeamRanking(pageContentList[2]);
            football.teamRankingGermany = GetTeamRanking(pageContentList[3]);
            football.teamRankingItalia = GetTeamRanking(pageContentList[4]);
        }

        private static List<TeamRanking> GetTeamRanking(string pageContent)
        {
            var sectionContent = Regex.Match(pageContent, @"<div id=""cont"">(.*?)<div class=""clear"">", RegexOptions.IgnoreCase);

            var teamList = Regex.Matches(sectionContent.Value, @"html""><strong>(.*?)</strong></a>", RegexOptions.IgnoreCase);
            var pointList = Regex.Matches(sectionContent.Value, @"<div class=""points"">(.*?)</div>", RegexOptions.IgnoreCase);
            var dayList = Regex.Matches(sectionContent.Value, @"<div class=""j"">(.*?)</div>", RegexOptions.IgnoreCase);
            var differenceList = Regex.Matches(sectionContent.Value, @"<div class=""diff"">(.*?)</div>", RegexOptions.IgnoreCase);
            var imageList = Regex.Matches(sectionContent.Value, @"<img(.*?)>", RegexOptions.IgnoreCase);

            List<TeamRanking> teamRankingList = new List<TeamRanking>();

            for (int i = 0; i < teamList.Count; i++)
            {
                teamRankingList.Add(new TeamRanking
                {
                    TeamName = teamList[i].Groups[1].ToString(),
                    Point = pointList[i].Groups[1].ToString(),
                    Day = dayList[i].Groups[1].ToString(),
                    Difference = differenceList[i].Groups[1].ToString(),
                    Image = imageList[i].Groups[1].ToString()
                });
            }

            return teamRankingList;
        }

        #endregion Team ranking

        #region Player ranking

        private static void InitPlayerRanking(Football football, List<string> pageContentList)
        {
            football.playerRankingFrance = GetPlayerRanking(pageContentList[5]);
            football.playerRankingEngland = GetPlayerRanking(pageContentList[6]);
            football.playerRankingSpain = GetPlayerRanking(pageContentList[7]);
            football.playerRankingGermany = GetPlayerRanking(pageContentList[8]);
            football.playerRankingItalia = GetPlayerRanking(pageContentList[9]);
        }

        private static List<PlayerRanking> GetPlayerRanking(string pageContent)
        {
            var sectionContent = Regex.Match(pageContent, @"<div id=""cont"">(.*?)<div class=""clear"">", RegexOptions.IgnoreCase);

            var rankList = Regex.Matches(sectionContent.Value, @"<div class=""rang""><strong>(.*?)</strong></div>", RegexOptions.IgnoreCase);
            var playerList = Regex.Matches(sectionContent.Value, @"html""><strong>(.*?)</strong>", RegexOptions.IgnoreCase);
            var pointList = Regex.Matches(sectionContent.Value, @"<div class=""points"">(.*?)</div>", RegexOptions.IgnoreCase);
            var imageList = Regex.Matches(sectionContent.Value, @"<img(.*?)/>", RegexOptions.IgnoreCase);

            List<PlayerRanking> playerRankingList = new List<PlayerRanking>();

            for (int i = 0; i < 10; i++)
            {
                playerRankingList.Add(new PlayerRanking
                {
                    Rank = rankList[i].Groups[1].ToString(),
                    PlayerName = playerList[i].Groups[1].ToString(),
                    Point = pointList[i * 2].Groups[1].ToString(),
                    Day = pointList[i * 2 + 1].Groups[1].ToString(),
                    Image = imageList[i].Groups[1].ToString()
                });
            }

            return playerRankingList;
        }

        #endregion Player ranking

        #endregion Football

        #region Chat

        public ActionResult Chat()
        {
            return View();
        }

        //public class ChatHub : Hub
        //{
        //    private static List<string> users = new List<string>();

        //    public void Send(string name, string message)
        //    {
        //        //AddMessageinCache(userName, message);
        //        Clients.All.broadcastMessage(name, message);
        //    }

        //    public override Task OnConnected()
        //    {
        //        string clientId = GetClientId();

        //        if (users.IndexOf(clientId) == -1)
        //            users.Add(clientId);

        //        ShowUsersOnLine();

        //        return base.OnConnected();
        //    }

        //    public override Task OnReconnected()
        //    {
        //        string clientId = GetClientId();

        //        if (users.IndexOf(clientId) == -1)
        //            users.Add(clientId);

        //        ShowUsersOnLine();

        //        return base.OnReconnected();
        //    }

        //    public override Task OnDisconnected()
        //    {
        //        string clientId = GetClientId();

        //        if (users.IndexOf(clientId) > -1)
        //            users.Remove(clientId);

        //        ShowUsersOnLine();

        //        return base.OnDisconnected();
        //    }

        //    private string GetClientId()
        //    {
        //        string clientId = "";

        //        if (!(Context.QueryString["clientId"] == null))
        //            clientId = Context.QueryString["clientId"].ToString();

        //        if (clientId.Trim() == "")
        //            clientId = Context.ConnectionId;

        //        return clientId;
        //    }

        //    public void ShowUsersOnLine()
        //    {
        //        Clients.All.showUsersOnLine(users);
        //    }
        //}

        #endregion Chat
    }
}
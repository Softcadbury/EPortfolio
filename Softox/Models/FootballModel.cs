using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Softox.Models
{
    public class Football
    {
        public List<TeamRanking> teamRankingFrance { get; set; }
        public List<TeamRanking> teamRankingEngland { get; set; }
        public List<TeamRanking> teamRankingSpain { get; set; }
        public List<TeamRanking> teamRankingItalia { get; set; }
        public List<TeamRanking> teamRankingGermany { get; set; }

        public List<PlayerRanking> playerRankingFrance { get; set; }
        public List<PlayerRanking> playerRankingEngland { get; set; }
        public List<PlayerRanking> playerRankingSpain { get; set; }
        public List<PlayerRanking> playerRankingItalia { get; set; }
        public List<PlayerRanking> playerRankingGermany { get; set; }

        public List<Result> resultsFrance { get; set; }
        public List<Result> resultsEngland { get; set; }
        public List<Result> resultsSpain { get; set; }
        public List<Result> resultsItalia { get; set; }
        public List<Result> resultsGermany { get; set; }
    }

    public class TeamRanking
    {
        public string TeamName { get; set; }
        public string Point { get; set; }
        public string Day { get; set; }
        public string Difference { get; set; }
        public string Image { get; set; }
    }

    public class PlayerRanking
    {
        public string Rank { get; set; }
        public string PlayerName { get; set; }
        public string Point { get; set; }
        public string Day { get; set; }
        public string Image { get; set; }
    }

    public class Result
    {
        public string TeamName1 { get; set; }
        public string Point1 { get; set; }
        public string TeamName2 { get; set; }
        public string Point2 { get; set; }
        public string Score { get; set; }
    }
}
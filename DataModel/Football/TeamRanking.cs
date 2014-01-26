using System;

namespace DataModel.Football
{
    [Serializable]
    public class TeamRanking
    {
        public string TeamName { get; set; }
        public string Image { get; set; }
        public int Rank { get; set; }
        public string Point { get; set; }
        public string Day { get; set; }
        public string Difference { get; set; }
    }
}
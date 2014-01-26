using System;

namespace DataModel.Football
{
    [Serializable]
    public class TeamResult
    {
        public string TeamName1 { get; set; }
        public string TeamName2 { get; set; }
        public string Score { get; set; }
    }
}
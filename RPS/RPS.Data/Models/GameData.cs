using System;
using System.Collections.Generic;
using System.Text;

namespace RPS.Data.Models
{
    public class GameData
    {
        public int ID { get; set; }

        public int PlayerScore { get; set; }

        public int ComputerScore { get; set; }

        public int PointsToWin { get; set; }

        public string MostUsedItem { get; set; }

        public int MostUsedAmount { get; set; }

        public int numberOfTurns { get; set; }
    }
}

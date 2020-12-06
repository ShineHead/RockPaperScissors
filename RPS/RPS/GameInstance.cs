using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static RPS.RPSGame;

namespace RPS
{

    // HELPER CLASS
    class GameInstance
    {

        public int rockCount = 0;
        public int paperCount = 0;
        public int scissorsCount = 0;
        public int numberOfTurns = 0;
        public int lizardCount = 0;
        public int spockCount = 0;

        public void resetStats()
        {
            rockCount = 0;
            paperCount = 0;
            scissorsCount = 0;
            lizardCount = 0;
            spockCount = 0;
            numberOfTurns = 0;
        }

        public int incrementTurns()
        {
            numberOfTurns++;
            return numberOfTurns;
        }

        public void incrementStats(Hand handStats)
        {
            if (handStats == Hand.Rock)
            {
                rockCount++;
            }
            else if (handStats == Hand.Scissors)
            {
                scissorsCount++;
            }
            else if (handStats == Hand.Paper)
            {
                paperCount++;
            }
            else if (handStats == Hand.Lizard)
            {
                lizardCount++;
            }
            else if (handStats == Hand.Spock)
            {
                spockCount++;
            }
        }


        public void findMostUsed(ref int maxValue, ref string maxKey)
        {

            Dictionary<string, int> mostUsedDictionary = new Dictionary<string, int>()
            {
              { "ROCK" , rockCount },
              { "PAPER" , paperCount },
              { "SCISSORS" , scissorsCount },
              { "LIZARD" , lizardCount },
              { "SPOCK" , spockCount }
            };

            var maximumValue = mostUsedDictionary.Values.Max();
            var maximumKey = mostUsedDictionary.Keys.Max();

            maxValue = maximumValue;
            maxKey = maximumKey;

        }



    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RPS
{
    // HELPER CLASS
    class MessageManager
    {
        // Program class
        public string invalidInput = "Invalid input. Please re-enter your selection.";
        public string messageError = "Unexpected Error";
        public string letsPlay = "Let's play: Rock, Paper, Scissors, Lizard, Spock! (y/n)";
        public string selectPoints = "Select how many points are needed to win the game.";
        public string start = "OK, Lets Start...";
        public string pointsSelected = "You've selected {0} points to win the game. \n";

        // RPSGame class
        public string turnNumber = "Turn number: {0}...";
        public string letsContinue = "OK, let's continue..";
        public string messagePlayerWon = "Player has won the match! Well played!";
        public string messageComputerWon = "Computer has won the match! Too bad!";
        public string messageMostUsedResource = "{0} was the most used resource, and was called a total of {1} times.\n";
        public string messageNumberTurns = "There were {0} turns.";
        public string messageThanks = "Thanks for playing!";

        public string transmitting = "Transmitting following scores: PlayerScore {0}, ComputerScore {1}, \n PointsToWin {2}, MostUsedItem {3}, MostUsedAmount {4}.";
        public string playAgain = "\n Would you like to play again? (y or n)";

        public string playerSelection = "Player selected: {0}.";
        public string computerSelection = "Computer selected: {0}.\n ";
        public string playerPoint = "{0} {1} {2}. Player Scores Point!";
        public string computerPoint = "{0} {1} {2}. Computer Scores Point!";
        public string tie = "It's a tie this time. No points scored!";
        public string displayScore = "Here's the score: Player {0}, Computer {1}. {2} points needed to win the game.\n";

        public void Screen()
        {
            Console.WriteLine("R - Rock");
            Console.WriteLine("P - Paper");
            Console.WriteLine("S - Scissors");
            Console.WriteLine("L - Lizard");
            Console.WriteLine("V - Vulcan Spock");
            Console.WriteLine("Please make your selection");
        }

        public void updateMessageStats(int computerHand, int playerHand, int pointsToWin)
        {
        }
    }
}

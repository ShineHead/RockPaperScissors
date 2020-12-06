using System;
using System.Collections.Generic;
using System.Text;
using RPS.Data;
using RPS.Data.Models;
using RPS.Data.Repository;

namespace RPS
{
    class RPSGame
    {
        // PROPERTIES
        public enum Hand { Rock = 1, Paper, Scissors, Lizard, Spock };
        public enum Outcome { Win, Lose, Tie };
        public Hand ComputerHand { get; set; } // Set enums for Player and Computer
        public Hand PlayerHand { get; set; }
        public char userSelection { get; set; } // When typing rock paper or scissors
        public int pointsToWin;
        public int playerScore;
        public int computerScore;
        int mostFrequentNumber;
        string mostUsedTool;
        int numberOfTurns;
        char response;
        public string verb = "beats";
        Random rand = new Random();
        GameInstance GameInstance = new GameInstance();
        MessageManager Message = new MessageManager();

        public void PlayGame()
        {
            resetPoints();
            Console.Clear();

            // PLAY AS LONG AS SCORE HAS NOT BEEN REACHED BY EITHER THE PLAYER OR THE COMPUTER
            while (playerScore < pointsToWin && computerScore < pointsToWin)
            {
                numberOfTurns = GameInstance.incrementTurns();
                Console.WriteLine(Message.turnNumber, numberOfTurns);
                Message.Screen(); // DISPLAY LIST OF OPTIONS VIA CONSOLE
                userSelection = Convert.ToChar(Console.ReadLine());

                // PLAYER TURN
                getUserHand();
                GameInstance.incrementStats(PlayerHand);

                // COMPUTER TURN
                ComputerHand = (Hand)rand.Next(1, 6);
                GameInstance.incrementStats(ComputerHand);

                // UPDATE USER WITH SCORE
                updateMessageStats();
                
                // IF POINTS CAP NOT YET REACHED, CONTINUE PLAYING
                if (playerScore < pointsToWin && computerScore < pointsToWin)
                {
                    Console.WriteLine(Message.letsContinue);
                    Console.ReadLine();
                }

                // OTHERWISE END THE GAME
                else
                {
                    if (playerScore > computerScore)
                    {
                        Console.WriteLine(Message.messagePlayerWon);
                    }
                    else if (computerScore > playerScore)
                    {
                        Console.WriteLine(Message.messageComputerWon);
                    }

                    // Receive most frequent items used
                    GameInstance.findMostUsed(ref mostFrequentNumber, ref mostUsedTool);
                    Console.WriteLine(Message.messageMostUsedResource, mostUsedTool, mostFrequentNumber);
                    Console.ReadLine();

                    // END OF GAME MESSAGES
                    Console.WriteLine(Message.messageNumberTurns, numberOfTurns);
                    Console.WriteLine(Message.messageThanks);
                    Console.ReadLine();
                }
            }

            //  Upload data to database (Issues here, unable to access repositories and databases through injection. Work in progress.) 
            var GameData = new GameData();
            transmitGameData(ref GameData);

            // MORE END OF GAME MESSAGES
            Console.WriteLine(Message.transmitting,
            GameData.PlayerScore, GameData.ComputerScore, GameData.PointsToWin, GameData.MostUsedItem, GameData.MostUsedAmount);

            GameInstance.resetStats(); // In case of new game

            Console.WriteLine(Message.playAgain);
            response = Convert.ToChar(Console.ReadLine());

            if (Char.ToUpper(response) == 'Y')
            {
                PlayGame(); // RESTART GAMe
            }
            
            Console.Clear();

            // END GAME
        }


        // HELPER FUNCTIONS
        public void setPointsToWin(int userPointsSelection)
        {
            pointsToWin = userPointsSelection;
        }

        public bool validateResponse(char response)
        {
            if (Char.ToUpper(response) != 'Y' && Char.ToUpper(response) != 'N')
            {
                return false;
            }
            return true;
        }

        public bool validateDigitResponse(char response)
        {
            if (Char.IsDigit(response))
            {
                return true;
            }
            return false;
        }

        public Hand getUserHand()
        {
            while (!validateSelection())
            {
                Console.Clear();
                Console.WriteLine(Message.invalidInput);
                Message.Screen();
                userSelection = Convert.ToChar(Console.ReadLine());
            }

            switch (Char.ToUpper(userSelection))
            {
                case 'R':
                    PlayerHand = Hand.Rock;
                    break;
                case 'P':
                    PlayerHand = Hand.Paper;
                    break;
                case 'S':
                    PlayerHand = Hand.Scissors;
                    break;
                case 'L':
                    PlayerHand = Hand.Lizard;
                    break;
                case 'V':
                    PlayerHand = Hand.Spock;
                    break;
                default:
                    throw new Exception(Message.messageError);
            }
            return PlayerHand;
        }

        public Outcome DetermineRoundWon()
        {

            // Player winning options

            // SCISSORS
            if (PlayerHand == Hand.Scissors && ComputerHand == Hand.Paper)
            {
                verb = "cuts";
                return Outcome.Win;
            }
            else if (PlayerHand == Hand.Scissors && ComputerHand == Hand.Lizard)
            {
                verb = "decapitates";
                return Outcome.Win;
            }

            // ROCK
            else if(PlayerHand == Hand.Rock && ComputerHand == Hand.Scissors)
            {
                verb = "smashes";
                return Outcome.Win;
            }
            else if (PlayerHand == Hand.Rock && ComputerHand == Hand.Lizard)
            {
                verb = "crushes";
                return Outcome.Win;
            }

            // PAPER
            else if (PlayerHand == Hand.Paper && ComputerHand == Hand.Rock)
            {
                verb = "covers";
                return Outcome.Win;
            }
            else if (PlayerHand == Hand.Paper && ComputerHand == Hand.Spock)
            {
                verb = "disproves";
                return Outcome.Win;
            }

            // LIZARD
            else if (PlayerHand == Hand.Lizard && ComputerHand == Hand.Paper)
            {
                verb = "eats";
                return Outcome.Win;
            }
            else if (PlayerHand == Hand.Lizard && ComputerHand == Hand.Spock)
            {
                verb = "poisons";
                return Outcome.Win;
            }


            // SPOCK
            else if (PlayerHand == Hand.Spock && ComputerHand == Hand.Rock)
            {
                verb = "vaporizes";
                return Outcome.Win;
            }
            else if (PlayerHand == Hand.Spock && ComputerHand == Hand.Scissors)
            {
                verb = "smashes";
                return Outcome.Win;
            }

            // Player losing options
            // SCISSORS
            else if (PlayerHand == Hand.Scissors && ComputerHand == Hand.Rock)
            {
                verb = "smashes";
                return Outcome.Lose;
                
            }
            else if (PlayerHand == Hand.Scissors && ComputerHand == Hand.Spock)
            {
                verb = "smashes";
                return Outcome.Lose;
            }

            // ROCK
            else if (PlayerHand == Hand.Rock && ComputerHand == Hand.Paper)
            {
                verb = "covers";
                return Outcome.Lose;
            }
            else if (PlayerHand == Hand.Rock && ComputerHand == Hand.Spock)
            {
                verb = "vaporizes";
                return Outcome.Lose;
            }

            // PAPER
            else if (PlayerHand == Hand.Paper && ComputerHand == Hand.Scissors)
            {
                verb = "cuts";
                return Outcome.Lose;
            }
            else if (PlayerHand == Hand.Paper && ComputerHand == Hand.Lizard)
            {
                verb = "eats";
                return Outcome.Lose;
            }

            // LIZARD
            else if (PlayerHand == Hand.Lizard && ComputerHand == Hand.Rock)
            {
                verb = "crushes";
                return Outcome.Lose;
            }
            else if (PlayerHand == Hand.Lizard && ComputerHand == Hand.Scissors)
            {
                verb = "decapitates";
                return Outcome.Lose;
            }

            // SPOCK
            else if (PlayerHand == Hand.Spock && ComputerHand == Hand.Paper)
            {
                verb = "disproves";
                return Outcome.Lose;
            }
            else if (PlayerHand == Hand.Spock && ComputerHand == Hand.Lizard)
            {
                verb = "poisons";
                return Outcome.Lose;
            }

            return Outcome.Tie;
        }

        private bool validateSelection()
        {
            char value = Char.ToUpper(userSelection);
            
            if(value != 'R' && value != 'P' && value != 'S' && value != 'L' && value != 'V')
            {
                return false;
            }

            return true;
        }

        public void updateMessageStats()
        {
            Console.Clear();
            Console.WriteLine(Message.playerSelection, PlayerHand);
            Console.WriteLine(Message.computerSelection, ComputerHand);

            if (DetermineRoundWon() == Outcome.Win)
            {
                playerScore++;
                Console.WriteLine(Message.playerPoint, PlayerHand, verb, ComputerHand);
            }

            else if (DetermineRoundWon() == Outcome.Lose)
            {
                computerScore++;
                Console.WriteLine(Message.computerPoint, ComputerHand, verb, PlayerHand);
            }

            else
            {
                Console.WriteLine(Message.tie);
            }

            Console.WriteLine(Message.displayScore, playerScore, computerScore, pointsToWin);
        }

        public void transmitGameData(ref GameData gameData)
        {
            gameData.PlayerScore = playerScore;
            gameData.ComputerScore = computerScore;
            gameData.PointsToWin = pointsToWin;
            gameData.MostUsedAmount = mostFrequentNumber;
            gameData.MostUsedItem = mostUsedTool;
            gameData.numberOfTurns = numberOfTurns;
        }

        public void resetPoints()
        {
            playerScore = 0;
            computerScore = 0;
        }

    }
}

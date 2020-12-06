using System;

namespace RPS
{
    class Program
    {
        static void Main(string[] args)
        {

            RPSGame game = new RPSGame(); // Game object
            MessageManager message = new MessageManager(); // Message library
            char response;
            char numberOfPointsSetter;
            int numberOfPointsInteger;
            
            Console.WriteLine(message.letsPlay);
            response = Convert.ToChar(Console.ReadLine());

            while(game.validateResponse(response) == false)
            {
                Console.WriteLine(message.invalidInput);
                response = Convert.ToChar(Console.ReadLine());
            }

            if (Char.ToUpper(response) == 'Y')
            {
                // SET NUMBER OF TURNS PER MATCH
                Console.WriteLine(message.selectPoints);
                numberOfPointsSetter = Convert.ToChar(Console.ReadLine());

                while (game.validateDigitResponse(numberOfPointsSetter) == false)
                {
                    Console.WriteLine(message.invalidInput);
                    numberOfPointsSetter = Convert.ToChar(Console.ReadLine());
                }

                numberOfPointsInteger = (int)Char.GetNumericValue(numberOfPointsSetter); // convert to integer             
                game.setPointsToWin(numberOfPointsInteger); // NUMBERS ARE SET HERE WITHIN THE RPS GAME OBJECT

                // GENERAL MESSAGES FOR THE USER
                Console.Clear();
                Console.WriteLine(message.pointsSelected, numberOfPointsSetter);
                Console.WriteLine(message.start);
                Console.ReadLine();
                Console.Clear();

                // START GAME
                game.PlayGame();
            }

            Console.WriteLine("Exiting application.");
            Console.ReadLine(); 
        }



    }
}

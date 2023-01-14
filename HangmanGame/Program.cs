using Newtonsoft.Json;

namespace HangmanGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Introduction();

            var figure = new HangmanFigure();
            var game = new HangmanGame(GetRandomWord());

            while (!game.IsWon() && !game.IsLost())
            {
                Console.WriteLine(game.GetCurrentWord());
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Remaining guesses: {game.GetRemainingGuesses()}");
                Console.ResetColor();

                Console.Write("Guess a letter: ");
                char letter = Console.ReadLine()[0];

                bool correctGuess = game.Guess(letter);
                if (correctGuess)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct!");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Incorrect.");
                    Console.Clear();
                    figure.DrawNextPart();
                }
            }

            if (game.IsWon())
            {
                Console.WriteLine("You won!");
            }
            else
            {
                Console.WriteLine("You lost.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The correct word was: " + game.word);
                Console.ResetColor();
            }
        }

        public static void Introduction()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" .----------------.  .----------------.  .-----------------. .----------------.  .----------------.  .----------------.  .-----------------.\r\n| .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |\r\n| |  ____  ____  | || |      __      | || | ____  _____  | || |    ______    | || | ____    ____ | || |      __      | || | ____  _____  | |\r\n| | |_   ||   _| | || |     /  \\     | || ||_   \\|_   _| | || |  .' ___  |   | || ||_   \\  /   _|| || |     /  \\     | || ||_   \\|_   _| | |\r\n| |   | |__| |   | || |    / /\\ \\    | || |  |   \\ | |   | || | / .'   \\_|   | || |  |   \\/   |  | || |    / /\\ \\    | || |  |   \\ | |   | |\r\n| |   |  __  |   | || |   / ____ \\   | || |  | |\\ \\| |   | || | | |    ____  | || |  | |\\  /| |  | || |   / ____ \\   | || |  | |\\ \\| |   | |\r\n| |  _| |  | |_  | || | _/ /    \\ \\_ | || | _| |_\\   |_  | || | \\ `.___]  _| | || | _| |_\\/_| |_ | || | _/ /    \\ \\_ | || | _| |_\\   |_  | |\r\n| | |____||____| | || ||____|  |____|| || ||_____|\\____| | || |  `._____.'   | || ||_____||_____|| || ||____|  |____|| || ||_____|\\____| | |\r\n| |              | || |              | || |              | || |              | || |              | || |              | || |              | |\r\n| '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |\r\n '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------' ");
            Console.WriteLine("Would you like to play a game? Press ENTER to begin!");
            Console.ReadLine();
            Console.ResetColor();
            Console.Clear();
        }

        static string GetRandomWord()
        {
            string[] words = { "apple", "banana", "cat", "dog", "elephant", "flower", "guitar", "hat", "igloo", "jacket", "kangaroo", "lion", "moon", "nest", "ocean", "penguin", "queen", "rabbit", "sun", "truck" };
            Random rnd = new Random();
            return words[rnd.Next(0, words.Length)];
        }
    }


}
using Newtonsoft.Json;

namespace HangmanGame
{
    class Program
    {
        static void Main(string[] args)
        {
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

        static string GetRandomWord()
        {
            string[] words = { "apple", "banana", "cat", "dog", "elephant", "flower", "guitar", "hat", "igloo", "jacket", "kangaroo", "lion", "moon", "nest", "ocean", "penguin", "queen", "rabbit", "sun", "truck" };
            Random rnd = new Random();
            return words[rnd.Next(0, words.Length)];
        }
    }


}
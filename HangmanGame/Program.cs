﻿using Newtonsoft.Json;

namespace HangmanGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Introduction();

            var figure = new HangmanFigure();
            var game = new HangmanGame(GetRandomWord());

            while (!game.GameIsWon() && !game.GameIsLost())
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

            if (game.GameIsWon())
            {
                Console.Clear();
                Console.ForegroundColor= ConsoleColor.Green;
                Congrats();
                Console.WriteLine("You won!");
                Console.ResetColor();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                GameOverNoose();
                Console.WriteLine("You lost.");                
                Console.WriteLine("The correct word was: " + game._word);
                Console.ResetColor();
            }
        }

        static string GetRandomWord()
        {
            string[] words = { "apple", "banana", "cat", "dog", "elephant", "flower", "guitar", "hat", "igloo", "jacket", "kangaroo", "lion", "moon", "nest", "ocean", "penguin", "queen", "rabbit", "sun", "truck" };
            Random rnd = new Random();
            return words[rnd.Next(0, words.Length)];
        }
#region ASCII ARTWORK
        public static void Introduction()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" .----------------.  .----------------.  .-----------------. .----------------.  .----------------.  .----------------.  .-----------------.\r\n| .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |\r\n| |  ____  ____  | || |      __      | || | ____  _____  | || |    ______    | || | ____    ____ | || |      __      | || | ____  _____  | |\r\n| | |_   ||   _| | || |     /  \\     | || ||_   \\|_   _| | || |  .' ___  |   | || ||_   \\  /   _|| || |     /  \\     | || ||_   \\|_   _| | |\r\n| |   | |__| |   | || |    / /\\ \\    | || |  |   \\ | |   | || | / .'   \\_|   | || |  |   \\/   |  | || |    / /\\ \\    | || |  |   \\ | |   | |\r\n| |   |  __  |   | || |   / ____ \\   | || |  | |\\ \\| |   | || | | |    ____  | || |  | |\\  /| |  | || |   / ____ \\   | || |  | |\\ \\| |   | |\r\n| |  _| |  | |_  | || | _/ /    \\ \\_ | || | _| |_\\   |_  | || | \\ `.___]  _| | || | _| |_\\/_| |_ | || | _/ /    \\ \\_ | || | _| |_\\   |_  | |\r\n| | |____||____| | || ||____|  |____|| || ||_____|\\____| | || |  `._____.'   | || ||_____||_____|| || ||____|  |____|| || ||_____|\\____| | |\r\n| |              | || |              | || |              | || |              | || |              | || |              | || |              | |\r\n| '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |\r\n '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------' ");
            Console.WriteLine("Would you like to play a game? Press ENTER to begin!");
            Console.ReadLine();
            Console.ResetColor();
            Console.Clear();
        }

        public static void GoodJob()
        {
            Console.WriteLine("┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌\r\n┌┌┌┌┌┌┌┌┌┌┌█████┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌\r\n┌┌┌┌┌┌┌┌┌┌███████┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌\r\n┌┌┌┌┌┌┌┌┌███┌┌┌██┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌\r\n┌┌┌┌┌┌┌┌┌██┌┌┌┌██┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌\r\n┌┌┌┌┌┌┌┌███┌┌┌┌███┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌\r\n┌┌┌┌┌┌┌┌███┌┌┌┌███┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌\r\n┌┌┌┌┌┌┌┌┌██┌┌┌┌┌███┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌\r\n┌┌┌┌┌┌┌┌┌███┌┌┌┌┌███┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌\r\n┌┌┌┌┌┌┌┌┌┌███┌┌┌┌┌████┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌\r\n┌┌┌┌┌┌┌┌┌┌┌██┌┌┌┌┌┌████┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌\r\n┌┌┌┌┌┌┌┌┌┌┌███┌┌┌┌┌┌┌███┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌\r\n┌┌┌┌┌┌┌┌┌┌┌┌███┌┌┌┌┌┌┌███┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌\r\n┌┌┌┌┌┌┌┌┌┌┌┌███┌┌┌┌┌┌┌┌███┌┌┌┌┌┌┌┌┌┌┌┌┌┌\r\n┌┌┌┌┌┌┌┌┌┌┌┌┌██┌┌┌┌┌┌┌┌┌┌███┌┌┌┌┌┌┌┌┌┌┌┌\r\n┌┌┌┌┌┌┌┌┌███┌███┌┌┌┌┌┌┌┌┌┌██┌┌┌┌┌┌┌┌┌┌┌┌\r\n┌┌┌┌████████████┌┌┌┌┌┌┌┌┌┌┌███┌┌┌┌┌┌┌┌┌┌\r\n┌┌████████┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌███┌┌┌┌┌┌┌┌┌\r\n┌███┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌█████████┌┌\r\n███┌┌┌┌█████████┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌█████┌\r\n██┌┌┌███████┌████┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌███┌\r\n██┌┌┌┌███┌┌┌┌┌┌┌███┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌██┌\r\n███┌┌┌┌┌┌┌┌┌┌┌█████┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌██┌\r\n┌███┌┌┌┌┌┌┌████████┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌██┌\r\n┌┌████████████┌┌┌████┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌██┌\r\n┌███┌██████┌┌┌┌┌┌┌████┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌██┌\r\n┌███┌┌┌┌┌┌┌┌┌┌┌██████┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌██┌\r\n┌┌████┌████┌██████████┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌██┌\r\n┌┌┌████████████┌┌┌┌┌███┌┌┌┌┌┌┌┌┌┌┌┌┌███┌\r\n┌┌┌┌██┌┌┌┌┌┌┌┌┌┌┌███████┌┌┌┌┌┌┌███████┌┌\r\n┌┌┌┌████┌┌┌┌┌┌████████┌┌┌┌┌┌┌┌████████┌┌\r\n┌┌┌┌┌████████████┌┌┌███┌┌┌┌┌███┌┌┌┌┌┌┌┌┌\r\n┌┌┌┌┌┌┌┌███┌█┌█┌┌┌┌┌┌███┌┌┌███┌┌┌┌┌┌┌┌┌┌\r\n┌┌┌┌┌┌┌┌███┌┌┌┌┌┌█████┌┌█████┌┌┌┌┌┌┌┌┌┌┌\r\n┌┌┌┌┌┌┌┌┌██████████████████┌┌┌┌┌┌┌┌┌┌┌┌┌\r\n┌┌┌┌┌┌┌┌┌┌██████████████┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌\r\n┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌┌");
        }

        public static void Congrats()
        {
            Console.WriteLine("   ___     ___    _  _     ___     ___     ___    _____    ___   \r\n  / __|   / _ \\  | \\| |   / __|   | _ \\   /   \\  |_   _|  / __|  \r\n | (__   | (_) | | .` |  | (_ |   |   /   | - |    | |    \\__ \\  \r\n  \\___|   \\___/  |_|\\_|   \\___|   |_|_\\   |_|_|   _|_|_   |___/  \r\n_|\"\"\"\"\"|_|\"\"\"\"\"|_|\"\"\"\"\"|_|\"\"\"\"\"|_|\"\"\"\"\"|_|\"\"\"\"\"|_|\"\"\"\"\"|_|\"\"\"\"\"| \r\n\"`-0-0-'\"`-0-0-'\"`-0-0-'\"`-0-0-'\"`-0-0-'\"`-0-0-'\"`-0-0-'\"`-0-0-' ");
        }
        public static void GameOverNoose()
        {
            Console.WriteLine("     |/|\r\n     |/|\r\n     |/|\r\n     |/|\r\n     |/|\r\n     |/|\r\n     |/| /¯)\r\n     |/|/\\/\r\n     |/|\\/\r\n    (¯¯¯)\r\n    (¯¯¯)\r\n    (¯¯¯)\r\n    (¯¯¯)\r\n    (¯¯¯)\r\n    /¯¯/\\\r\n   / ,^./\\\r\n  / /   \\/\\\r\n / /     \\/\\\r\n( (       )/)\r\n| |       |/|\r\n| |       |/|\r\n| |       |/|\r\n( (       )/)\r\n \\ \\     / /\r\n  \\ `---' /\r\n   `-----'    \r\n\r\r\n\r\n");
        }
#endregion

    }


}
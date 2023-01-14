using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame
{
    class HangmanFigure
    {
        private int partsDrawn;
        private readonly string[] parts =
        {
        "   +---+\n   |   |\n       |\n       |\n       |\n       |\n=========",
        "   +---+\n   |   |\n   O   |\n       |\n       |\n       |\n=========",
        "   +---+\n   |   |\n   O   |\n   |   |\n       |\n       |\n=========",
        "   +---+\n   |   |\n   O   |\n  /|   |\n       |\n       |\n=========",
        "   +---+\n   |   |\n   O   |\n  /|\\ |\n       |\n       |\n=========",
        "   +---+\n   |   |\n   O   |\n  /|\\ |\n  /    |\n       |\n=========",
        "   +---+\n   |   |\n   O   |\n  /|\\ |\n  / \\ |\n       |\n========="
    };

        public void DrawNextPart()
        {
            partsDrawn++;
            Console.WriteLine(parts[partsDrawn - 1]);
        }
    }

}

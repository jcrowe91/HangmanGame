using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame
{
    class HangmanGame
    {
        private string currentWord;
        private int remainingGuesses;
        public string word;
        private HashSet<char> guessedLetters;

        public HangmanGame(string _word)
        {
            word = _word;
            currentWord = new string('_', _word.Length);
            remainingGuesses = 7;
            guessedLetters = new HashSet<char>();
        }



        public bool Guess(char letter)
        {
            if (guessedLetters.Contains(letter))
            {
                return false;
            }
            guessedLetters.Add(letter);

            if (word.Contains(letter))
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == letter)
                    {
                        currentWord = currentWord.Remove(i, 1).Insert(i, letter.ToString());
                    }
                }
                return true;
            }
            else
            {
                remainingGuesses--;
                return false;
            }
        }

        public bool IsWon()
        {
            return currentWord == word;
        }

        public bool IsLost()
        {
            return remainingGuesses == 0;
        }

        public string GetCurrentWord()
        {
            return currentWord;
        }

        public int GetRemainingGuesses()
        {
            return remainingGuesses;
        }
    }
}

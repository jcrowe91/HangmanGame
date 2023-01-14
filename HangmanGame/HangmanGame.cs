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
        public string _word;
        private HashSet<char> guessedLetters;

        public HangmanGame(string word)
        {
            _word = word;
            currentWord = new string('_', word.Length);
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

            if (_word.Contains(letter))
            {
                for (int i = 0; i < _word.Length; i++)
                {
                    if (_word[i] == letter)
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
            return currentWord == _word;
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

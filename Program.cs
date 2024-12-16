using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Requirements
 * Random Word pulled from a file (5 letters) (X)
 * User Input (5 letters) (X)
 * Input restrictions (5 letters) (Bonus: No numbers, No special characters)
 * Check against the word for correct letters
 * Counter (max 6 tries), TriesLeft, Possibility to lose
 * Possibility to win
 * Seperate each letter between words
 * Red for incorrect, Green for correct, Yellow for correct letter in wrong spot
 * General Loop for everything
 * Loop for the game rounds 
 * Safecheck to only be able to type in the same word once
 * Checking whether word is in the dictionary
 * Playername for leaderboard
 * Draw the game board
 */
namespace Wordle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WordleGame Wordle = new WordleGame();
            Wordle.StartMatch();
        }
    }
}

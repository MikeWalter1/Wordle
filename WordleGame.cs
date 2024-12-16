using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Wordle
{
    internal class WordleGame
    {
        List<string> Board = new List<string>();
        string CurrentWord = "";

        int maxTries = 6;
        public WordleGame()
        {
        }

        public void StartMatch()
        {
            Console.WriteLine("Welcome to Wordle!");
            CurrentWord = GetRandomWordWith5Letters();
            StartNewBoard();
            DrawBoard();

            // Rounds
            for (int currentTry = 0; currentTry < maxTries; currentTry++)
            {
                string userInput = GetUserInput();
                AssignColorBasedOnPositionCheck(userInput);
                Board[currentTry] = userInput;
                DrawBoard();
                CheckCondition(userInput, currentTry);
                Console.WriteLine("Current try: " + currentTry + " word: " + CurrentWord);
            }


        }

        private void AssignColorBasedOnPositionCheck(string word)
        {
            bool isLetterInWord = false;
            // Check if letter is on the word at all

            //Console.WriteLine(CurrentWord);
            //Console.WriteLine(CurrentWord.Length);

            int letterIndex = 0;
            if (letterIndex >= CurrentWord.Length)
            {
                return;
            }
            foreach (char letter in word)
            {
                // GREEN
                if (letter == CurrentWord[letterIndex])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(letter);
                    Console.ResetColor();
                    letterIndex++;
                    continue;
                }

                // YELLOW
                isLetterInWord = CurrentWord.Contains(letter);
                if (isLetterInWord)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(letter);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(letter);
                    Console.ResetColor();   
                }
                letterIndex++;
            }
            Console.Write("\n");
        }

        void CheckCondition(string userInput, int currentTry)
        {
            if(CurrentWord == userInput)
            {
                Console.WriteLine("You win!");
            }
            else
            {
                if (currentTry +1 == maxTries)
                {
                    Console.WriteLine("You lose!");
                }
            }
        }

        string GetRandomWordWith5Letters()
        {
            string[] words = { "apple", "elder", "dates" };
            Random random = new Random();
            int index = random.Next(words.Length);
            string word = words[index];

            return word.ToUpper();
        }
        
        string GetUserInput()
        {
            do
            {
                string input = Console.ReadLine();
                if (input.Length != 5)
                {
                    Console.WriteLine("Please enter a 5 letter word.");
                    continue;
                }
                else
                {
                    //bool isInDictionary = await CheckIfWordIsInDictionary(input);

                    if (true)
                    {
                        //Console.WriteLine("Word is in the dictionary");
                        return input.ToUpper();
                    }
                    else
                    {
                        Console.WriteLine("Word is not in the dictionary");
                    }
                    
                }
            } while (true);
        }

        //async bool CheckIfWordIsInDictionary(string word)
        //{
        //    Console.Write("Enter a word to check: ");

        //    string userInput = Console.ReadLine();
        //    string url = $"https://api.dictionaryapi.dev/api/v2/entries/en/{userInput}";

        //    using (HttpClient client = new HttpClient())
        //    {

        //        try
        //        {
        //            HttpResponseMessage response = await client.GetAsync(url);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                Console.WriteLine("true");
        //                return true;
        //            }
        //            else
        //            {
        //                Console.WriteLine("false");
        //                return false;
        //            }
        //        }
        //        catch (HttpRequestException e)
        //        {
        //            Console.WriteLine("false");
        //            return false;
        //        }
        //    }
        //    return false;
        //}

        void StartNewBoard()
        {
            Board.Clear();
            for (int i = 0; i < 6; i++)
            {
                Board.Add("_____");
            }
        }

        void DrawBoard()
        {
            Console.Clear();
            foreach (var item in Board)
            {
                AssignColorBasedOnPositionCheck(item);
                //Console.WriteLine(item);
            }
        }
    }
}

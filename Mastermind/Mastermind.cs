using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    public class Mastermind
    {
        public Mastermind() 
        {
        }
        public string GenerateRandomNumber()
        {
            var r = new Random();
            return $"{r.Next(1, 7)}{r.Next(1, 7)}{r.Next(1, 7)}{r.Next(1, 7)}";            
        }

        public void Play()
        {
            var randomNum = GenerateRandomNumber();
            int guesses = 12;
            while (guesses > 0)

            {
                try
                {
                    Console.WriteLine("Guess a 4 digit number. Each digit must be between 1 and 6.");
                    var guessedNum = Console.ReadLine();
                    if (guessedNum.Length != 4)
                    {
                        Console.WriteLine("Your guess must be 4 digits long");
                        continue;
                    }
                    foreach (var num in guessedNum) 
                    {
                        if (6 <= int.Parse(num.ToString()) && int.Parse(num.ToString()) >= 1)
                        {
                            Console.WriteLine("Each digit in your guess must be between 1 and 6.");
                            break;
                        }
                    }                  
                    guesses--;
                    var hint = string.Empty;
                    for (int i = 0; i < guessedNum.Length; i++)
                    {
                        if (guessedNum[i] == randomNum[i])
                        {
                            hint += "+";
                        }
                        else if (randomNum.Contains(guessedNum[i]))
                        {
                            hint += "-";
                        }
                    }

                    hint = SortHint(hint);                  
                    Console.WriteLine(hint);
                    if (hint.Equals("++++"))
                    {
                        Console.WriteLine("You solved it!");
                        break;
                    }
                    Console.WriteLine($"You have {guesses} guesses remaining.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            Console.WriteLine($"The number is: {randomNum}");
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();

        }

        public string SortHint(string hint) 
        {
            var unsortedHint = hint.ToCharArray();
            Array.Sort(unsortedHint);
            hint = string.Concat(unsortedHint);
            return hint;
        }

    }
}

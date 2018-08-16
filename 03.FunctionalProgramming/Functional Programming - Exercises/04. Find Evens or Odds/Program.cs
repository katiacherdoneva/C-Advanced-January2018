using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Find_Evens_or_Odds
{
    class FindEvensOrOdds
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string command = Console.ReadLine();

            Predicate<int> IsEvenNumbers = x => x % 2 == 0;
            Predicate<string> WantEvenNumbers = x => x == "even";

            List<int> newNumbers = GetNewNumbers(numbers, command, IsEvenNumbers, WantEvenNumbers);

            Console.WriteLine(string.Join(" ", newNumbers));
        }

        private static List<int> GetNewNumbers(int[] numbers, string command, Predicate<int> IsEvenNumbers, Predicate<string> WantEvenNumbers)
        {
            List<int> newNumbers = new List<int>();
            for (int number = numbers[0]; number <= numbers[1]; number++)
            {
                if (IsEvenNumbers(number) && WantEvenNumbers(command))
                {
                    newNumbers.Add(number);
                }
                else if (!IsEvenNumbers(number) && !WantEvenNumbers(command))
                {
                    newNumbers.Add(number);
                }
            }
            return newNumbers;
        }
    }
}

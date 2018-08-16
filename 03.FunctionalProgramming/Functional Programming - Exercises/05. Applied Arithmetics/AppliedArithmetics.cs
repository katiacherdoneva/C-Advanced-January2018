using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Applied_Arithmetics
{
    class AppliedArithmetics
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            Func<List<int>, List<int>> Add = y => y.Select(x => x + 1).ToList();
            Func<List<int>, List<int>> Multiply = y => y.Select(x => x * 2).ToList();
            Func<List<int>, List<int>> Subtract = y => y.Select(x => x - 1).ToList();
            Action<List<int>> PrintNumbers = nums => Console.WriteLine(string.Join(" ", nums));

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }

                switch (command)
                {
                    case "add":
                        numbers = Add(numbers);
                        break;
                    case "multiply":
                        numbers = Multiply(numbers);
                        break;
                    case "subtract":
                        numbers = Subtract(numbers);
                        break;
                    case "print":
                        PrintNumbers(numbers);
                        break;
                }
            }
        }
    }
}

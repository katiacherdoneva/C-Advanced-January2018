using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Basic_Stack_Operations
{
    class BasicStackOperations
    {
        static void Main()
        {
            int[] commandOfArgs = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] inputNumbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int numbersPushCount = commandOfArgs[0];
            int numbersPopCount = commandOfArgs[1];
            int searchNum = commandOfArgs[2];

            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < numbersPushCount; i++)
            {
                numbers.Push(inputNumbers[i]);
            }
            for (int i = 0; i < numbersPopCount; i++)
            {
                numbers.Pop();
            }

            if(numbers.Count == 0)
            {
                Console.WriteLine("0");
            }
            else if(numbers.Contains(searchNum))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbers.Min());
            }
        }
    }
}

using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class CustomMinFunction
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> SmallestNumber = (int firstNumber, int secondNumber) => Math.Min(firstNumber, secondNumber);

            int smallestNumber = int.MaxValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                smallestNumber = SmallestNumber(smallestNumber, numbers[i]);
            }

            Console.WriteLine(smallestNumber);
        }
    }
}

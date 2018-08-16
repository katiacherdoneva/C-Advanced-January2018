using System;
using System.Linq;

namespace _08._Custom_Comparator
{
    class CustomComparator
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int[]> evenNumbers = (numbers) => x => x % 2;
        }
    }
}

using System;
using System.Linq;

namespace _03._Group_Numbers
{
    class GroupNumbers
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] numRemainderZero = numbers.Where(x => Math.Abs(x % 3) == 0).ToArray();
            int[] numRemainderOne = numbers.Where(x => Math.Abs(x % 3) == 1).ToArray();
            int[] numRemainderTwo = numbers.Where(x => Math.Abs(x % 3) == 2).ToArray();

            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = numRemainderZero;
            jaggedArray[1] = numRemainderOne;
            jaggedArray[2] = numRemainderTwo;

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int colomn = 0; colomn < jaggedArray[row].Length; colomn++)
                {
                    Console.Write($"{jaggedArray[row][colomn]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Linq;

namespace _04._Maximal_Sum
{
    class MaximalSum
    {
        static void Main()
        {
            int[] parameters = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[parameters[0], parameters[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int colomn = 0; colomn < matrix.GetLength(1); colomn++)
                {
                    matrix[row, colomn] = input[colomn];
                }
            }

            long theBestSum = long.MinValue;
            int theBestRow = 0;
            int theBestColomn = 0;
            long sum = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int colomn = 0; colomn < matrix.GetLength(1) - 2; colomn++)
                {
                    long sumFirstRow = matrix[row, colomn] + matrix[row, colomn + 1] + matrix[row, colomn + 2];
                    long sumSecondRow = matrix[row + 1, colomn] + matrix[row + 1, colomn + 1] + matrix[row + 1, colomn + 2];
                    long sumThirdRow = matrix[row + 2, colomn] + matrix[row + 2, colomn + 1] + matrix[row + 2, colomn + 2];
                    sum = sumFirstRow + sumSecondRow + sumThirdRow;

                    if (theBestSum < sum)
                    {
                        theBestSum = sum;
                        theBestRow = row;
                        theBestColomn = colomn;
                    }
                }
            }

            Console.WriteLine($"Sum = {theBestSum}");

            for (int row = theBestRow; row < theBestRow + 3; row++)
            {
                for (int colomn = theBestColomn; colomn < theBestColomn + 3; colomn++)
                {
                    Console.Write($"{matrix[row, colomn]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

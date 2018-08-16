using System;
using System.Linq;

namespace _02._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main()
        {
            int[] infoForMatrix = Console.ReadLine()
                                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            int[,] matrix = new int[infoForMatrix[0], infoForMatrix[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbersInput = Console.ReadLine()
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = numbersInput[column];
                }
            }

            long sum = long.MinValue;
            int rowTheBiggestSum = 0;
            int colomnTheBiggestSum = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int column = 0; column < matrix.GetLength(1) - 1; column++)
                {
                    long currentSum = matrix[row, column] + matrix[row, column + 1]
                        + matrix[row + 1, column] + matrix[row + 1, column + 1];

                    if(sum < currentSum)
                    {
                        sum = currentSum;
                        rowTheBiggestSum = row;
                        colomnTheBiggestSum = column;
                    }
                }
            }

            Console.WriteLine($"{matrix[rowTheBiggestSum, colomnTheBiggestSum]} " +
                $"{matrix[rowTheBiggestSum, colomnTheBiggestSum + 1]}");
            Console.WriteLine($"{matrix[rowTheBiggestSum + 1, colomnTheBiggestSum]} " +
                $"{matrix[rowTheBiggestSum + 1, colomnTheBiggestSum + 1]}");
            Console.WriteLine(sum);
        }
    }
}

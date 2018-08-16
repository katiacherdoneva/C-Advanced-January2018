using System;
using System.Linq;

namespace _01._Sum_Matrix_Elements
{
    class SumMatrixElements
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

            long sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int colomn = 0; colomn < matrix.GetLength(1); colomn++)
                {
                    sum += matrix[row, colomn];
                }
            }
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}

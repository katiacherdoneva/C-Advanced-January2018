using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Squares_in_Matrix
{
    class SquaresInMatrix
    {
        static void Main()
        {
            int[] parameters = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string[][] matrix = new string[parameters[0]][];

            for (int i = 0; i < matrix.Length; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                matrix[i] = input;
            }

            int count = 0;
            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int colomn = 0; colomn < matrix[row].Length - 1; colomn++)
                {
                    if(matrix[row][colomn] == matrix[row][colomn + 1] 
                        && matrix[row][colomn + 1] == matrix[row + 1][colomn]
                        && matrix[row + 1][colomn] == matrix[row + 1][colomn + 1])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}

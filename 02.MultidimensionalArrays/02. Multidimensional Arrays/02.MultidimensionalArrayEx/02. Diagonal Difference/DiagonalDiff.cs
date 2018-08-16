using System;
using System.Linq;

namespace _02._Diagonal_Difference
{
    class DiagonalDiff
    {
        static void Main()
        {
            int parameters = int.Parse(Console.ReadLine());
            int[][] matrix = new int[parameters][];
            
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            Console.WriteLine(GetDiffDiagonal(matrix));
        }

        private static long GetDiffDiagonal(int[][] matrix)
        {
            long sumPrimary = 0; 
            long sumSecodary = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                sumPrimary += matrix[row][row];
                sumSecodary += matrix[row][matrix.Length - 1 - row];
            }
            return Math.Abs(sumPrimary - sumSecodary);
        }
    }
}

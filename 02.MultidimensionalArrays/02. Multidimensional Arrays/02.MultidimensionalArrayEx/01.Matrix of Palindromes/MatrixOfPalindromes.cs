using System;
using System.Linq;

namespace _01.Matrix_of_Palindromes
{
    class MatrixOfPalindromes
    {
        static void Main()
        {
            int[] parameters = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            string[,] matrix = new string[parameters[0], parameters[1]];

            char[] alphabetical = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int indexMiddleABC = row;
                for (int colomn = 0; colomn < matrix.GetLength(1); colomn++)
                {
                    string result = string.Empty;

                    result += alphabetical[row];
                    result += alphabetical[indexMiddleABC];
                    result += alphabetical[row];
                    matrix[row, colomn] = result;

                    indexMiddleABC++;
                }              
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int colomn = 0; colomn < matrix.GetLength(1); colomn++)
                {
                    Console.Write($"{matrix[row, colomn]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

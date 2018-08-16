using System;
using System.Linq;
using System.Text;

namespace _06._Target_Practice
{
    class TargetPractice
    {
        static void Main()
        {
            int[] parameters = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            char[] word = Console.ReadLine()
                .ToCharArray();

            int rows = parameters[0];
            int colomns = parameters[1];
            char[,] matrix = new char[rows, colomns];

            matrix = FullMatrix(matrix, word);
            matrix = FireShot(matrix);
            matrix = Gravity(matrix);
            Print(matrix);

        }

        private static char[,] Gravity(char[,] matrix)
        {
            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                int empty = 0;
                for (int r = matrix.GetLength(0) - 1; r >= 0; r--)
                {
                    if (matrix[r, c] == ' ')
                    {
                        empty++;
                    }
                    else if (empty > 0)
                    {
                        matrix[r + empty, c] = matrix[r, c];
                        matrix[r, c] = ' ';
                    }

                }
            }
            return matrix;
        }

        private static void Print(char[,] matrix)
        {
            StringBuilder sb = new StringBuilder();

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    sb.Append(matrix[r, c]);
                }
                sb.AppendLine();
            }
            string result = sb.ToString().TrimEnd();
            Console.WriteLine(result);
        }

        private static char[,] FireShot(char[,] matrix)
        {
            int[] shot = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int row = shot[0];
            int column = shot[1];
            int radius = shot[2];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    int a = row - r;
                    int b = column - c;

                    double distance = Math.Sqrt(a * a + b * b);

                    if (distance <= radius)
                    {
                        matrix[r, c] = ' ';
                    }
                }
            }
            return matrix;
        }

        private static char[,] FullMatrix(char[,] matrix, char[] word)
        {
            bool goingLeft = true;
            int indexOfWord = 0;
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                int index = goingLeft ? matrix.GetLength(1) - 1 : 0;
                int incremend = goingLeft ? -1 : 1;
                for (int colomn = 0; colomn < matrix.GetLength(1); colomn++)
                {
                    matrix[row, index] = word[indexOfWord];

                    indexOfWord++;
                    if(indexOfWord >= word.Length)
                    {
                        indexOfWord = 0;
                    }
                    index += incremend;
                }
                goingLeft = !goingLeft;
            }
            return matrix;
        }
    }
}

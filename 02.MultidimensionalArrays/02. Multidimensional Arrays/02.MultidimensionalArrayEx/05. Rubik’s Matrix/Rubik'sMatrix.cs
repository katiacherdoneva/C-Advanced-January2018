using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Rubik_s_Matrix
{
    class RibilMatrix
    {
        private static int[,] matrix;

        static void Main()
        {
            int[] parameters = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
            Dictionary<int, List<int>> valueAndPosition = new Dictionary<int, List<int>>();
            matrix = new int[parameters[0], parameters[1]];

            int count = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int colomn = 0; colomn < matrix.GetLength(1); colomn++)
                {
                    count++;
                    matrix[row, colomn] = count;
                    valueAndPosition.Add(count, new List<int>());
                }
            }

            int n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                string[] commandOfArgs = Console.ReadLine()
                             .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                             .ToArray();

                int index = int.Parse(commandOfArgs[0]);
                string command = commandOfArgs[1];
                int moves = int.Parse(commandOfArgs[2]);

                switch (command)
                {
                    case "up":
                        ColomnMove(index, matrix.GetLength(0) - moves);
                        break;
                    case "down":
                        ColomnMove(index, moves);
                        break;
                    case "left":
                        RowMove(index, matrix.GetLength(1) - moves);
                        break;
                    case "right":
                        RowMove(index, moves);
                        break;
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int colomn = 0; colomn < matrix.GetLength(1); colomn++)
                {
                    valueAndPosition[matrix[row, colomn]].Add(row);
                    valueAndPosition[matrix[row, colomn]].Add(colomn);
                }
            }
            Print(valueAndPosition, matrix);
        }

        private static void RowMove(int index, int moves)
        {
            int colomn = matrix.GetLength(1);
            moves %= colomn;

            int[] tempArray = new int[colomn];
            for (int col = 0; col < colomn; col++)
            {
                tempArray[(col + moves) % colomn] = matrix[index, col];
            }

            for (int col = 0; col < colomn; col++)
            {
                matrix[index, col] = tempArray[col];
            }
        }

        private static void ColomnMove(int index, int moves)
        {
            int rows = matrix.GetLength(0);
            moves %= rows;

            int[] tempArray = new int[rows];
            for (int row = 0; row < rows; row++)
            {
                tempArray[(row + moves) % rows] = matrix[row, index];
            }

            for (int row = 0; row < rows; row++)
            {
                matrix[row, index] = tempArray[row];
            }
        }

        private static void PrintMatrix(Dictionary<int, List<int>> valueAndPosition, int[,] matrix)
        {
            int count = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int colomn = 0; colomn < matrix.GetLength(1); colomn++)
                {
                    count++;
                    int currentRow = valueAndPosition[count][0];
                    int currentColomn = valueAndPosition[count][1];

                    if (row == currentRow && colomn == currentColomn)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        Console.WriteLine($"Swap ({row}, {colomn}) with ({currentRow}, {currentColomn})");

                        valueAndPosition[matrix[row, colomn]].Clear();
                        valueAndPosition[matrix[row, colomn]].Add(currentRow);
                        valueAndPosition[matrix[row, colomn]].Add(currentColomn);

                        int currentValue = matrix[row, colomn];
                        matrix[row, colomn] = matrix[currentRow, currentColomn];
                        matrix[currentRow, currentColomn] = currentValue;
                    }
                }
            }
        }
    }
}
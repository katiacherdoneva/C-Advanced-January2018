using System;
using System.Linq;

namespace _08._Radioactive_Bunnies
{
    class RadioactiveBunnies
    {
        private static char[,] matrix;
        private static bool isDie = false;
        private static int rowPlayerEnd;
        private static int columnPlayerEnd;
        private static int rowPlayerCurrent;
        private static int columnPlayerCurrent;

        static void Main()
        {
            int[] parameters = Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            int rows = parameters[0];
            int columns = parameters[1];
            matrix = new char[rows, columns];
            matrix = FullMatrix(matrix);

            char[] command = Console.ReadLine()
                             .ToCharArray();

            char[,] newMatrix = new char[rows, columns];
            int indexOfCommand = 0;
            while (true)
            {
                newMatrix = DoublingBunnies(rows, columns, newMatrix);
                newMatrix = MovePlayer(newMatrix, indexOfCommand, command);
                if (isDie)
                {
                    newMatrix[rowPlayerEnd, columnPlayerEnd] = 'B';
                    PrintMatrix(newMatrix);
                    Console.WriteLine($"dead: {rowPlayerEnd} {columnPlayerEnd}");
                    Environment.Exit(0);
                }
                matrix = CloneNewMatrix(newMatrix);
                indexOfCommand++;

            }
        }

        private static char[,] MovePlayer(char[,] newMatrix, int indexOfCommand, char[] command)
        {
            bool isWin = false;
            switch (command[indexOfCommand])
            {
                case 'L':
                    if (columnPlayerCurrent - 1 < 0 || columnPlayerCurrent - 1 >= newMatrix.GetLength(1))
                    {
                        isWin = true;
                        rowPlayerEnd = rowPlayerCurrent;
                        columnPlayerEnd = columnPlayerCurrent;
                        newMatrix[rowPlayerCurrent, columnPlayerCurrent] = '.';
                    }
                    else
                    {
                        if (matrix[rowPlayerCurrent, columnPlayerCurrent - 1] == 'B')
                        {
                            isDie = true;
                        }
                        else
                        {
                            newMatrix[rowPlayerCurrent, columnPlayerCurrent - 1] = 'P';                
                        }
                        rowPlayerEnd = rowPlayerCurrent;
                        columnPlayerEnd = columnPlayerCurrent - 1;
                    }

                    break;
                case 'R':
                    if (columnPlayerCurrent + 1 < 0 || columnPlayerCurrent + 1 >= newMatrix.GetLength(1))
                    {
                        isWin = true;
                        rowPlayerEnd = rowPlayerCurrent;
                        columnPlayerEnd = columnPlayerCurrent;
                        newMatrix[rowPlayerCurrent, columnPlayerCurrent] = '.';
                    }
                    else
                    {
                        if (matrix[rowPlayerCurrent, columnPlayerCurrent + 1] == 'B')
                        {
                            isDie = true;
                        }
                        else
                        {
                            newMatrix[rowPlayerCurrent, columnPlayerCurrent + 1] = 'P';                         
                        }
                        rowPlayerEnd = rowPlayerCurrent;
                        columnPlayerEnd = columnPlayerCurrent + 1;
                    }
                    break;
                case 'U':
                    if (rowPlayerCurrent - 1 < 0 || rowPlayerCurrent - 1 >= newMatrix.GetLength(1))
                    {
                        isWin = true;
                        rowPlayerEnd = rowPlayerCurrent;
                        columnPlayerEnd = columnPlayerCurrent;
                        newMatrix[rowPlayerCurrent, columnPlayerCurrent] = '.';
                    }
                    else
                    {
                        if (matrix[rowPlayerCurrent - 1, columnPlayerCurrent] == 'B')
                        {
                            isDie = true;
                        }
                        else
                        {
                            newMatrix[rowPlayerCurrent - 1, columnPlayerCurrent] = 'P';                           
                        }
                        rowPlayerEnd = rowPlayerCurrent - 1;
                        columnPlayerEnd = columnPlayerCurrent;
                    }
                    break;
                case 'D':
                    if (rowPlayerCurrent + 1 < 0 || rowPlayerCurrent + 1 >= newMatrix.GetLength(1))
                    {
                        isWin = true;
                        rowPlayerEnd = rowPlayerCurrent;
                        columnPlayerEnd = columnPlayerCurrent;
                        newMatrix[rowPlayerCurrent, columnPlayerCurrent] = '.';
                    }
                    else
                    {
                        if (matrix[rowPlayerCurrent + 1, columnPlayerCurrent] == 'B')
                        {
                            isDie = true;
                        }
                        else
                        {
                            newMatrix[rowPlayerCurrent + 1, columnPlayerCurrent] = 'P';                           
                        }
                        rowPlayerEnd = rowPlayerCurrent + 1;
                        columnPlayerEnd = columnPlayerCurrent;
                    }
                    break;
            }

            newMatrix[rowPlayerCurrent, columnPlayerCurrent] = '.';

            if (isWin)
            {
                PrintMatrix(newMatrix);
                Console.WriteLine($"won: {rowPlayerEnd} {columnPlayerEnd}");
                Environment.Exit(0);
            }
            return newMatrix;
        }

        private static char[,] CloneNewMatrix(char[,] newMatrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = newMatrix[r, c];
                }
            }
            return matrix;
        }

        private static void PrintMatrix(char[,] newMatrix)
        {
            for (int r = 0; r < newMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < newMatrix.GetLength(1); c++)
                {
                    Console.Write($"{newMatrix[r, c]}");
                }
                Console.WriteLine();
            }
        }

        private static char[,] DoublingBunnies(int rows, int columns, char[,] newMatrix)
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (matrix[r, c] == 'B')
                    {
                        newMatrix[r, c] = 'B';

                        if (r - 1 >= 0 && r - 1 < rows)
                        {
                            if (matrix[r - 1, c] == 'P')
                            {
                                isDie = true;
                            }
                            newMatrix[r - 1, c] = 'B';
                        }

                        if (r + 1 >= 0 && r + 1 < rows)
                        {
                            if (matrix[r + 1, c] == 'P')
                            {
                                isDie = true;
                            }
                            newMatrix[r + 1, c] = 'B';
                        }

                        if (c + 1 >= 0 && c + 1 < columns)
                        {
                            if (matrix[r, c + 1] == 'P')
                            {
                                isDie = true;
                            }
                            newMatrix[r, c + 1] = 'B';
                        }

                        if (c - 1 >= 0 && c - 1 < columns)
                        {
                            if (matrix[r, c - 1] == 'P')
                            {
                                isDie = true;
                            }
                            newMatrix[r, c - 1] = 'B';
                        }
                    }
                    else if (matrix[r, c] == 'P')
                    {
                        newMatrix[r, c] = 'P';
                        rowPlayerCurrent = r;
                        columnPlayerCurrent = c;
                    }
                    else if (newMatrix[r, c] != 'B' && matrix[r, c] == '.')
                    {
                        newMatrix[r, c] = '.';
                    }
                }
            }
            return newMatrix;
        }

        private static char[,] FullMatrix(char[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                char[] row = Console.ReadLine()
                    .ToCharArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = row[c];
                }
            }
            return matrix;
        }
    }
}

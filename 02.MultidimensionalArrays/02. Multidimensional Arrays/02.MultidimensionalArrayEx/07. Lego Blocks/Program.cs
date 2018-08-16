using System;
using System.Linq;
using System.Text;

namespace _07._Lego_Blocks
{
    class LegoBlocks
    {
        private static int allElements;
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] firstJaggedArray = new int[rows][];
            int[][] secondJaggedArray = new int[rows][];

            bool notReverseJaggedArray = true;
            firstJaggedArray = FullMatrix(rows, firstJaggedArray, notReverseJaggedArray);
            secondJaggedArray = FullMatrix(rows, secondJaggedArray, !notReverseJaggedArray);

            int[][] matchedArray = new int[rows][];
            matchedArray = FullMatchedArray(rows, firstJaggedArray, secondJaggedArray, matchedArray);

            PrintJaggedArray(matchedArray);
        }

        private static int[][] FullMatchedArray(int rows, int[][] firstJaggedArray, int[][] secondJaggedArray, int[][] matchedArray)
        {
            int maxLenght = 0;
            maxLenght = firstJaggedArray[0].Length + secondJaggedArray[0].Length;
            for (int r = 0; r < rows; r++)
            {
                if (firstJaggedArray[r].Length + secondJaggedArray[r].Length == maxLenght)
                {
                    int[] newRow = new int[maxLenght];
                    int indexSecond = 0;
                    for (int c = 0; c < maxLenght; c++)
                    {
                        if (c < firstJaggedArray[r].Length)
                        {
                            newRow[c] = firstJaggedArray[r][c];
                        }
                        else
                        {
                            newRow[c] = secondJaggedArray[r][indexSecond];
                            ++indexSecond;
                        }
                    }
                    matchedArray[r] = newRow;
                }
                else
                {
                    Console.WriteLine($"The total number of cells is: {allElements}");
                    Environment.Exit(0);
                }
            }
            return matchedArray;
        }

        private static void PrintJaggedArray(int[][] matchedArray)
        {
            StringBuilder sb = new StringBuilder();
            for (int r = 0; r < matchedArray.Length; r++)
            {
                sb.Append("[");
                for (int c = 0; c < matchedArray[r].Length; c++)
                {
                    sb.Append(matchedArray[r][c] + ", ");
                }
                sb.Remove(sb.Length - 2, 2);
                sb.Append("]");
                sb.AppendLine();
            }
            string result = sb.ToString().TrimEnd();
            Console.WriteLine(result);
        }

        private static int[][] FullMatrix(int rows, int[][] jaggedArray, bool notReverseJaggedArray)
        {
            for (int r = 0; r < rows; r++)
            {
                int[] row = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                row = notReverseJaggedArray ? row.ToArray() : row.Reverse().ToArray();
                jaggedArray[r] = row;
                allElements += row.Length;
            }
            return jaggedArray;
        }
    }
}

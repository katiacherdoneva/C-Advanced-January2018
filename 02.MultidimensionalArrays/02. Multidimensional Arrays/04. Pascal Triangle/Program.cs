using System;

namespace _04._Pascal_Triangle
{
    class PascalTriangle
    {
        static void Main()
        {
            int height = int.Parse(Console.ReadLine());

            long[][] jaggedArray = new long[height][];

            jaggedArray[0] = new long[1];
            jaggedArray[0][0] = 1;

            for (int row = 1; row < jaggedArray.Length; row++)
            {
                int colomn = 1;
                jaggedArray[row] = new long[row + 1];
                jaggedArray[row][0] = 1;
                jaggedArray[row][row] = 1;
                while (row - 1 >= colomn)
                {
                    jaggedArray[row][colomn] = jaggedArray[row - 1][colomn - 1] + jaggedArray[row - 1][colomn];
                    colomn++;
                }
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int colomn = 0; colomn < jaggedArray[row].Length; colomn++)
                {
                    Console.Write($"{jaggedArray[row][colomn]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

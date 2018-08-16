using System;
using System.Collections.Generic;

namespace _08._Recursive_Fibonacci
{
    class RecursiveFibonacci
    {
        private static long[] fibNumbers;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            fibNumbers = new long[n]; 
            long result = GetFibonacci(n);

            Console.WriteLine(result);
        }

        private static long GetFibonacci(int n)
        {
            if(n <= 2)
            {
                return 1;
            }
            if(fibNumbers[n - 1] != 0)
            {
                return fibNumbers[n - 1];
            }
            return fibNumbers[n - 1] = GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
    }
}

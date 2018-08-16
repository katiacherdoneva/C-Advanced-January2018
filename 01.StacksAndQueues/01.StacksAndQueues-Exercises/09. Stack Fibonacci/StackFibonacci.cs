using System;
using System.Collections.Generic;

namespace _09._Stack_Fibonacci
{
    class StackFibonaci
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Stack<long> fibonacciNum = new Stack<long>();
            Queue<long> currentResult = new Queue<long>();

            fibonacciNum.Push(0);
            fibonacciNum.Push(1);
            fibonacciNum.Push(1);
            currentResult.Enqueue(1);
            currentResult.Enqueue(1);

            for (int i = 0; i < n - 2; i++)
            {

                fibonacciNum.Push(currentResult.Dequeue() + currentResult.Peek());
                currentResult.Enqueue(fibonacciNum.Peek());
            }
            Console.WriteLine(fibonacciNum.Peek());
        }
    }
}

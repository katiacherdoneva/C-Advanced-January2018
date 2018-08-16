using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Reverse_Numbers
{
    class ReverseNumbers
    {
        static void Main()
        {
            int[] number = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> reverseNumber = new Stack<int>();
          
            for (int i = 0; i < number.Length; i++)
            {
                reverseNumber.Push(number[i]);
            }

            while(reverseNumber.Count != 0)
            {
                Console.Write($"{reverseNumber.Pop()} "); 
            }
        }
    }
}

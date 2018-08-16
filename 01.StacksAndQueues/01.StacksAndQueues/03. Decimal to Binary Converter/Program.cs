using System;
using System.Collections.Generic;

namespace _03._Decimal_to_Binary_Converter
{
    class Program
    {
        static void Main()
        {
            int numberInDecimal = int.Parse(Console.ReadLine());

            if(numberInDecimal == 0)
            {
                Console.WriteLine("0");
                return;
            }
            Stack<int> numberInbinary = new Stack<int>();

            while(numberInDecimal > 0)
            {
                numberInbinary.Push(numberInDecimal % 2);
                numberInDecimal /= 2;
            }
            Console.WriteLine(string.Join("", numberInbinary));
        }
    }
}

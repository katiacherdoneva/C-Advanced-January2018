using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Reverse_Strings
{
    class ReverseStrings
    {
        static void Main()
        {
            char[] texts = Console.ReadLine()
                .ToArray();

            Stack<char> reverseTexts = new Stack<char>(texts);

            Console.WriteLine(string.Join("", reverseTexts));
        }
    }
}

using System;
using System.Collections.Generic;

namespace _04._Matching_Brackets
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Stack<int> indexesOpenBrackets = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indexesOpenBrackets.Push(i);
                }

                if (input[i] == ')')
                {
                    int indexOpenBracket = indexesOpenBrackets.Pop();
                    int indexCloseBracket = i - indexOpenBracket + 1;

                    Console.WriteLine(input.Substring(indexOpenBracket, indexCloseBracket));
                }
            }
        }
    }
}

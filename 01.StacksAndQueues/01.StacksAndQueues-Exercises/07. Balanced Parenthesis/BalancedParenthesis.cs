using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Balanced_Parenthesis
{
    class BalancedParenthesis
    {
        static void Main(string[] args)
        {
            char[] parentheses = Console.ReadLine()
                .ToCharArray();

            if(parentheses.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                Environment.Exit(0);
            }

            Stack<char> openParentheses = new Stack<char>();
            char[] opening = new[] { '(', '[', '{' };
            char[] closing = new[] { ')', ']', '}' };

            foreach (var parenthes in parentheses)
            {
                if(opening.Contains(parenthes))
                {
                    openParentheses.Push(parenthes);
                }
                else if(closing.Contains(parenthes))
                {
                    char firstParentheses = openParentheses.Pop();

                    int indexOpen = Array.IndexOf(opening, firstParentheses);
                    int indexClose = Array.IndexOf(closing, parenthes);
                    if (indexClose != indexOpen)
                    {
                        Console.WriteLine("NO");
                        Environment.Exit(0);
                    }
                }
            }
            Console.WriteLine("YES");
        }
    }
}

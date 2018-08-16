using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Simple_Calculator
{
    class SimpleCalculator
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(' ')
                .ToArray();

            Stack<string> equation = new Stack<string>(input.Reverse());

            while(equation.Count > 1)
            {
                int firstNumber = int.Parse(equation.Pop());
                string operation = equation.Pop();
                int secondNumber = int.Parse(equation.Pop());

                switch (operation)
                {
                    case "-":
                        equation.Push((firstNumber - secondNumber).ToString());
                        break;
                    case "+":
                        equation.Push((firstNumber + secondNumber).ToString());
                        break;
                }
            }
            Console.WriteLine(equation.Peek());
        }
    }
}

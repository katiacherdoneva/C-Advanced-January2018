using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Maximum_Element
{
    class MaximumElement
    {
        static void Main()
        {
            int operationCount = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();
            Stack<int> theBiggestNum = new Stack<int>();

            theBiggestNum.Push(int.MinValue);

            for (int i = 0; i < operationCount; i++)
            {
                int[] commandOfArgs = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                switch (commandOfArgs[0])
                {
                    case 1:
                        int element = commandOfArgs[1];
                        numbers.Push(element);

                        if (element >= theBiggestNum.Peek())
                        {
                            theBiggestNum.Push(element);
                        }
                        break;
                    case 2:
                        int popElement = 0;
                        if (numbers.Count >= 1)
                        {
                            popElement = numbers.Pop();
                        }
                        if (theBiggestNum.Peek() == popElement)
                        {
                            theBiggestNum.Pop();
                        }
                        break;
                    case 3:
                        Console.WriteLine(theBiggestNum.Peek());
                        break;
                }
            }
        }
    }
}

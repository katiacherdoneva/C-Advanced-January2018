using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Basic_Queue_Operations
{
    class BasicQueueOperations
    {
        static void Main()
        {
            int[] commandOfArgs = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] numbersInput = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbers = new Queue<int>();
            Stack<int> smallestNum = new Stack<int>();

            smallestNum.Push(int.MaxValue);

            for (int i = 0; i < commandOfArgs[0]; i++)
            {
                numbers.Enqueue(numbersInput[i]);

                if (numbersInput[i] <= smallestNum.Peek())
                {
                    smallestNum.Push(numbersInput[i]);
                }
            }

            for (int i = 0; i < commandOfArgs[1]; i++)
            {
                int popElement = numbers.Dequeue();

                if (popElement == smallestNum.Peek())
                {
                    smallestNum.Pop();
                }
            }
            if (numbers.Count == 0)
            {
                Console.WriteLine("0");
            }
            else if (numbers.Contains(commandOfArgs[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(smallestNum.Peek());
            }
        }
    }
}

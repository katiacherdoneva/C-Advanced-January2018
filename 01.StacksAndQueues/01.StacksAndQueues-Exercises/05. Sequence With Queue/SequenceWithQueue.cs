using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Sequence_With_Queue
{
    class SequenceWithQueue
    {
        static void Main()
        {
            long firstResult = long.Parse(Console.ReadLine());

            Queue<long> currentResults = new Queue<long>();
            currentResults.Enqueue(firstResult);
            Queue<long> results = new Queue<long>();
            results.Enqueue(firstResult);

            long count = 1;

            while (count < 50)
            {
                long currentResult = currentResults.Dequeue();
           
                if (count < 50)
                {
                    long secondResult = currentResult + 1;
                    currentResults.Enqueue(secondResult);
                    results.Enqueue(secondResult);
                    count++;
                }
                if(count < 50)
                {
                    long thirdResult = 2 * currentResult + 1;
                    currentResults.Enqueue(thirdResult);
                    results.Enqueue(thirdResult);
                    count++;
                }
                if(count < 50)
                {
                    long fourthResult = currentResult + 2;
                    currentResults.Enqueue(fourthResult);
                    results.Enqueue(fourthResult);
                    count++;
                }               
            }
            Console.WriteLine(string.Join(" ", results));
        }
    }
}

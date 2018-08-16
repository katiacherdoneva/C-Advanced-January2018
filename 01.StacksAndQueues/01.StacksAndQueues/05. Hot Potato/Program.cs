using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Hot_Potato
{
    class HotPotatp
    {
        static void Main()
        {
            string[] namesOnGamers = Console.ReadLine()
                .Split(' ')
                .ToArray();
            int toss = int.Parse(Console.ReadLine());
            Queue<string> gamers = new Queue<string>(namesOnGamers);

            while (gamers.Count > 1)
            {
                for (int i = 1; i < toss; i++)
                {
                    gamers.Enqueue(gamers.Dequeue());
                }
                Console.WriteLine($"Removed {gamers.Dequeue()}");
            }
            Console.WriteLine($"Last is {gamers.Peek()}");
            gamers.TrimExcess();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Poisonous_Plants
{
    class PoisonousPlants
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] plants = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int[] days = new int[n];
            Stack<int> indexes = new Stack<int>();
            indexes.Push(0);

            for (int i = 1; i < plants.Length; i++)
            {
                int maxDay = 0;
                while (indexes.Count > 0 && plants[indexes.Peek()] >= plants[i])
                {
                    maxDay = Math.Max(maxDay, days[indexes.Pop()]);
                }

                if (indexes.Count > 0)
                {
                    days[i] = maxDay + 1;
                }
                indexes.Push(i);
            }
            Console.WriteLine(days.Max());
        }
    }
}

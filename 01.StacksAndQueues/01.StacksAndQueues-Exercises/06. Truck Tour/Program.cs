using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Truck_Tour
{
    class TruckTour
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] pumpInput = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                pumps.Enqueue(pumpInput);
            }

            for (int i = 0; i < n - 1; i++)
            {
                int fuel = 0;
                bool isSolution = true;

                for (int pumpsPassed = 0; pumpsPassed < n; pumpsPassed++)
                {
                    int[] currentPump = pumps.Dequeue();
                    int amountOfFuel = currentPump[0];
                    int distanceNextToPump = currentPump[1];

                    pumps.Enqueue(currentPump);

                    fuel += amountOfFuel - distanceNextToPump;
                    if (fuel < 0)
                    {
                        i += pumpsPassed;
                        isSolution = false;
                        break;
                    }
                }

                if (isSolution)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace _06._Traffic_Jam
{
    class TrafficJam
    {
        static void Main()
        {
            int carsLight = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int countCarPass = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                if (input == "green")
                {
                    int carsThatCanPass = Math.Min(cars.Count, carsLight);

                    for (int i = 0; i < carsThatCanPass; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        countCarPass++;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }
            Console.WriteLine($"{countCarPass} cars passed the crossroads.");
        }
    }
}

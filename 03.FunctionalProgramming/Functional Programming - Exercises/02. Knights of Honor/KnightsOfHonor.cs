using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class KnightsOfHonor
    {
        static void Main()
        {
            string[] inputNames = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string> PrintSirPlusName = name => Console.WriteLine($"Sir {name}");

            for (int i = 0; i < inputNames.Length; i++)
            {
                PrintSirPlusName(inputNames[i]);
            }
        }
    }
}

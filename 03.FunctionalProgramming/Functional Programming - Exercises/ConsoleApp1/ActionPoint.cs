using System;
using System.Linq;

namespace ConsoleApp1
{
    class ActionPoint
    {
        static void Main()
        {
            string[] inputNames = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string> PrintName = name => Console.WriteLine(name);

            for (int i = 0; i < inputNames.Length; i++)
            {
                PrintName(inputNames[i]);
            }
        }
    }
}

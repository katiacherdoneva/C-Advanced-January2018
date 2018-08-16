using System;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class ReverseAndExclude
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = x => x % n != 0;

            numbers = numbers.Where(x => isDivisible(x)).Reverse().ToArray();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

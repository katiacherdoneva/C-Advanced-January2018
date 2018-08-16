using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class PredicateForNames
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Predicate<string> nIsLessAndEqual = x => x.Length <= n;

            names = names.Where(x => nIsLessAndEqual(x)).ToArray();

            Console.WriteLine(string.Join("\r\n", names));
        }
    }
}

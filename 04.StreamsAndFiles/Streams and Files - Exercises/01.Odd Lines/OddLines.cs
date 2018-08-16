using System;
using System.IO;

namespace _01.Odd_Lines
{
    public class OddLines
    {
        public static void Main()
        {
            StreamReader reader = new StreamReader("Files/text.txt");
            using (reader)
            {
                int lineNumber = 0;

                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null) break;

                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine($"Line {lineNumber}: {line}");
                    }
                    lineNumber++;
                }
            }
        }
    }
}

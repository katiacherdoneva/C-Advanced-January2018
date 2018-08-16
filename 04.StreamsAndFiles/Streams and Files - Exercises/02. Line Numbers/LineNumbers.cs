using System;
using System.IO;

namespace _02._Line_Numbers
{
    public class LineNumbers
    {
        public static void Main()
        {
            using (var reader = new StreamReader($"Files/text.txt"))
            {
                using (var writer = new StreamWriter($"Files/output.txt"))
                {
                    int lineNumbers = 0;
                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == null) break;

                        writer.WriteLine($"Line {++lineNumbers}: {line}");
                    }
                }
            }
        }
    }
}

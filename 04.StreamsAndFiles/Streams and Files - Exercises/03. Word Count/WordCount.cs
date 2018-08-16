using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _03._Word_Count
{
    public class WordCount
    {
        public static void Main()
        {
            var wordsCount = new Dictionary<string, int>();

            using (var reader = new StreamReader($"Files/words.txt"))
            {
                while (true)
                {
                    var word = reader.ReadLine();
                    if (word == null) break;

                    word = word.ToLower();
                    if (!wordsCount.ContainsKey(word))
                    {
                        wordsCount[word] = 0;
                    }
                }
            }
            using (var reader = new StreamReader($"Files/text.txt"))
            {
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null) break;

                    var currentWords = line
                        .Split(" .,?!:;-[]{}()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.ToLower())
                        .ToArray();
                    foreach (var word in currentWords)
                    {
                        if (wordsCount.ContainsKey(word))
                        {
                            wordsCount[word]++;
                        }
                    }
                }
            }
            using (var writer = new StreamWriter($"Files/result.txt"))
            {
                var result = wordsCount
                            .OrderByDescending(w => w.Value)
                            .Select(w => $"{w.Key} - {w.Value}");
                foreach (var resultPair in result)
                {
                    writer.WriteLine(resultPair);
                }
            }
        }
    }
}


using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _07._Directory_Traversal
{
    public class DirectoryTraversal
    {
        public static void Main()
        {
            Console.Write("Path: ");
            string path = Console.ReadLine();
            SortedDictionary<string, Dictionary<string, double>> extensions = new SortedDictionary<string, Dictionary<string, double>>();
            DirectoryInfo directorySelected = new DirectoryInfo(path);
            FilesExtensions(directorySelected, extensions);
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StreamWriter writer = new StreamWriter(desktop + "/report.txt");
            using (writer)
            {
                WritingOnFile(writer, extensions);
            }
        }

        private static void WritingOnFile(StreamWriter writer, SortedDictionary<string, Dictionary<string, double>> extensions)
        {
            var orderedExtensions =
               extensions
               .OrderByDescending(extension => extension.Value.Count)
               .ThenBy(extension => extension.Key);

            foreach (var extension in orderedExtensions)
            {

                writer.WriteLine(extension.Key);
                var orderedDic = extension.Value.OrderBy(dic => dic.Value);
                foreach (var dic in orderedDic)
                {

                    writer.WriteLine("{0}{1:F2}kb", dic.Key, dic.Value / 1024);

                }
            }
        }

        private static void FilesExtensions(DirectoryInfo directorySelected, SortedDictionary<string, Dictionary<string, double>> extensions)
        {
            foreach (var file in directorySelected.GetFiles())
            {
                if (!extensions.ContainsKey(file.Extension))
                {
                    extensions.Add(file.Extension, new Dictionary<string, double>
                    {
                       {string.Format("--{0} - ", file.Name), file.Length}
                    }
                    );
                }
                else
                {
                    extensions[file.Extension].Add(string.Format("--{0} - ", file.Name), file.Length);
                }

            }
        }
    }

}




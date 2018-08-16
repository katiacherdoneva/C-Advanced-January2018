using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _08._Full_Directory_Traversal
{
    public class FullDirectoryTraversal
    {
        public static void Main()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StreamWriter writer = new StreamWriter(desktop + "/myfile.txt");
            using (writer)
            {
                WritingOnFile(writer, "v. turnovo");
            }
        }

        private static void WritingOnFile(StreamWriter writer, string name)
        {
            writer.WriteLine(name);
        }

    }
}

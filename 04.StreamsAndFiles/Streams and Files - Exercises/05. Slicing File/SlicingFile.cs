using System;
using System.Collections.Generic;
using System.IO;

namespace _05._Slicing_File
{
    public class SlicingFile
    {
        private static List<string> listFileParts = new List<string>();

        public static void Main()
        {
            Console.Write("Enter number of parts: ");
            int partsCount = int.Parse(Console.ReadLine());

            SliceFileIntoParts(partsCount);
            AssembleFileFromParts();
        }

        private static void AssembleFileFromParts()
        {
            var buffer = new byte[4096];
            using (var assembledImage = new FileStream($"../Resource/assembledVideo.mp4", FileMode.Create))
            {
                for (int i = 0; i < listFileParts.Count; i++)
                {
                    using (var reader = new FileStream(listFileParts[i], FileMode.Open))
                    {
                        while (true)
                        {
                            int readBytes = reader.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0) break;

                            assembledImage.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }

        private static void SliceFileIntoParts(int partsCount)
        {
            var buffer = new byte[4096];
            using (var sourceFile = new FileStream($"../Resource/sliceMe.mp4", FileMode.Open))
            {
                var partSize = Math.Ceiling((double)sourceFile.Length / partsCount);
                for (int i = 0; i < partsCount; i++)
                {
                    var filePartName = $"../Resource/Part-{i}.mp4";
                    listFileParts.Add(filePartName);

                    using (var destinationFile = new FileStream(filePartName, FileMode.Create))
                    {
                        int totalBytes = 0;
                        while (totalBytes < partSize)
                        {
                            int readBytes = sourceFile.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0) break;

                            destinationFile.Write(buffer, 0, readBytes);
                            totalBytes += readBytes;
                        }
                    }
                }
            }
        }
    }
}
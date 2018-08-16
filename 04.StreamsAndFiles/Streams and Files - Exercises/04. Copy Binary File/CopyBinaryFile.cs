using System;
using System.IO;

namespace _04._Copy_Binary_File
{
    public class CopyBinaryFile
    {
        public static void Main()
        {
            var sourceFilePath = $"Files/image.png";
            var copyFilePath = $"Files/imageCopy.png";

            using (var sourceFile = new FileStream(sourceFilePath, FileMode.Open))
            {
                using (var copyFile = new FileStream(copyFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int readBytes = sourceFile.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0) break;

                        copyFile.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
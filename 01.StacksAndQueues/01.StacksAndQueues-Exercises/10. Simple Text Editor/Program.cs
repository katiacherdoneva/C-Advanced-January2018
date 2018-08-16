using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _10._Simple_Text_Editor
{
    class SimpleTextEditor
    {
        static void Main()
        {
            int countCommands = int.Parse(Console.ReadLine());
            Stack<string> oldText = new Stack<string>();
            oldText.Push("");
            StringBuilder text = new StringBuilder();

            for (int i = 0; i < countCommands; i++)
            {
                string[] commandOfArgs = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int numCommand = int.Parse(commandOfArgs[0]);

                switch (numCommand)
                {
                    case 1:
                        oldText.Push(text.ToString());
                        string newText = commandOfArgs[1];
                        text.Append(newText);
                        break;
                    case 2:
                        oldText.Push(text.ToString());
                        int length = int.Parse(commandOfArgs[1]);
                        text.Remove(text.Length - length, length);
                        break;
                    case 3:
                        int index = int.Parse(commandOfArgs[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case 4:
                        text.Clear();
                        text.Append(oldText.Pop());
                        break;
                }
            }
        }
    }
}

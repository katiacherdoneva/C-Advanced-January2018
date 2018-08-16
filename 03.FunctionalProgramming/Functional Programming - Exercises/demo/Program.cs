using System;
using System.Text;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;

            Func<int, int> number = (numb) => numb * 3;
            int num = number(2);
            Action<int> printNum = nums => Console.WriteLine(num);
            printNum(num);
        }
    }
}

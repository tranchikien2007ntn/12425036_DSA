using System;
using System.Text;

namespace BTC1sgkCTDLGT
{
    class Bai2
    {
        public static void Chay()
        {
            var sb = new StringBuilder();
            for (int i = 1; i <= 100; i++)
            {
                if (i % 15 == 0) sb.AppendLine("FizzBuzz");
                else if (i % 3 == 0) sb.AppendLine("Fizz");
                else if (i % 5 == 0) sb.AppendLine("Buzz");
                else sb.AppendLine(i.ToString());
            }
            Console.Write(sb.ToString());
        }
    }
}
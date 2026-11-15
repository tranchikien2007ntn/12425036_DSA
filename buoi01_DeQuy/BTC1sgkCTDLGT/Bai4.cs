using System;

namespace BTC1sgkCTDLGT
{
    class Bai4
    {
        public static void Chay()
        {
            const int N = 1000;
            var rd = new Random();
            int[] a = new int[N];
            for (int i = 0; i < N; i++)
                a[i] = rd.Next(0, 10000);

            Console.WriteLine("a. Mang ban dau:");
            Console.WriteLine(string.Join(" ", a));

            Array.Sort(a);

            Console.WriteLine("\nb. Mang sau khi sap xep tang dan:");
            Console.WriteLine(string.Join(" ", a));
        }
    }
}
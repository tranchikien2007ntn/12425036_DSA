using System;

namespace BTChuong1sgkCTDLGT
{
    class Bai1
    {
        public static void Chay()
        {
            const int N = 1000;
            var rd = new Random();
            int[] a = new int[N];
            int max = int.MinValue, min = int.MaxValue;

            for (int i = 0; i < N; i++)
            {
                a[i] = rd.Next(0, 10000);
                if (a[i] > max) max = a[i];
                if (a[i] < min) min = a[i];
            }

            Console.WriteLine($"a. So lon nhat: {max}");
            Console.WriteLine($"b. So nho nhat: {min}");
        }
    }
}
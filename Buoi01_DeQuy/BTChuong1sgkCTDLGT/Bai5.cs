using System;

namespace BTChuong1sgkCTDLGT
{
    class Bai5
    {
        public static void Chay()
        {
            const int MaxN = 93;
            int n;

            Console.Write($"Nhap so nguyen duong n (1 - {MaxN}): ");
            while (true)
            {
                string s = Console.ReadLine();
                if (s == null) return;
                if (int.TryParse(s, out n) && n >= 1 && n <= MaxN) break;
                Console.Write("Khong hop le, nhap lai: ");
            }

            ulong a = 0, b = 1;
            for (int i = 1; i < n; i++)
            {
                ulong t = a + b;
                a = b;
                b = t;
            }

            Console.WriteLine($"So Fibonacci thu {n} la: {a}");
        }
    }
}
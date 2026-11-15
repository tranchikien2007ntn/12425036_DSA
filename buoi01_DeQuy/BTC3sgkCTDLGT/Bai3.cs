using System;

namespace BTC3sgkCTDLGT
{
    class Bai3
    {
        static double S(int n)
        {
            if (n == 1) return 1;
            return S(n - 1) + 1.0 / n;
        }

        public static void Chay()
        {
            Console.WriteLine("=== BAI 3: S(n) = 1 + 1/2 + 1/3 + ... + 1/n ===");
            int n;
            Console.Write("Nhap n (1 - 5000): ");
            while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 5000)
                Console.Write("Khong hop le, nhap lai: ");

            Console.WriteLine($"S({n}) = {S(n):F6}");
        }
    }
}
using System;

namespace BTchuong3sgkCTDLGT
{
    class Bai2
    {
        static long S(int n)
        {
            if (n == 1) return 1;
            return S(n - 1) + (long)n * n;
        }

        public static void Chay()
        {
            Console.WriteLine("=== BAI 2: S(n) = 1 + 2^2 + 3^2 + ... + n^2 ===");
            int n;
            Console.Write("Nhap n (1 - 5000): ");
            while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 5000)
                Console.Write("Khong hop le, nhap lai: ");

            Console.WriteLine($"S({n}) = {S(n)}");
            Console.WriteLine($"Kiem tra bang cong thuc n(n+1)(2n+1)/6 = {(long)n * (n + 1) * (2L * n + 1) / 6}");
        }
    }
}
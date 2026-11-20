using System;

namespace BTchuong3sgkCTDLGT
{
    class Bai8
    {
        static double Can(int i, int n)
        {
            if (i == n) return Math.Sqrt(n);
            return Math.Sqrt(i + Can(i + 1, n));
        }

        static double S(int n)
        {
            return Can(1, n);
        }

        public static void Chay()
        {
            Console.WriteLine("=== BAI 8: S(n) = sqrt(1 + sqrt(2 + sqrt(3 + ... + sqrt(n)))) ===");
            int n;
            Console.Write("Nhap n (1 - 5000): ");
            while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 5000)
                Console.Write("Khong hop le, nhap lai: ");

            Console.WriteLine($"S({n}) = {S(n):F6}");
        }
    }
}
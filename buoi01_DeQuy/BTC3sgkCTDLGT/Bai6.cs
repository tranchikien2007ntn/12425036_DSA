using System;

namespace BTC3sgkCTDLGT
{
    class Bai6
    {
        static long UCLN(long a, long b)
        {
            if (a % b == 0) return b;
            return UCLN(b, a % b);
        }

        public static void Chay()
        {
            Console.WriteLine("=== BAI 6: UOC CHUNG LON NHAT (EUCLID) ===");
            long a, b;
            Console.Write("Nhap a (so nguyen duong): ");
            while (!long.TryParse(Console.ReadLine(), out a) || a < 1)
                Console.Write("Khong hop le, nhap lai: ");
            Console.Write("Nhap b (so nguyen duong): ");
            while (!long.TryParse(Console.ReadLine(), out b) || b < 1)
                Console.Write("Khong hop le, nhap lai: ");

            Console.WriteLine($"UCLN({a}, {b}) = {UCLN(a, b)}");
        }
    }
}
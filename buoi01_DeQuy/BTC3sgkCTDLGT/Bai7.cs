using System;

namespace BTC3sgkCTDLGT
{
    class Bai7
    {
        static int SoChuSo(long n)
        {
            if (n == 0) return 0;
            return SoChuSo(n / 10) + 1;
        }

        public static void Chay()
        {
            Console.WriteLine("=== BAI 7: DEM SO CHU SO CUA n ===");
            long n;
            Console.Write("Nhap so nguyen duong n: ");
            while (!long.TryParse(Console.ReadLine(), out n) || n < 1)
                Console.Write("Khong hop le, nhap lai: ");

            Console.WriteLine($"So {n} co {SoChuSo(n)} chu so");
        }
    }
}
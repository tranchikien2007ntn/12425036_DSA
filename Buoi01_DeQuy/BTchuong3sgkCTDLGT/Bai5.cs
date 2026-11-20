using System;

namespace BTchuong3sgkCTDLGT
{
    class Bai5
    {
        static long UocLeMax(long n)
        {
            if (n % 2 == 1) return n;
            return UocLeMax(n / 2);
        }

        public static void Chay()
        {
            Console.WriteLine("=== BAI 5: UOC LE LON NHAT CUA n ===");
            long n;
            Console.Write("Nhap so nguyen duong n: ");
            while (!long.TryParse(Console.ReadLine(), out n) || n < 1)
                Console.Write("Khong hop le, nhap lai: ");

            Console.WriteLine($"Uoc le lon nhat cua {n} la {UocLeMax(n)}");
        }
    }
}
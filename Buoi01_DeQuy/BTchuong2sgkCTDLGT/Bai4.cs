using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BTchuong2sgkCTDLGT
{
    class Bai4
    {
        const long GIOI_HAN_1 = 30000;
        const long GIOI_HAN_2 = 500000;

        static List<long> CoBan(long N)
        {
            var kq = new List<long>();
            int n = (int)N;
            for (int i = 2; i < n; i++)
            {
                int tong = 0;
                for (int d = 1; d < i; d++)
                    if (i % d == 0) tong += d;
                if (tong == i) kq.Add(i);
            }
            return kq;
        }

        static List<long> CaiTien(long N)
        {
            var kq = new List<long>();
            int n = (int)N;
            for (int i = 2; i < n; i++)
            {
                int tong = 1;
                for (int d = 2; d * d <= i; d++)
                {
                    if (i % d == 0)
                    {
                        tong += d;
                        int e = i / d;
                        if (e != d) tong += e;
                    }
                }
                if (tong == i) kq.Add(i);
            }
            return kq;
        }

        static bool NguyenTo(long m)
        {
            if (m < 2) return false;
            if (m % 2 == 0) return m == 2;
            for (long i = 3; i * i <= m; i += 2)
                if (m % i == 0) return false;
            return true;
        }

        // So hoan hao chan: 2^(p-1) * (2^p - 1) voi 2^p - 1 la so nguyen to
        static List<long> Euclid(long N)
        {
            var kq = new List<long>();
            for (int p = 2; p <= 32; p++)
            {
                long m = (1L << p) - 1;
                long so = (1L << (p - 1)) * m;
                if (so >= N) break;
                if (NguyenTo(m)) kq.Add(so);
            }
            return kq;
        }

        static void InKQ(string ten, bool chay, Func<List<long>> f)
        {
            if (!chay)
            {
                Console.WriteLine("{0,-26}: bo qua (N qua lon, chay rat lau)", ten);
                return;
            }
            var sw = Stopwatch.StartNew();
            List<long> ds = f();
            sw.Stop();
            Console.WriteLine("{0,-26}: {1} ({2:F2} ms)", ten, string.Join(", ", ds), sw.Elapsed.TotalMilliseconds);
        }

        static string Ms(bool chay, Func<List<long>> f)
        {
            if (!chay) return "-";
            var sw = Stopwatch.StartNew();
            f();
            sw.Stop();
            return sw.Elapsed.TotalMilliseconds.ToString("F3");
        }

        public static void Chay()
        {
            Console.WriteLine("=== BAI 4: LIET KE SO HOAN HAO < N ===");
            Console.WriteLine("Ly thuyet: GT1 (tim uoc 1..i-1)  : Theta(N^2)");
            Console.WriteLine("           GT2 (tim uoc toi sqrt): Theta(N*sqrt N)");
            Console.WriteLine("           GT3 (Euclid-Euler)    : ~O(N^(1/4)) (chi ra so hoan hao chan)\n");

            long N;
            Console.Write("Nhap N (>= 2): ");
            while (!long.TryParse(Console.ReadLine(), out N) || N < 2)
                Console.Write("Khong hop le, nhap lai: ");

            InKQ("GT1 co ban", N <= GIOI_HAN_1, () => CoBan(N));
            InKQ("GT2 cai tien", N <= GIOI_HAN_2, () => CaiTien(N));
            InKQ("GT3 Euclid-Euler", true, () => Euclid(N));

            CoBan(100); CaiTien(100); Euclid(100);
            Console.WriteLine("\nThuc nghiem (ms):");
            Console.WriteLine("{0,22} | {1,12} | {2,12} | {3,12}", "N", "GT1", "GT2", "GT3");
            foreach (long v in new long[] { 1000, 10000, 30000, 100000, 500000, 1000000000, 1000000000000000000L })
            {
                Console.WriteLine("{0,22:N0} | {1,12} | {2,12} | {3,12}", v,
                    Ms(v <= GIOI_HAN_1, () => CoBan(v)),
                    Ms(v <= GIOI_HAN_2, () => CaiTien(v)),
                    Ms(true, () => Euclid(v)));
            }
            Console.WriteLine("Nhan xet: GT1 tang rat nhanh theo N, GT3 gan nhu tuc thoi.");
        }
    }
}
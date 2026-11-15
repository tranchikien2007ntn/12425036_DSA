using System;
using System.Diagnostics;

namespace BTC2sgkCTDLGT
{
    class Bai3
    {
        const ulong GIOI_HAN_CO_BAN = 300000000;

        static bool CoBan(ulong n)
        {
            if (n < 2) return false;
            for (ulong i = 2; i < n; i++)
                if (n % i == 0) return false;
            return true;
        }

        static bool CaiTien(ulong n)
        {
            if (n < 2) return false;
            if (n % 2 == 0) return n == 2;
            for (ulong i = 3; i * i <= n; i += 2)
                if (n % i == 0) return false;
            return true;
        }

        static ulong LuyThuaMod(ulong co, ulong mu, ulong mod)
        {
            ulong kq = 1;
            co %= mod;
            while (mu > 0)
            {
                if ((mu & 1) == 1) kq = kq * co % mod;
                co = co * co % mod;
                mu >>= 1;
            }
            return kq;
        }

        // Xac dinh dung voi moi n < 2^32 (co so 2, 7, 61)
        static bool MillerRabin(ulong n)
        {
            if (n < 2) return false;
            ulong[] cs = { 2, 7, 61 };
            foreach (ulong a in cs)
            {
                if (n == a) return true;
                if (n % a == 0) return false;
            }

            ulong d = n - 1;
            int s = 0;
            while ((d & 1) == 0) { d >>= 1; s++; }

            foreach (ulong a in cs)
            {
                ulong x = LuyThuaMod(a, d, n);
                if (x == 1 || x == n - 1) continue;
                bool hopSo = true;
                for (int r = 1; r < s; r++)
                {
                    x = x * x % n;
                    if (x == n - 1) { hopSo = false; break; }
                }
                if (hopSo) return false;
            }
            return true;
        }

        static void Thu(string ten, Func<ulong, bool> f, ulong n, bool chay)
        {
            if (!chay)
            {
                Console.WriteLine("{0,-24}: bo qua (n qua lon, chay rat lau)", ten);
                return;
            }
            var sw = Stopwatch.StartNew();
            bool kq = f(n);
            sw.Stop();
            Console.WriteLine("{0,-24}: {1} ({2:F4} ms)", ten, kq ? "la so nguyen to" : "khong phai so nguyen to", sw.Elapsed.TotalMilliseconds);
        }

        static string Ms(Func<ulong, bool> f, ulong n, bool chay)
        {
            if (!chay) return "-";
            var sw = Stopwatch.StartNew();
            f(n);
            sw.Stop();
            return sw.Elapsed.TotalMilliseconds.ToString("F4");
        }

        public static void Chay()
        {
            Console.WriteLine("=== BAI 3: KIEM TRA SO NGUYEN TO ===");
            Console.WriteLine("Ly thuyet: GT1 (2..n-1)  : O(n), Omega(1) (n chan), Theta(n) khi n la so nguyen to");
            Console.WriteLine("           GT2 (2..sqrt n): O(sqrt n), Omega(1)");
            Console.WriteLine("           GT3 Miller-Rabin: O(k log n), k = so co so (k = 3)\n");

            ulong n;
            Console.Write("Nhap n (0 - 4294967295): ");
            while (!ulong.TryParse(Console.ReadLine(), out n) || n > uint.MaxValue)
                Console.Write("Khong hop le, nhap lai: ");

            Thu("GT1 duyet 2..n-1", CoBan, n, n <= GIOI_HAN_CO_BAN);
            Thu("GT2 duyet 2..sqrt(n)", CaiTien, n, true);
            Thu("GT3 Miller-Rabin", MillerRabin, n, true);

            CoBan(7); CaiTien(7); MillerRabin(7);
            Console.WriteLine("\nThuc nghiem (ms), cac so deu la so nguyen to:");
            Console.WriteLine("{0,14} | {1,12} | {2,12} | {3,12}", "n", "GT1", "GT2", "GT3");
            foreach (ulong v in new ulong[] { 10007, 1000003, 100000007, 4294967291 })
            {
                Console.WriteLine("{0,14:N0} | {1,12} | {2,12} | {3,12}", v,
                    Ms(CoBan, v, v <= GIOI_HAN_CO_BAN),
                    Ms(CaiTien, v, true),
                    Ms(MillerRabin, v, true));
            }
            Console.WriteLine("Nhan xet: GT1 tang tuyen tinh theo n, GT2 tang theo can n, GT3 gan nhu khong doi.");
        }
    }
}
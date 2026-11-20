using System;
using System.Diagnostics;

namespace BTchuong2sgkCTDLGT
{
    class Bai5
    {
        const ulong MOD = 1000000007;
        static ulong sink;

        // mod = 0: tinh chinh xac (dung duoc toi F93); mod > 0: tinh F(n) % mod
        static ulong Cong(ulong a, ulong b, ulong mod)
        {
            return unchecked(mod == 0 ? a + b : (a + b) % mod);
        }

        static ulong Nhan(ulong a, ulong b, ulong mod)
        {
            return unchecked(mod == 0 ? a * b : a * b % mod);
        }

        static ulong DeQuy(int n, ulong mod)
        {
            if (n < 2) return (ulong)n;
            return Cong(DeQuy(n - 1, mod), DeQuy(n - 2, mod), mod);
        }

        static ulong Lap(int n, ulong mod)
        {
            ulong a = 0, b = 1;
            for (int i = 0; i < n; i++)
            {
                ulong t = Cong(a, b, mod);
                a = b;
                b = t;
            }
            return a;
        }

        static ulong Nho(int n, ulong[] memo, bool[] da, ulong mod)
        {
            if (n < 2) return (ulong)n;
            if (da[n]) return memo[n];
            memo[n] = Cong(Nho(n - 1, memo, da, mod), Nho(n - 2, memo, da, mod), mod);
            da[n] = true;
            return memo[n];
        }

        static ulong NhoDeQuy(int n, ulong mod)
        {
            return Nho(n, new ulong[n + 2], new bool[n + 2], mod);
        }

        static ulong[] Nhan2x2(ulong[] x, ulong[] y, ulong mod)
        {
            return new ulong[]
            {
                Cong(Nhan(x[0], y[0], mod), Nhan(x[1], y[2], mod), mod),
                Cong(Nhan(x[0], y[1], mod), Nhan(x[1], y[3], mod), mod),
                Cong(Nhan(x[2], y[0], mod), Nhan(x[3], y[2], mod), mod),
                Cong(Nhan(x[2], y[1], mod), Nhan(x[3], y[3], mod), mod)
            };
        }

        static ulong MaTran(int n, ulong mod)
        {
            ulong[] kq = { 1, 0, 0, 1 };
            ulong[] co = { 1, 1, 1, 0 };
            while (n > 0)
            {
                if ((n & 1) == 1) kq = Nhan2x2(kq, co, mod);
                co = Nhan2x2(co, co, mod);
                n >>= 1;
            }
            return kq[1];
        }

        static string Ms(Func<ulong> f)
        {
            var sw = Stopwatch.StartNew();
            sink ^= f();
            sw.Stop();
            return sw.Elapsed.TotalMilliseconds.ToString("F4");
        }

        public static void Chay()
        {
            Console.WriteLine("=== BAI 5: SO FIBONACCI THU n ===");
            Console.WriteLine("F0 = 0, F1 = 1, Fn = Fn-1 + Fn-2");
            Console.WriteLine("Ly thuyet: GT1 De quy truc tiep : Theta(phi^n) ~ O(2^n), phi = 1.618");
            Console.WriteLine("           GT2 Vong lap         : Theta(n)");
            Console.WriteLine("           GT3 De quy co nho    : Theta(n) thoi gian, O(n) bo nho");
            Console.WriteLine("           GT4 Luy thua ma tran : Theta(log n)\n");

            int n;
            Console.Write("Nhap n (0 - 93): ");
            while (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n > 93)
                Console.Write("Khong hop le, nhap lai: ");

            if (n <= 40) Console.WriteLine("GT1 De quy        : " + DeQuy(n, 0));
            else Console.WriteLine("GT1 De quy        : bo qua (n > 40 chay rat lau)");
            Console.WriteLine("GT2 Vong lap      : " + Lap(n, 0));
            Console.WriteLine("GT3 De quy co nho : " + NhoDeQuy(n, 0));
            Console.WriteLine("GT4 Ma tran       : " + MaTran(n, 0));

            DeQuy(10, MOD); Lap(10, MOD); NhoDeQuy(10, MOD); MaTran(10, MOD);
            Console.WriteLine("\nThuc nghiem (ms), tinh F(n) mod 1.000.000.007 de tranh tran so:");
            Console.WriteLine("{0,12} | {1,12} | {2,12} | {3,12} | {4,12}", "n", "GT1", "GT2", "GT3", "GT4");
            foreach (int k in new[] { 20, 30, 40, 1000, 5000, 1000000, 100000000 })
            {
                string t1 = k <= 40 ? Ms(() => DeQuy(k, MOD)) : "-";
                string t2 = Ms(() => Lap(k, MOD));
                string t3 = k <= 5000 ? Ms(() => NhoDeQuy(k, MOD)) : "-";
                string t4 = Ms(() => MaTran(k, MOD));
                Console.WriteLine("{0,12:N0} | {1,12} | {2,12} | {3,12} | {4,12}", k, t1, t2, t3, t4);
            }
            Console.WriteLine("Nhan xet: GT1 bung no theo n, GT2/GT3 tang tuyen tinh, GT4 gan nhu khong doi.");
            Console.WriteLine("(GT3 bi gioi han n <= 5000 vi de quy qua sau se tran ngan xep)");
        }
    }
}
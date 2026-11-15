using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BTC2sgkCTDLGT
{
    class Bai1
    {
        struct Frame
        {
            public int N;
            public char Tu, Qua, Den;
            public Frame(int n, char tu, char qua, char den) { N = n; Tu = tu; Qua = qua; Den = den; }
        }

        static long dem;
        static bool inBuoc;

        static void Chuyen(char tu, char den)
        {
            dem++;
            if (inBuoc) Console.WriteLine(tu + " -> " + den);
        }

        static void DeQuy(int n, char tu, char qua, char den)
        {
            if (n == 1) { Chuyen(tu, den); return; }
            DeQuy(n - 1, tu, den, qua);
            Chuyen(tu, den);
            DeQuy(n - 1, qua, tu, den);
        }

        static long ChayDeQuy(int n)
        {
            dem = 0;
            DeQuy(n, 'A', 'B', 'C');
            return dem;
        }

        static long LapNganXep(int n)
        {
            dem = 0;
            var st = new Stack<Frame>();
            st.Push(new Frame(n, 'A', 'B', 'C'));
            while (st.Count > 0)
            {
                Frame f = st.Pop();
                if (f.N <= 1) Chuyen(f.Tu, f.Den);
                else
                {
                    st.Push(new Frame(f.N - 1, f.Qua, f.Tu, f.Den));
                    st.Push(new Frame(0, f.Tu, ' ', f.Den));
                    st.Push(new Frame(f.N - 1, f.Tu, f.Den, f.Qua));
                }
            }
            return dem;
        }

        public static void Chay()
        {
            Console.WriteLine("=== BAI 1: THAP HA NOI ===");
            Console.WriteLine("T(n) = 2T(n-1) + 1, T(1) = 1  =>  T(n) = 2^n - 1");
            Console.WriteLine("Ly thuyet: O(2^n), Omega(2^n), Theta(2^n); bo nho O(n)\n");

            int n;
            Console.Write("Nhap so dia n (1 - 25): ");
            while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 25)
                Console.Write("Khong hop le, nhap lai: ");

            if (n <= 4) Console.WriteLine("Cac buoc chuyen:");
            inBuoc = n <= 4;
            long a = ChayDeQuy(n);
            inBuoc = false;
            long b = LapNganXep(n);
            Console.WriteLine($"So buoc: de quy = {a}, lap = {b}, 2^n - 1 = {(1L << n) - 1}");

            Console.WriteLine("\nThuc nghiem (ms):");
            Console.WriteLine("{0,4} | {1,12} | {2,10} | {3,10}", "n", "So buoc", "De quy", "Lap(stack)");
            foreach (int k in new[] { 10, 15, 20, 25 })
            {
                var sw = Stopwatch.StartNew();
                long s = ChayDeQuy(k);
                double t1 = sw.Elapsed.TotalMilliseconds;
                sw.Restart();
                LapNganXep(k);
                double t2 = sw.Elapsed.TotalMilliseconds;
                Console.WriteLine("{0,4} | {1,12:N0} | {2,10:F2} | {3,10:F2}", k, s, t1, t2);
            }
            Console.WriteLine("Nhan xet: n tang 1 thi thoi gian tang gap doi (Theta(2^n)).");
        }
    }
}
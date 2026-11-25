using System;
using System.Diagnostics;

namespace BTchuong2sgkCTDLGT
{
    class Bai2
    {
        static int sink;

        static int NhiPhanLap(int[] a, int x)
        {
            int l = 0, r = a.Length - 1;
            while (l <= r)
            {
                int m = l + ((r - l) >> 1);
                if (a[m] == x) return m;
                if (a[m] < x) l = m + 1; else r = m - 1;
            }
            return -1;
        }

        static int NhiPhanDeQuy(int[] a, int x, int l, int r)
        {
            if (l > r) return -1;
            int m = l + ((r - l) >> 1);
            if (a[m] == x) return m;
            return a[m] < x ? NhiPhanDeQuy(a, x, m + 1, r) : NhiPhanDeQuy(a, x, l, m - 1);
        }

        static int TuyenTinh(int[] a, int x)
        {
            for (int i = 0; i < a.Length; i++)
                if (a[i] == x) return i;
            return -1;
        }

        static void InViTri(string ten, int vt)
        {
            Console.WriteLine(ten + ": " + (vt >= 0 ? "vi tri " + vt : "khong tim thay"));
        }

        static double NsMoiLan(Func<int[], int, int> f, int[] a, int[] keys)
        {
            var sw = Stopwatch.StartNew();
            int s = 0;
            for (int i = 0; i < keys.Length; i++) s += f(a, keys[i]);
            sw.Stop();
            sink += s;
            return sw.Elapsed.TotalMilliseconds * 1e6 / keys.Length;
        }

        public static void Chay()
        {
            Console.WriteLine("=== BAI 2: TIM KIEM NHI PHAN ===");
            Console.WriteLine("T(n) = T(n/2) + 1, T(1) = 1  =>  T(n) = log2(n) + 1");
            Console.WriteLine("Ly thuyet: Nhi phan : O(log n), Omega(1), Theta(log n) (xau nhat/trung binh)");
            Console.WriteLine("           Tuyen tinh: O(n),     Omega(1), Theta(n)     (xau nhat/trung binh)\n");

            int[] mau = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };
            Console.WriteLine("Mang mau: " + string.Join(", ", mau));
            int x;
            Console.Write("Nhap gia tri can tim: ");
            while (!int.TryParse(Console.ReadLine(), out x))
                Console.Write("Khong hop le, nhap lai: ");

            InViTri("Nhi phan (lap)   ", NhiPhanLap(mau, x));
            InViTri("Nhi phan (de quy)", NhiPhanDeQuy(mau, x, 0, mau.Length - 1));
            InViTri("Tuyen tinh       ", TuyenTinh(mau, x));

            Func<int[], int, int> deQuy = (arr, k) => NhiPhanDeQuy(arr, k, 0, arr.Length - 1);
            NsMoiLan(NhiPhanLap, mau, new[] { 5 });
            NsMoiLan(deQuy, mau, new[] { 5 });
            NsMoiLan(TuyenTinh, mau, new[] { 5 });

            Console.WriteLine("\nThuc nghiem (ns / 1 lan tim, khoa ngau nhien):");
            Console.WriteLine("{0,12} | {1,14} | {2,14} | {3,14}", "n", "Nhi phan lap", "Nhi phan DQ", "Tuyen tinh");
            var rd = new Random(1);
            foreach (int n in new[] { 100000, 1000000, 10000000 })
            {
                int[] a = new int[n];
                for (int i = 0; i < n; i++) a[i] = 2 * i;

                int[] keys = new int[100000];
                for (int i = 0; i < keys.Length; i++) keys[i] = rd.Next(0, 2 * n);
                int[] keysTT = new int[100];
                Array.Copy(keys, keysTT, keysTT.Length);

                double t1 = NsMoiLan(NhiPhanLap, a, keys);
                double t2 = NsMoiLan(deQuy, a, keys);
                double t3 = NsMoiLan(TuyenTinh, a, keysTT);
                Console.WriteLine("{0,12:N0} | {1,14:F1} | {2,14:F1} | {3,14:F1}", n, t1, t2, t3);
            }
            Console.WriteLine("Nhan xet: n tang 10 lan, nhi phan gan nhu khong doi, tuyen tinh tang ~10 lan.");
        }
    }
}
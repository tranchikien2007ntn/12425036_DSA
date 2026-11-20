using System;
using System.Collections.Generic;

namespace Buoi02_DanhSach
{
    // Thuc hanh 9: Tach cac so nguyen to, so chan va so hoan hao.
    static class TH09
    {
        static bool LaSoNguyenTo(int n)
        {
            if (n < 2)
            {
                return false;
            }

            for (int i = 2; i <= n / i; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static bool LaSoHoanHao(int n)
        {
            if (n < 2)
            {
                return false;
            }

            // Tong cac uoc duong nho hon n.
            int tongUoc = 1;
            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    tongUoc += i;
                }
            }

            return tongUoc == n;
        }

        static void InDanhSach(string tieuDe, List<int> danhSach)
        {
            Console.Write(tieuDe + ": ");

            if (danhSach.Count == 0)
            {
                Console.WriteLine("(khong co)");
                return;
            }

            for (int i = 0; i < danhSach.Count; i++)
            {
                Console.Write(danhSach[i] + " ");
            }
            Console.WriteLine();
        }

        public static void Chay()
        {
            Console.Write("Nhap so phan tu n: ");
            int n = int.Parse(Console.ReadLine());

            if (n < 0)
            {
                Console.WriteLine("n khong duoc am!");
                return;
            }

            int[] mang = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("mang[{0}] = ", i);
                mang[i] = int.Parse(Console.ReadLine());
            }

            List<int> danhSachNguyenTo = new List<int>();
            List<int> danhSachSoChan = new List<int>();
            List<int> danhSachHoanHao = new List<int>();

            for (int i = 0; i < mang.Length; i++)
            {
                int giaTri = mang[i];

                if (LaSoNguyenTo(giaTri))
                {
                    danhSachNguyenTo.Add(giaTri);
                }

                if (giaTri % 2 == 0)
                {
                    danhSachSoChan.Add(giaTri);
                }

                if (LaSoHoanHao(giaTri))
                {
                    danhSachHoanHao.Add(giaTri);
                }
            }

            Console.WriteLine();
            InDanhSach("Cac so nguyen to", danhSachNguyenTo);
            InDanhSach("Cac so chan", danhSachSoChan);
            InDanhSach("Cac so hoan hao", danhSachHoanHao);
        }
    }
}
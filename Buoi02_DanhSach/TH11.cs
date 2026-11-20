using System;

namespace Buoi02_DanhSach
{
    // Thuc hanh 11: Kiem tra ma tran don vi va ma tran doi xung.
    static class TH11
    {
        static bool LaMaTranDonVi(int[,] maTran, int cap)
        {
            for (int i = 0; i < cap; i++)
            {
                for (int j = 0; j < cap; j++)
                {
                    // Tren duong cheo chinh phai bang 1.
                    if (i == j && maTran[i, j] != 1)
                    {
                        return false;
                    }

                    // Ngoai duong cheo chinh phai bang 0.
                    if (i != j && maTran[i, j] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static bool LaMaTranDoiXung(int[,] maTran, int cap)
        {
            for (int i = 0; i < cap; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    // Hai phan tu doi xung qua duong cheo chinh phai bang nhau.
                    if (maTran[i, j] != maTran[j, i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void Chay()
        {
            Console.Write("Nhap cap n cua ma tran vuong: ");
            int n = int.Parse(Console.ReadLine());

            if (n <= 0)
            {
                Console.WriteLine("Cap ma tran phai lon hon 0!");
                return;
            }

            int[,] maTran = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("a[{0},{1}] = ", i, j);
                    maTran[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("\nMa tran vua nhap:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,5}", maTran[i, j]);
                }
                Console.WriteLine();
            }

            if (LaMaTranDonVi(maTran, n))
            {
                Console.WriteLine("\nDay la ma tran don vi.");
            }
            else
            {
                Console.WriteLine("\nKhong phai ma tran don vi.");
            }

            if (LaMaTranDoiXung(maTran, n))
            {
                Console.WriteLine("Day la ma tran doi xung.");
            }
            else
            {
                Console.WriteLine("Khong phai ma tran doi xung.");
            }
        }
    }
}
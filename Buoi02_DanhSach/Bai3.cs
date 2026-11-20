using System;

namespace Buoi02_DanhSach
{
    // Bai 3: Cac phep tinh tren ma tran vuong.
    static class Bai3
    {
        static int[,] maTran;
        static int capMaTran;

        static void NhapMaTran()
        {
            Console.Write("Nhap cap ma tran n (0 <= n < 100): ");
            capMaTran = int.Parse(Console.ReadLine());

            if (capMaTran < 0 || capMaTran >= 100)
            {
                Console.WriteLine("Cap ma tran khong hop le!");
                capMaTran = 0;
            }

            maTran = new int[capMaTran, capMaTran];

            for (int i = 0; i < capMaTran; i++)
            {
                for (int j = 0; j < capMaTran; j++)
                {
                    Console.Write("a[{0},{1}] = ", i, j);
                    maTran[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        static void InMaTran()
        {
            for (int i = 0; i < capMaTran; i++)
            {
                for (int j = 0; j < capMaTran; j++)
                {
                    Console.Write("{0,5}", maTran[i, j]);
                }
                Console.WriteLine();
            }
        }

        static long TinhTongPhanTu()
        {
            long tong = 0;
            for (int i = 0; i < capMaTran; i++)
            {
                for (int j = 0; j < capMaTran; j++)
                {
                    tong += maTran[i, j];
                }
            }
            return tong;
        }

        // Tra ve so duong nho nhat; int.MaxValue nghia la khong co so duong.
        static int TimSoDuongNhoNhat()
        {
            int nhoNhat = int.MaxValue;
            for (int i = 0; i < capMaTran; i++)
            {
                for (int j = 0; j < capMaTran; j++)
                {
                    if (maTran[i, j] > 0 && maTran[i, j] < nhoNhat)
                    {
                        nhoNhat = maTran[i, j];
                    }
                }
            }
            return nhoNhat;
        }

        static long TinhTongCheoPhu()
        {
            long tong = 0;
            for (int i = 0; i < capMaTran; i++)
            {
                tong += maTran[i, capMaTran - 1 - i];
            }
            return tong;
        }

        // Kiem tra cac phan tu tren duong cheo chinh co tang dan hay khong.
        static bool KiemTraCheoChinhTangDan()
        {
            for (int i = 1; i < capMaTran; i++)
            {
                if (maTran[i, i] <= maTran[i - 1, i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        public static void Chay()
        {
            NhapMaTran();

            Console.WriteLine("\nMa tran vua nhap:");
            InMaTran();

            Console.WriteLine("\na. Tong cac phan tu: " + TinhTongPhanTu());

            int soDuongNhoNhat = TimSoDuongNhoNhat();
            if (soDuongNhoNhat == int.MaxValue)
            {
                Console.WriteLine("b. Ma tran khong co so duong.");
            }
            else
            {
                Console.WriteLine("b. So duong nho nhat: " + soDuongNhoNhat);
            }

            Console.WriteLine("c. Tong duong cheo phu: " + TinhTongCheoPhu());

            if (KiemTraCheoChinhTangDan())
            {
                Console.WriteLine("d. Duong cheo chinh tang dan.");
            }
            else
            {
                Console.WriteLine("d. Duong cheo chinh khong tang dan.");
            }
        }
    }
}
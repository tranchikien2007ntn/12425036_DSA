using System;

namespace Buoi02_DanhSach
{
    // Bai 1: Chen mot phan tu vao mang mot chieu.
    static class Bai1
    {
        static int[] mang;

        // Nhap mang tu ban phim.
        static void NhapMang()
        {
            Console.Write("Nhap so phan tu n: ");
            int n = int.Parse(Console.ReadLine());

            if (n < 0)
            {
                Console.WriteLine("So phan tu phai lon hon hoac bang 0!");
                n = 0;
            }

            mang = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("mang[{0}] = ", i);
                mang[i] = int.Parse(Console.ReadLine());
            }
        }

        // In cac phan tu cua mang.
        static void XuatMang()
        {
            for (int i = 0; i < mang.Length; i++)
            {
                Console.Write(mang[i] + " ");
            }
            Console.WriteLine();
        }

        // Chen gia tri x vao vi tri k.
        static void ChenPhanTu(int x, int k)
        {
            int[] mangMoi = new int[mang.Length + 1];

            // Sao chep cac phan tu dung truoc vi tri chen.
            for (int i = 0; i < k; i++)
            {
                mangMoi[i] = mang[i];
            }

            // Gan x vao vi tri can chen.
            mangMoi[k] = x;

            // Sao chep cac phan tu con lai sang phai 1 vi tri.
            for (int i = k; i < mang.Length; i++)
            {
                mangMoi[i + 1] = mang[i];
            }

            mang = mangMoi;
        }

        public static void Chay()
        {
            NhapMang();

            Console.Write("Mang ban dau: ");
            XuatMang();

            Console.Write("Nhap gia tri x can chen: ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Nhap vi tri k (tu 0 den {0}): ", mang.Length);
            int k = int.Parse(Console.ReadLine());

            if (k < 0 || k > mang.Length)
            {
                Console.WriteLine("Vi tri chen khong hop le!");
                return;
            }

            ChenPhanTu(x, k);

            Console.Write("Mang sau khi chen: ");
            XuatMang();
        }
    }
}
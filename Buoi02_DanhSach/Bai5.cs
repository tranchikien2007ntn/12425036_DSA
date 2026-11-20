using System;

namespace Buoi02_DanhSach
{
    // Bai 5: Cac thao tac nang cao tren danh sach lien ket don.
    static class Bai5
    {
        class Node
        {
            public int GiaTri;
            public Node TiepTheo;
        }

        static Node dau;

        static void ThemCuoi(int giaTri)
        {
            Node nutMoi = new Node();
            nutMoi.GiaTri = giaTri;

            if (dau == null)
            {
                dau = nutMoi;
                return;
            }

            Node hienTai = dau;
            while (hienTai.TiepTheo != null)
            {
                hienTai = hienTai.TiepTheo;
            }
            hienTai.TiepTheo = nutMoi;
        }

        static void NhapDanhSach()
        {
            dau = null;
            Console.Write("Nhap so phan tu n: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write("Phan tu thu {0}: ", i + 1);
                ThemCuoi(int.Parse(Console.ReadLine()));
            }
        }

        static void InDanhSach()
        {
            Node hienTai = dau;
            while (hienTai != null)
            {
                Console.Write(hienTai.GiaTri + " ");
                hienTai = hienTai.TiepTheo;
            }
            Console.WriteLine();
        }

        static int TimGiaTriLonNhat()
        {
            int lonNhat = dau.GiaTri;
            Node hienTai = dau;

            while (hienTai != null)
            {
                if (hienTai.GiaTri > lonNhat)
                {
                    lonNhat = hienTai.GiaTri;
                }
                hienTai = hienTai.TiepTheo;
            }
            return lonNhat;
        }

        static long TinhTong()
        {
            long tong = 0;
            Node hienTai = dau;

            while (hienTai != null)
            {
                tong += hienTai.GiaTri;
                hienTai = hienTai.TiepTheo;
            }
            return tong;
        }

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

        static int DemSoNguyenTo()
        {
            int dem = 0;
            Node hienTai = dau;

            while (hienTai != null)
            {
                if (LaSoNguyenTo(hienTai.GiaTri))
                {
                    dem++;
                }
                hienTai = hienTai.TiepTheo;
            }
            return dem;
        }

        static void DemAmKhongDuong(out int soAm, out int soKhong, out int soDuong)
        {
            soAm = 0;
            soKhong = 0;
            soDuong = 0;

            Node hienTai = dau;
            while (hienTai != null)
            {
                if (hienTai.GiaTri < 0)
                {
                    soAm++;
                }
                else if (hienTai.GiaTri == 0)
                {
                    soKhong++;
                }
                else
                {
                    soDuong++;
                }
                hienTai = hienTai.TiepTheo;
            }
        }

        static int DemSoLanXuatHien(int x)
        {
            int dem = 0;
            Node hienTai = dau;

            while (hienTai != null)
            {
                if (hienTai.GiaTri == x)
                {
                    dem++;
                }
                hienTai = hienTai.TiepTheo;
            }
            return dem;
        }

        static int TimSoDuongNhoNhat()
        {
            int nhoNhat = int.MaxValue;
            Node hienTai = dau;

            while (hienTai != null)
            {
                if (hienTai.GiaTri > 0 && hienTai.GiaTri < nhoNhat)
                {
                    nhoNhat = hienTai.GiaTri;
                }
                hienTai = hienTai.TiepTheo;
            }
            return nhoNhat;
        }

        public static void Chay()
        {
            NhapDanhSach();

            if (dau == null)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }

            Console.Write("Danh sach: ");
            InDanhSach();

            Console.WriteLine("\na. Phan tu lon nhat: " + TimGiaTriLonNhat());
            Console.WriteLine("b. Tong cac phan tu: " + TinhTong());
            Console.WriteLine("c. So luong so nguyen to: " + DemSoNguyenTo());

            int soAm, soKhong, soDuong;
            DemAmKhongDuong(out soAm, out soKhong, out soDuong);
            Console.WriteLine("d. So am: {0}, so 0: {1}, so duong: {2}", soAm, soKhong, soDuong);

            Console.Write("e. Nhap x can dem: ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("So lan xuat hien cua {0}: {1}", x, DemSoLanXuatHien(x));

            int soDuongNhoNhat = TimSoDuongNhoNhat();
            if (soDuongNhoNhat == int.MaxValue)
            {
                Console.WriteLine("f. Danh sach khong co phan tu duong.");
            }
            else
            {
                Console.WriteLine("f. Phan tu duong nho nhat: " + soDuongNhoNhat);
            }
        }
    }
}
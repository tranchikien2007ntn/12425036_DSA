using System;

namespace Buoi02_DanhSach
{
    // Bai 4: Danh sach lien ket don co ban.
    static class Bai4
    {
        class Node
        {
            public int GiaTri;
            public Node TiepTheo;
        }

        static Node dau;

        // Them mot nut vao cuoi danh sach.
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
                int giaTri = int.Parse(Console.ReadLine());
                ThemCuoi(giaTri);
            }
        }

        static void InDanhSach()
        {
            if (dau == null)
            {
                Console.WriteLine("Danh sach rong.");
                return;
            }

            Node hienTai = dau;
            while (hienTai != null)
            {
                Console.Write(hienTai.GiaTri + " ");
                hienTai = hienTai.TiepTheo;
            }
            Console.WriteLine();
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

        // Xoa lan xuat hien dau tien cua x trong danh sach.
        static bool XoaPhanTu(int x)
        {
            Node hienTai = dau;
            Node truocDo = null;

            while (hienTai != null && hienTai.GiaTri != x)
            {
                truocDo = hienTai;
                hienTai = hienTai.TiepTheo;
            }

            if (hienTai == null)
            {
                return false;
            }

            // Neu nut can xoa la nut dau tien thi cap nhat dau.
            if (truocDo == null)
            {
                dau = hienTai.TiepTheo;
            }
            else
            {
                truocDo.TiepTheo = hienTai.TiepTheo;
            }
            return true;
        }

        public static void Chay()
        {
            NhapDanhSach();

            Console.Write("Danh sach: ");
            InDanhSach();

            Console.Write("\na. Nhap x can dem: ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("So lan xuat hien cua {0}: {1}", x, DemSoLanXuatHien(x));

            int soDuongNhoNhat = TimSoDuongNhoNhat();
            if (soDuongNhoNhat == int.MaxValue)
            {
                Console.WriteLine("b. Danh sach khong co phan tu duong.");
            }
            else
            {
                Console.WriteLine("b. Phan tu duong nho nhat: " + soDuongNhoNhat);
            }

            Console.Write("c. Nhap x can xoa: ");
            int giaTriCanXoa = int.Parse(Console.ReadLine());
            if (XoaPhanTu(giaTriCanXoa))
            {
                Console.WriteLine("Da xoa gia tri {0}.", giaTriCanXoa);
            }
            else
            {
                Console.WriteLine("Khong tim thay gia tri {0}.", giaTriCanXoa);
            }

            Console.Write("Danh sach sau khi xoa: ");
            InDanhSach();
        }
    }
}
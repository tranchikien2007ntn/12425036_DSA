using System;

namespace Buoi02_DanhSach
{
    // Thuc hanh 14: Gop hai danh sach lien ket da sap xep tang dan.
    static class TH14
    {
        class Node
        {
            public int GiaTri;
            public Node TiepTheo;
        }

        static Node NhapDanhSach()
        {
            Console.Write("Nhap so phan tu n: ");
            int n = int.Parse(Console.ReadLine());

            Node dau = null;
            Node cuoi = null;

            for (int i = 0; i < n; i++)
            {
                Console.Write("Phan tu thu {0} (nhap tang dan): ", i + 1);
                Node nutMoi = new Node();
                nutMoi.GiaTri = int.Parse(Console.ReadLine());

                if (dau == null)
                {
                    dau = nutMoi;
                }
                else
                {
                    cuoi.TiepTheo = nutMoi;
                }
                cuoi = nutMoi;
            }

            return dau;
        }

        static void InDanhSach(Node dau)
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

        static bool KiemTraTangDan(Node dau)
        {
            Node hienTai = dau;

            while (hienTai != null && hienTai.TiepTheo != null)
            {
                if (hienTai.GiaTri > hienTai.TiepTheo.GiaTri)
                {
                    return false;
                }
                hienTai = hienTai.TiepTheo;
            }
            return true;
        }

        static Node GopHaiDanhSach(Node danhSach1, Node danhSach2)
        {
            // Nut gia de de noi cac nut cua hai danh sach.
            Node nutGia = new Node();
            Node nutCuoiKetQua = nutGia;

            while (danhSach1 != null && danhSach2 != null)
            {
                if (danhSach1.GiaTri <= danhSach2.GiaTri)
                {
                    nutCuoiKetQua.TiepTheo = danhSach1;
                    danhSach1 = danhSach1.TiepTheo;
                }
                else
                {
                    nutCuoiKetQua.TiepTheo = danhSach2;
                    danhSach2 = danhSach2.TiepTheo;
                }

                nutCuoiKetQua = nutCuoiKetQua.TiepTheo;
            }

            // Noi phan con lai (neu co) vao cuoi ket qua.
            if (danhSach1 != null)
            {
                nutCuoiKetQua.TiepTheo = danhSach1;
            }
            else
            {
                nutCuoiKetQua.TiepTheo = danhSach2;
            }

            return nutGia.TiepTheo;
        }

        public static void Chay()
        {
            Console.WriteLine("--- NHAP DANH SACH THU NHAT ---");
            Node danhSach1 = NhapDanhSach();

            Console.WriteLine("--- NHAP DANH SACH THU HAI ---");
            Node danhSach2 = NhapDanhSach();

            if (!KiemTraTangDan(danhSach1) || !KiemTraTangDan(danhSach2))
            {
                Console.WriteLine("Hai danh sach phai duoc sap xep tang dan!");
                return;
            }

            Console.Write("Danh sach 1: ");
            InDanhSach(danhSach1);
            Console.Write("Danh sach 2: ");
            InDanhSach(danhSach2);

            Node ketQua = GopHaiDanhSach(danhSach1, danhSach2);
            Console.Write("Danh sach sau khi gop: ");
            InDanhSach(ketQua);
        }
    }
}
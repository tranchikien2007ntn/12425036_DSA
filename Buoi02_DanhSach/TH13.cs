using System;

namespace Buoi02_DanhSach
{
    // Thuc hanh 13: Dao nguoc thu tu cac nut cua danh sach lien ket don.
    static class TH13
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
                Console.Write("Phan tu thu {0}: ", i + 1);
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

        static Node DaoNguocDanhSach(Node dau)
        {
            Node nutTruoc = null;
            Node nutHienTai = dau;

            while (nutHienTai != null)
            {
                // Luu nut phia sau de khong mat phan con lai cua danh sach.
                Node nutTiepTheo = nutHienTai.TiepTheo;

                // Dao chieu mui ten lien ket cua nut hien tai.
                nutHienTai.TiepTheo = nutTruoc;

                nutTruoc = nutHienTai;
                nutHienTai = nutTiepTheo;
            }

            // nutTruoc la nut dau moi sau khi dao nguoc.
            return nutTruoc;
        }

        public static void Chay()
        {
            Node dau = NhapDanhSach();

            Console.Write("Danh sach ban dau: ");
            InDanhSach(dau);

            dau = DaoNguocDanhSach(dau);

            Console.Write("Danh sach sau khi dao nguoc: ");
            InDanhSach(dau);
        }
    }
}
using System;

namespace Buoi02_DanhSach
{
    // Thuc hanh 16: Mo phong nut Back va Forward cua trinh duyet web.
    static class TH16
    {
        class Node
        {
            public string DiaChi;
            public Node Truoc;
            public Node Sau;
        }

        static Node dau;
        static Node trangHienTai;

        static void TruyCapTrangMoi(string diaChi)
        {
            Node trangMoi = new Node();
            trangMoi.DiaChi = diaChi;

            if (trangHienTai == null)
            {
                dau = trangMoi;
            }
            else
            {
                // Khi mo trang moi sau khi Back, nhanh Forward cu se bi bo.
                trangHienTai.Sau = trangMoi;
                trangMoi.Truoc = trangHienTai;
            }

            trangHienTai = trangMoi;
        }

        static void QuayLai()
        {
            if (trangHienTai == null || trangHienTai.Truoc == null)
            {
                Console.WriteLine("Khong the quay lai!");
            }
            else
            {
                trangHienTai = trangHienTai.Truoc;
            }
        }

        static void DiTiep()
        {
            if (trangHienTai == null || trangHienTai.Sau == null)
            {
                Console.WriteLine("Khong the di tiep!");
            }
            else
            {
                trangHienTai = trangHienTai.Sau;
            }
        }

        static void XemLichSu()
        {
            if (dau == null)
            {
                Console.WriteLine("Lich su dang trong.");
                return;
            }

            Node hienTai = dau;
            while (hienTai != null)
            {
                Console.Write(hienTai.DiaChi);

                if (hienTai == trangHienTai)
                {
                    Console.Write("  <-- Trang hien tai");
                }

                Console.WriteLine();
                hienTai = hienTai.Sau;
            }
        }

        public static void Chay()
        {
            dau = null;
            trangHienTai = null;

            while (true)
            {
                Console.WriteLine("\n--- LICH SU TRINH DUYET ---");

                if (trangHienTai == null)
                {
                    Console.WriteLine("Trang hien tai: (chua co trang nao)");
                }
                else
                {
                    Console.WriteLine("Trang hien tai: " + trangHienTai.DiaChi);
                }

                Console.WriteLine("1. Truy cap trang moi");
                Console.WriteLine("2. Back - quay lai");
                Console.WriteLine("3. Forward - di tiep");
                Console.WriteLine("4. Xem lich su");
                Console.WriteLine("0. Quay lai menu chinh");
                Console.Write("Nhap lua chon: ");

                string luaChon = Console.ReadLine();
                if (luaChon == "0")
                {
                    return;
                }

                switch (luaChon)
                {
                    case "1":
                        Console.Write("Nhap dia chi trang web: ");
                        TruyCapTrangMoi(Console.ReadLine());
                        break;
                    case "2":
                        QuayLai();
                        break;
                    case "3":
                        DiTiep();
                        break;
                    case "4":
                        XemLichSu();
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }
            }
        }
    }
}
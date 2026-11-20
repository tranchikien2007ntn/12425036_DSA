using System;

namespace Buoi02_DanhSach
{
    // Thuc hanh 18: Quan ly don hang bang danh sach lien ket doi.
    static class TH18
    {
        class Node
        {
            public int MaDonHang;
            public string TenKhachHang;
            public int TrangThai;
            public Node Truoc;
            public Node Sau;
        }

        static string[] tenTrangThai = { "Cho xu ly", "Dang giao", "Hoan thanh" };
        static Node dau;
        static Node cuoi;
        static int maTiepTheo;

        static void ThemDonHang(string tenKhachHang)
        {
            Node donHangMoi = new Node();
            donHangMoi.MaDonHang = maTiepTheo;
            maTiepTheo++;
            donHangMoi.TenKhachHang = tenKhachHang;
            donHangMoi.TrangThai = 0; // Don moi bat dau o trang thai Cho xu ly.

            if (dau == null)
            {
                dau = donHangMoi;
                cuoi = donHangMoi;
            }
            else
            {
                cuoi.Sau = donHangMoi;
                donHangMoi.Truoc = cuoi;
                cuoi = donHangMoi;
            }

            Console.WriteLine("Da tao don hang ma: " + donHangMoi.MaDonHang);
        }

        static Node TimDonHang(int maDonHang)
        {
            Node hienTai = dau;

            while (hienTai != null)
            {
                if (hienTai.MaDonHang == maDonHang)
                {
                    return hienTai;
                }
                hienTai = hienTai.Sau;
            }

            return null;
        }

        static bool ChuyenSangTrangThaiTiep(Node donHang)
        {
            if (donHang.TrangThai == 2)
            {
                return false;
            }

            donHang.TrangThai++;
            return true;
        }

        static bool QuayVeTrangThaiTruoc(Node donHang)
        {
            if (donHang.TrangThai == 0)
            {
                return false;
            }

            donHang.TrangThai--;
            return true;
        }

        static void InMotDonHang(Node donHang)
        {
            Console.WriteLine("{0,-8}{1,-22}{2}",
                donHang.MaDonHang, donHang.TenKhachHang,
                tenTrangThai[donHang.TrangThai]);
        }

        static void XemDonHangCuDenMoi()
        {
            if (dau == null)
            {
                Console.WriteLine("Chua co don hang nao.");
                return;
            }

            Console.WriteLine("{0,-8}{1,-22}{2}", "Ma don", "Khach hang", "Trang thai");
            Node hienTai = dau;
            while (hienTai != null)
            {
                InMotDonHang(hienTai);
                hienTai = hienTai.Sau;
            }
        }

        static void XemDonHangMoiDenCu()
        {
            if (cuoi == null)
            {
                Console.WriteLine("Chua co don hang nao.");
                return;
            }

            Console.WriteLine("{0,-8}{1,-22}{2}", "Ma don", "Khach hang", "Trang thai");
            Node hienTai = cuoi;
            while (hienTai != null)
            {
                InMotDonHang(hienTai);
                hienTai = hienTai.Truoc;
            }
        }

        static void CapNhatTrangThai(bool chuyenTiep)
        {
            Console.Write("Nhap ma don hang: ");
            int maDonHang = int.Parse(Console.ReadLine());

            Node donHang = TimDonHang(maDonHang);
            if (donHang == null)
            {
                Console.WriteLine("Khong tim thay don hang!");
                return;
            }

            bool capNhatThanhCong;
            if (chuyenTiep)
            {
                capNhatThanhCong = ChuyenSangTrangThaiTiep(donHang);
            }
            else
            {
                capNhatThanhCong = QuayVeTrangThaiTruoc(donHang);
            }

            if (capNhatThanhCong)
            {
                Console.WriteLine("Trang thai moi: " + tenTrangThai[donHang.TrangThai]);
            }
            else
            {
                Console.WriteLine("Khong the chuyen trang thai. Trang thai hien tai: " +
                    tenTrangThai[donHang.TrangThai]);
            }
        }

        public static void Chay()
        {
            dau = null;
            cuoi = null;
            maTiepTheo = 1;

            while (true)
            {
                Console.WriteLine("\n--- QUAN LY DON HANG ---");
                Console.WriteLine("1. Them don hang");
                Console.WriteLine("2. Chuyen sang trang thai tiep theo");
                Console.WriteLine("3. Quay lai trang thai truoc");
                Console.WriteLine("4. Xem danh sach (cu den moi)");
                Console.WriteLine("5. Xem danh sach (moi den cu)");
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
                        Console.Write("Ten khach hang: ");
                        ThemDonHang(Console.ReadLine());
                        break;
                    case "2":
                        CapNhatTrangThai(true);
                        break;
                    case "3":
                        CapNhatTrangThai(false);
                        break;
                    case "4":
                        XemDonHangCuDenMoi();
                        break;
                    case "5":
                        XemDonHangMoiDenCu();
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }
            }
        }
    }
}
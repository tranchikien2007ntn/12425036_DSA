using System;

namespace Buoi02_DanhSach
{
    // Thuc hanh 17: Quan ly playlist bang danh sach lien ket doi.
    static class TH17
    {
        class Node
        {
            public string TenBaiHat;
            public string TenCaSi;
            public Node Truoc;
            public Node Sau;
        }

        static Node dau;
        static Node cuoi;
        static Node baiHatDangPhat;

        static void ThemBaiHat(string tenBaiHat, string tenCaSi)
        {
            Node baiHatMoi = new Node();
            baiHatMoi.TenBaiHat = tenBaiHat;
            baiHatMoi.TenCaSi = tenCaSi;

            if (dau == null)
            {
                dau = baiHatMoi;
                cuoi = baiHatMoi;
                baiHatDangPhat = baiHatMoi;
                return;
            }

            baiHatMoi.Truoc = cuoi;
            cuoi.Sau = baiHatMoi;
            cuoi = baiHatMoi;
        }

        static Node TimBaiHat(string tenBaiHat)
        {
            Node hienTai = dau;

            while (hienTai != null)
            {
                if (string.Equals(hienTai.TenBaiHat, tenBaiHat,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return hienTai;
                }
                hienTai = hienTai.Sau;
            }

            return null;
        }

        static bool XoaBaiHat(string tenBaiHat)
        {
            Node baiHatCanXoa = TimBaiHat(tenBaiHat);
            if (baiHatCanXoa == null)
            {
                return false;
            }

            // Noi nut dung truoc voi nut dung sau nut bi xoa.
            if (baiHatCanXoa.Truoc != null)
            {
                baiHatCanXoa.Truoc.Sau = baiHatCanXoa.Sau;
            }
            else
            {
                dau = baiHatCanXoa.Sau;
            }

            if (baiHatCanXoa.Sau != null)
            {
                baiHatCanXoa.Sau.Truoc = baiHatCanXoa.Truoc;
            }
            else
            {
                cuoi = baiHatCanXoa.Truoc;
            }

            // Neu xoa bai dang phat thi chuyen sang bai ke tiep, neu khong co thi lui lai.
            if (baiHatCanXoa == baiHatDangPhat)
            {
                if (baiHatCanXoa.Sau != null)
                {
                    baiHatDangPhat = baiHatCanXoa.Sau;
                }
                else
                {
                    baiHatDangPhat = baiHatCanXoa.Truoc;
                }
            }

            return true;
        }

        static void PhatBaiTiepTheo()
        {
            if (baiHatDangPhat == null || baiHatDangPhat.Sau == null)
            {
                Console.WriteLine("Dang o bai hat cuoi playlist!");
            }
            else
            {
                baiHatDangPhat = baiHatDangPhat.Sau;
            }
        }

        static void PhatBaiTruocDo()
        {
            if (baiHatDangPhat == null || baiHatDangPhat.Truoc == null)
            {
                Console.WriteLine("Dang o bai hat dau playlist!");
            }
            else
            {
                baiHatDangPhat = baiHatDangPhat.Truoc;
            }
        }

        static void InPlaylist()
        {
            if (dau == null)
            {
                Console.WriteLine("Playlist dang trong.");
                return;
            }

            Node hienTai = dau;
            while (hienTai != null)
            {
                if (hienTai == baiHatDangPhat)
                {
                    Console.WriteLine("> {0} - {1} (dang phat)",
                        hienTai.TenBaiHat, hienTai.TenCaSi);
                }
                else
                {
                    Console.WriteLine("  {0} - {1}", hienTai.TenBaiHat, hienTai.TenCaSi);
                }
                hienTai = hienTai.Sau;
            }
        }

        public static void Chay()
        {
            dau = null;
            cuoi = null;
            baiHatDangPhat = null;

            while (true)
            {
                Console.WriteLine("\n--- QUAN LY PLAYLIST ---");

                if (baiHatDangPhat == null)
                {
                    Console.WriteLine("Dang phat: (chua co bai hat)");
                }
                else
                {
                    Console.WriteLine("Dang phat: {0} - {1}",
                        baiHatDangPhat.TenBaiHat, baiHatDangPhat.TenCaSi);
                }

                Console.WriteLine("1. Them bai hat");
                Console.WriteLine("2. Xoa bai hat");
                Console.WriteLine("3. Next - bai tiep theo");
                Console.WriteLine("4. Previous - bai truoc do");
                Console.WriteLine("5. Xem playlist");
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
                        Console.Write("Ten bai hat: ");
                        string tenBaiHat = Console.ReadLine();
                        Console.Write("Ten ca si: ");
                        string tenCaSi = Console.ReadLine();
                        ThemBaiHat(tenBaiHat, tenCaSi);
                        break;
                    case "2":
                        Console.Write("Nhap ten bai hat can xoa: ");
                        if (XoaBaiHat(Console.ReadLine()))
                        {
                            Console.WriteLine("Da xoa bai hat.");
                        }
                        else
                        {
                            Console.WriteLine("Khong tim thay bai hat.");
                        }
                        break;
                    case "3":
                        PhatBaiTiepTheo();
                        break;
                    case "4":
                        PhatBaiTruocDo();
                        break;
                    case "5":
                        InPlaylist();
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }
            }
        }
    }
}
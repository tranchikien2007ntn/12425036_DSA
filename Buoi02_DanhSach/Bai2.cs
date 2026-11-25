using System;

namespace Buoi02_DanhSach
{
    // Bai 2: Quan ly thong tin nhan vien bang mang cac struct.
    static class Bai2
    {
        struct NhanVien
        {
            public string MaNhanVien;
            public string HoTen;
            public int NamSinh;
            public string PhongBan;
            public int LuongCoBan;
            public int TienThuong;
            public int ThucLinh;
        }

        static NhanVien[] danhSach;

        // Tao mot nhan vien va tinh thuc linh.
        static NhanVien TaoNhanVien(string ma, string ten, int namSinh,
                                    string phongBan, int luong, int thuong)
        {
            NhanVien nhanVien = new NhanVien();
            nhanVien.MaNhanVien = ma;
            nhanVien.HoTen = ten;
            nhanVien.NamSinh = namSinh;
            nhanVien.PhongBan = phongBan;
            nhanVien.LuongCoBan = luong;
            nhanVien.TienThuong = thuong;
            nhanVien.ThucLinh = luong + thuong;
            return nhanVien;
        }

        // Tao du lieu mau de thuc hien cac yeu cau bai tap.
        static void KhoiTaoDuLieu()
        {
            danhSach = new NhanVien[]
            {
                TaoNhanVien("NV01", "Nguyen Van An", 1995, "Ke toan", 8000000, 1500000),
                TaoNhanVien("NV02", "Tran Thi Binh", 1998, "Nhan su", 7000000, 1000000),
                TaoNhanVien("NV03", "Le Van Cuong", 1990, "Ke toan", 9000000, 1200000),
                TaoNhanVien("NV04", "Pham Thi Dung", 1996, "Ky thuat", 7000000, 2000000),
                TaoNhanVien("NV05", "Hoang Van Em", 1992, "Nhan su", 10000000, 800000)
            };
        }

        // In mot nhan vien tren mot dong.
        static void InMotNhanVien(NhanVien nv)
        {
            Console.WriteLine("{0,-7}{1,-20}{2,-8}{3,-12}{4,12}{5,12}{6,12}",
                nv.MaNhanVien, nv.HoTen, nv.NamSinh, nv.PhongBan,
                nv.LuongCoBan, nv.TienThuong, nv.ThucLinh);
        }

        // In toan bo danh sach nhan vien.
        static void InDanhSach(NhanVien[] ds)
        {
            Console.WriteLine("{0,-7}{1,-20}{2,-8}{3,-12}{4,12}{5,12}{6,12}",
                "Ma", "Ho ten", "Nam sinh", "Phong", "Luong CB", "Thuong", "Thuc linh");

            for (int i = 0; i < ds.Length; i++)
            {
                InMotNhanVien(ds[i]);
            }
        }

        // Tinh tong thuc linh cua tat ca nhan vien.
        static long TinhTongThucLinh()
        {
            long tong = 0;
            for (int i = 0; i < danhSach.Length; i++)
            {
                tong += danhSach[i].ThucLinh;
            }
            return tong;
        }

        // In nhung nhan vien co luong co ban thap nhat.
        static void InNhanVienLuongThapNhat()
        {
            int luongThapNhat = danhSach[0].LuongCoBan;

            for (int i = 1; i < danhSach.Length; i++)
            {
                if (danhSach[i].LuongCoBan < luongThapNhat)
                {
                    luongThapNhat = danhSach[i].LuongCoBan;
                }
            }

            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i].LuongCoBan == luongThapNhat)
                {
                    InMotNhanVien(danhSach[i]);
                }
            }
        }

        // Dem so nhan vien co tien thuong tu muc can tim tro len.
        static int DemNhanVienThuongTu(int mucThuong)
        {
            int dem = 0;
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i].TienThuong >= mucThuong)
                {
                    dem++;
                }
            }
            return dem;
        }

        // Sap xep phong ban tang dan, neu trung phong ban thi ma nhan vien giam dan.
        static void SapXepVaIn()
        {
            NhanVien[] mangTam = (NhanVien[])danhSach.Clone();

            // Dung sap xep doi cho de de theo doi.
            for (int i = 0; i < mangTam.Length - 1; i++)
            {
                for (int j = i + 1; j < mangTam.Length; j++)
                {
                    bool canDoiCho = false;

                    int soSanhPhong = string.Compare(mangTam[i].PhongBan, mangTam[j].PhongBan);
                    if (soSanhPhong > 0)
                    {
                        canDoiCho = true;
                    }
                    else if (soSanhPhong == 0 &&
                             string.Compare(mangTam[i].MaNhanVien, mangTam[j].MaNhanVien) < 0)
                    {
                        canDoiCho = true;
                    }

                    if (canDoiCho)
                    {
                        NhanVien tam = mangTam[i];
                        mangTam[i] = mangTam[j];
                        mangTam[j] = tam;
                    }
                }
            }

            InDanhSach(mangTam);
        }

        // Tang luong co ban 5% va tinh lai thuc linh.
        static void TangLuongNamPhanTram()
        {
            for (int i = 0; i < danhSach.Length; i++)
            {
                danhSach[i].LuongCoBan = danhSach[i].LuongCoBan * 105 / 100;
                danhSach[i].ThucLinh = danhSach[i].LuongCoBan + danhSach[i].TienThuong;
            }
        }

        public static void Chay()
        {
            KhoiTaoDuLieu();

            Console.WriteLine("DANH SACH NHAN VIEN:");
            InDanhSach(danhSach);

            Console.WriteLine("\na. Tong thuc linh: " + TinhTongThucLinh());

            Console.WriteLine("\nb. Nhan vien co luong co ban thap nhat:");
            InNhanVienLuongThapNhat();

            Console.WriteLine("\nc. So nhan vien co thuong >= 1.200.000: " + DemNhanVienThuongTu(1200000));

            Console.WriteLine("\nd. Sap xep phong ban tang dan, ma nhan vien giam dan:");
            SapXepVaIn();

            TangLuongNamPhanTram();
            Console.WriteLine("\ne. Danh sach sau khi tang luong co ban 5%:");
            InDanhSach(danhSach);
        }
    }
}
using System;

namespace Buoi02_DanhSach
{
    // Thuc hanh 15: Kiem tra danh sach lien ket co chu trinh hay khong.
    static class TH15
    {
        class Node
        {
            public int GiaTri;
            public Node TiepTheo;
        }

        static Node NhapDanhSach(out Node nutCuoi, out int soPhanTu)
        {
            Console.Write("Nhap so phan tu n: ");
            soPhanTu = int.Parse(Console.ReadLine());

            Node dau = null;
            nutCuoi = null;

            for (int i = 0; i < soPhanTu; i++)
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
                    nutCuoi.TiepTheo = nutMoi;
                }
                nutCuoi = nutMoi;
            }

            return dau;
        }

        // Thuat toan hai con tro: mot con tro di 1 buoc, mot con tro di 2 buoc.
        static bool CoChuTrinh(Node dau)
        {
            Node cham = dau;
            Node nhanh = dau;

            while (nhanh != null && nhanh.TiepTheo != null)
            {
                cham = cham.TiepTheo;
                nhanh = nhanh.TiepTheo.TiepTheo;

                // Neu hai con tro gap nhau thi danh sach co chu trinh.
                if (cham == nhanh)
                {
                    return true;
                }
            }

            return false;
        }

        public static void Chay()
        {
            Node nutCuoi;
            int soPhanTu;
            Node dau = NhapDanhSach(out nutCuoi, out soPhanTu);

            if (dau == null)
            {
                Console.WriteLine("Danh sach rong, khong co chu trinh.");
                return;
            }

            Console.Write("Danh sach ban dau: ");
            Node hienTai = dau;
            while (hienTai != null)
            {
                Console.Write(hienTai.GiaTri + " ");
                hienTai = hienTai.TiepTheo;
            }
            Console.WriteLine();

            Console.Write("Noi nut cuoi ve nut thu k (1 den {0}, nhap 0 neu khong tao chu trinh): ", soPhanTu);
            int k = int.Parse(Console.ReadLine());

            if (k < 0 || k > soPhanTu)
            {
                Console.WriteLine("Gia tri k khong hop le!");
                return;
            }

            if (k > 0)
            {
                Node nutThuK = dau;
                for (int i = 1; i < k; i++)
                {
                    nutThuK = nutThuK.TiepTheo;
                }

                nutCuoi.TiepTheo = nutThuK;
            }

            if (CoChuTrinh(dau))
            {
                Console.WriteLine("Danh sach CO chu trinh.");
            }
            else
            {
                Console.WriteLine("Danh sach KHONG co chu trinh.");
            }
        }
    }
}
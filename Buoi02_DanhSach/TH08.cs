using System;
using System.Collections.Generic;
using System.Text;

namespace Buoi02_DanhSach
{
    // Thuc hanh 8: Dem so lan xuat hien cua moi tu trong van ban.
    static class TH08
    {
        // Chuyen chu thuong va bo cac ky tu khong phai chu/so/khoang trang.
        static string ChuanHoaVanBan(string vanBan)
        {
            StringBuilder ketQua = new StringBuilder();
            vanBan = vanBan.ToLower();

            foreach (char kyTu in vanBan)
            {
                if (char.IsLetterOrDigit(kyTu) || char.IsWhiteSpace(kyTu))
                {
                    ketQua.Append(kyTu);
                }
            }

            return ketQua.ToString();
        }

        public static void Chay()
        {
            Console.WriteLine("Nhap mot doan van ban:");
            string vanBan = Console.ReadLine();

            string vanBanDaChuanHoa = ChuanHoaVanBan(vanBan);
            string[] cacTu = vanBanDaChuanHoa.Split(
                new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            // Dictionary luu cap: tu - so lan xuat hien.
            Dictionary<string, int> bangDem = new Dictionary<string, int>();

            foreach (string tu in cacTu)
            {
                if (bangDem.ContainsKey(tu))
                {
                    bangDem[tu]++;
                }
                else
                {
                    bangDem[tu] = 1;
                }
            }

            // Chuyen Dictionary sang List de co the sap xep.
            List<KeyValuePair<string, int>> danhSach =
                new List<KeyValuePair<string, int>>(bangDem);

            // Sap xep theo so lan giam dan; neu bang nhau thi sap xep tu A-Z.
            for (int i = 0; i < danhSach.Count - 1; i++)
            {
                for (int j = i + 1; j < danhSach.Count; j++)
                {
                    bool canDoiCho = false;

                    if (danhSach[i].Value < danhSach[j].Value)
                    {
                        canDoiCho = true;
                    }
                    else if (danhSach[i].Value == danhSach[j].Value &&
                             string.Compare(danhSach[i].Key, danhSach[j].Key) > 0)
                    {
                        canDoiCho = true;
                    }

                    if (canDoiCho)
                    {
                        KeyValuePair<string, int> tam = danhSach[i];
                        danhSach[i] = danhSach[j];
                        danhSach[j] = tam;
                    }
                }
            }

            Console.WriteLine("\n{0,-20}{1}", "Tu", "So lan xuat hien");
            foreach (KeyValuePair<string, int> cap in danhSach)
            {
                Console.WriteLine("{0,-20}{1}", cap.Key, cap.Value);
            }
        }
    }
}
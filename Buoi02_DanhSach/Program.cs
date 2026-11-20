using System;

namespace Buoi02_DanhSach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Hien thi va nhap duoc tieng Viet trong cua so Console.
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("========== BUOI 2 - DANH SACH ==========");
                Console.WriteLine("CAC BAI TAP CHUONG 4:");
                Console.WriteLine("1. Mang mot chieu");
                Console.WriteLine("2. Quan ly nhan vien");
                Console.WriteLine("3. Ma tran vuong");
                Console.WriteLine("4. Danh sach lien ket don co ban");
                Console.WriteLine("5. Danh sach lien ket don nang cao");
                Console.WriteLine();
                Console.WriteLine("CAC BAI TU THUC HANH:");
                Console.WriteLine("7. Quan ly nhiet do");
                Console.WriteLine("8. Thong ke tu");
                Console.WriteLine("9. Xu ly so nguyen");
                Console.WriteLine("10. Ma tran xoan oc");
                Console.WriteLine("11. Ma tran dac biet");
                Console.WriteLine("12. Minesweeper");
                Console.WriteLine("13. Dao nguoc danh sach lien ket");
                Console.WriteLine("14. Gop hai danh sach da sap xep");
                Console.WriteLine("15. Phat hien chu trinh");
                Console.WriteLine("16. Lich su duyet web");
                Console.WriteLine("17. Playlist nhac");
                Console.WriteLine("18. He thong dat hang");
                Console.WriteLine("0. Thoat chuong trinh");
                Console.Write("Nhap lua chon: ");

                string luaChon = Console.ReadLine();
                if (luaChon == "0")
                {
                    break;
                }

                Console.Clear();

                // Goi ham Chay() cua bai duoc chon.
                switch (luaChon)
                {
                    case "1": Bai1.Chay(); break;
                    case "2": Bai2.Chay(); break;
                    case "3": Bai3.Chay(); break;
                    case "4": Bai4.Chay(); break;
                    case "5": Bai5.Chay(); break;
                    case "7": TH07.Chay(); break;
                    case "8": TH08.Chay(); break;
                    case "9": TH09.Chay(); break;
                    case "10": TH10.Chay(); break;
                    case "11": TH11.Chay(); break;
                    case "12": TH12.Chay(); break;
                    case "13": TH13.Chay(); break;
                    case "14": TH14.Chay(); break;
                    case "15": TH15.Chay(); break;
                    case "16": TH16.Chay(); break;
                    case "17": TH17.Chay(); break;
                    case "18": TH18.Chay(); break;
                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Nhan Enter de quay lai menu...");
                Console.ReadLine();
            }

            Console.WriteLine("Da thoat chuong trinh.");
        }
    }
}
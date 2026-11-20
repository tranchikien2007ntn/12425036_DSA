using System;
using System.Globalization;

namespace Buoi02_DanhSach
{
    // Thuc hanh 7: Thong ke nhiet do trong nhieu ngay.
    static class TH07
    {
        // Cho phep nhap so thap phan bang dau phay hoac dau cham.
        static double DocSoThuc()
        {
            string noiDung = Console.ReadLine().Replace(',', '.');
            return double.Parse(noiDung, CultureInfo.InvariantCulture);
        }

        public static void Chay()
        {
            Console.Write("Nhap so ngay n: ");
            int n = int.Parse(Console.ReadLine());

            if (n <= 0)
            {
                Console.WriteLine("So ngay phai lon hon 0!");
                return;
            }

            double[] nhietDo = new double[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhiet do ngay {0}: ", i + 1);
                nhietDo[i] = DocSoThuc();
            }

            int viTriCaoNhat = 0;
            int viTriThapNhat = 0;
            double tongNhietDo = 0;

            for (int i = 0; i < n; i++)
            {
                if (nhietDo[i] > nhietDo[viTriCaoNhat])
                {
                    viTriCaoNhat = i;
                }

                if (nhietDo[i] < nhietDo[viTriThapNhat])
                {
                    viTriThapNhat = i;
                }

                tongNhietDo += nhietDo[i];
            }

            double trungBinh = tongNhietDo / n;

            Console.WriteLine("\nNgay co nhiet do cao nhat: ngay {0} ({1} do C)",
                viTriCaoNhat + 1, nhietDo[viTriCaoNhat]);
            Console.WriteLine("Ngay co nhiet do thap nhat: ngay {0} ({1} do C)",
                viTriThapNhat + 1, nhietDo[viTriThapNhat]);
            Console.WriteLine("Nhiet do trung binh: {0:F2} do C", trungBinh);
        }
    }
}
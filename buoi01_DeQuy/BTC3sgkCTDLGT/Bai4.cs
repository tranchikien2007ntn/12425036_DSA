using System;
using System.Globalization;

namespace BTC3sgkCTDLGT
{
    class Bai4
    {
        // n >= 0; chia doi so mu nen do sau chi la log n
        static double LuyThua(double x, int n)
        {
            if (n == 0) return 1;
            double h = LuyThua(x, n / 2);
            return n % 2 == 0 ? h * h : h * h * x;
        }

        static double S(double x, int n)
        {
            if (n < 0) return 1.0 / LuyThua(x, -n);
            return LuyThua(x, n);
        }

        public static void Chay()
        {
            Console.WriteLine("=== BAI 4: S(x, n) = x^n ===");
            double x;
            Console.Write("Nhap x: ");
            while (!double.TryParse((Console.ReadLine() ?? "").Replace(',', '.'),
                   NumberStyles.Float, CultureInfo.InvariantCulture, out x))
                Console.Write("Khong hop le, nhap lai: ");

            int n;
            Console.Write("Nhap n (-100000 den 100000): ");
            while (!int.TryParse(Console.ReadLine(), out n) || n < -100000 || n > 100000)
                Console.Write("Khong hop le, nhap lai: ");

            if (x == 0 && n < 0)
                Console.WriteLine("Khong xac dinh (chia cho 0).");
            else
                Console.WriteLine($"S({x}, {n}) = {S(x, n)}");
        }
    }
}
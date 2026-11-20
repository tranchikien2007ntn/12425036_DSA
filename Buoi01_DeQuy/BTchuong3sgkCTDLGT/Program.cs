using System;

namespace BTchuong3sgkCTDLGT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Chon bai (1-8): ");
            int chon = int.Parse(Console.ReadLine());
            if (chon == 1) Bai1.Chay();
            else if (chon == 2) Bai2.Chay();
            else if (chon == 3) Bai3.Chay();
            else if (chon == 4) Bai4.Chay();
            else if (chon == 5) Bai5.Chay();
            else if (chon == 6) Bai6.Chay();
            else if (chon == 7) Bai7.Chay();
            else Bai8.Chay();

            Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}
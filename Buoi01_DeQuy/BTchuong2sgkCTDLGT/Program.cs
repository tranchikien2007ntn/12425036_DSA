using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTchuong2sgkCTDLGT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Chon bai (1-5): ");
            int chon = int.Parse(Console.ReadLine());
            if (chon == 1) Bai1.Chay();
            else if (chon == 2) Bai2.Chay();
            else if (chon == 3) Bai3.Chay();
            else if (chon == 4) Bai4.Chay();
            else Bai5.Chay();

            Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}

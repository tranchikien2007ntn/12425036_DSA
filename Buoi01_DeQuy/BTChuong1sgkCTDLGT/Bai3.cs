using System;

namespace BTChuong1sgkCTDLGT
{
    class Bai3
    {
        public static void Chay()
        {
            Console.Write("Nhap chuoi: ");
            string s = Console.ReadLine() ?? "";

            char[] arr = s.ToCharArray();
            Array.Reverse(arr);

            Console.WriteLine("Chuoi dao nguoc: " + new string(arr));
        }
    }
}
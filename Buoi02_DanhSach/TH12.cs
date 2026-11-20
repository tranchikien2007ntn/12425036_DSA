using System;

namespace Buoi02_DanhSach
{
    // Thuc hanh 12: Tao bang Minesweeper va dem so min xung quanh moi o.
    static class TH12
    {
        public static void Chay()
        {
            Console.Write("Nhap so dong m: ");
            int soDong = int.Parse(Console.ReadLine());
            Console.Write("Nhap so cot n: ");
            int soCot = int.Parse(Console.ReadLine());
            Console.Write("Nhap so luong min k: ");
            int soMin = int.Parse(Console.ReadLine());

            if (soDong <= 0 || soCot <= 0 || soMin < 0 || soMin > soDong * soCot)
            {
                Console.WriteLine("Du lieu khong hop le!");
                return;
            }

            // true nghia la o do co min.
            bool[,] coMin = new bool[soDong, soCot];
            Random random = new Random();
            int soMinDaDat = 0;

            // Dat min vao cac vi tri ngau nhien, khong dat trung mot o.
            while (soMinDaDat < soMin)
            {
                int dong = random.Next(soDong);
                int cot = random.Next(soCot);

                if (coMin[dong, cot] == false)
                {
                    coMin[dong, cot] = true;
                    soMinDaDat++;
                }
            }

            int[,] soMinXungQuanh = new int[soDong, soCot];

            // Dem so min trong 8 o xung quanh moi o khong co min.
            for (int dong = 0; dong < soDong; dong++)
            {
                for (int cot = 0; cot < soCot; cot++)
                {
                    if (coMin[dong, cot])
                    {
                        continue;
                    }

                    for (int lechDong = -1; lechDong <= 1; lechDong++)
                    {
                        for (int lechCot = -1; lechCot <= 1; lechCot++)
                        {
                            int dongCanXet = dong + lechDong;
                            int cotCanXet = cot + lechCot;

                            bool namTrongBang = dongCanXet >= 0 && dongCanXet < soDong &&
                                                cotCanXet >= 0 && cotCanXet < soCot;

                            if (namTrongBang && coMin[dongCanXet, cotCanXet])
                            {
                                soMinXungQuanh[dong, cot]++;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("\nBang Minesweeper (* la min, . la khong co min xung quanh):");
            for (int dong = 0; dong < soDong; dong++)
            {
                for (int cot = 0; cot < soCot; cot++)
                {
                    if (coMin[dong, cot])
                    {
                        Console.Write("* ");
                    }
                    else if (soMinXungQuanh[dong, cot] == 0)
                    {
                        Console.Write(". ");
                    }
                    else
                    {
                        Console.Write(soMinXungQuanh[dong, cot] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
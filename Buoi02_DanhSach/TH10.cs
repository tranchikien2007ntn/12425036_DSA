using System;

namespace Buoi02_DanhSach
{
    // Thuc hanh 10: In cac phan tu ma tran theo thu tu xoan oc.
    static class TH10
    {
        public static void Chay()
        {
            Console.Write("Nhap so dong m: ");
            int soDong = int.Parse(Console.ReadLine());
            Console.Write("Nhap so cot n: ");
            int soCot = int.Parse(Console.ReadLine());

            if (soDong <= 0 || soCot <= 0)
            {
                Console.WriteLine("So dong va so cot phai lon hon 0!");
                return;
            }

            int[,] maTran = new int[soDong, soCot];

            // Nhap cac phan tu cua ma tran.
            for (int i = 0; i < soDong; i++)
            {
                for (int j = 0; j < soCot; j++)
                {
                    Console.Write("a[{0},{1}] = ", i, j);
                    maTran[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("\nMa tran vua nhap:");
            for (int i = 0; i < soDong; i++)
            {
                for (int j = 0; j < soCot; j++)
                {
                    Console.Write("{0,5}", maTran[i, j]);
                }
                Console.WriteLine();
            }

            // Bon bien danh dau pham vi chua duoc in.
            int tren = 0;
            int duoi = soDong - 1;
            int trai = 0;
            int phai = soCot - 1;

            Console.Write("\nCac phan tu theo thu tu xoan oc: ");

            while (tren <= duoi && trai <= phai)
            {
                // Buoc 1: In hang tren cung tu trai sang phai.
                for (int cot = trai; cot <= phai; cot++)
                {
                    Console.Write(maTran[tren, cot] + " ");
                }
                tren++;

                // Buoc 2: In cot ben phai tu tren xuong duoi.
                for (int dong = tren; dong <= duoi; dong++)
                {
                    Console.Write(maTran[dong, phai] + " ");
                }
                phai--;

                // Buoc 3: In hang duoi cung tu phai sang trai.
                if (tren <= duoi)
                {
                    for (int cot = phai; cot >= trai; cot--)
                    {
                        Console.Write(maTran[duoi, cot] + " ");
                    }
                    duoi--;
                }

                // Buoc 4: In cot ben trai tu duoi len tren.
                if (trai <= phai)
                {
                    for (int dong = duoi; dong >= tren; dong--)
                    {
                        Console.Write(maTran[dong, trai] + " ");
                    }
                    trai++;
                }
            }

            Console.WriteLine();
        }
    }
}
using System;

public class Bai3
{
    public static (int, int) DemAmDuong(int[] mang)
    {
        int am = 0;
        int duong = 0;
        foreach (int so in mang)
        {
            if (so < 0)
            {
                am++;
            }
            else if (so > 0)
            {
                duong++;
            }
        }
        return (am, duong);
    }

    public static void Main(string[] args)
    {
        Console.Write("Nhập số lượng phần tử của mảng: ");
        int n = int.Parse(Console.ReadLine());
        int[] mang = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Nhập phần tử thứ {i}: ");
            mang[i] = int.Parse(Console.ReadLine());
        }

        (int am, int duong) = DemAmDuong(mang);
        Console.WriteLine("Số lượng số âm: " + am);
        Console.WriteLine("Số lượng số dương: " + duong);
    }
}
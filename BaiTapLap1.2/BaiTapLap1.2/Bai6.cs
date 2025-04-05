using System;

public class Bai6
{
    public static double[] SapXepTangDan(double[] mang)
    {
        Array.Sort(mang);
        return mang;
    }

    public static void Main(string[] args)
    {
        Console.Write("Nhập số lượng phần tử của mảng: ");
        int n = int.Parse(Console.ReadLine());
        double[] mang = new double[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Nhập phần tử thứ {i}: ");
            mang[i] = double.Parse(Console.ReadLine());
        }

        double[] mangSapXep = SapXepTangDan(mang);
        Console.WriteLine("Mảng sau khi sắp xếp: " + string.Join(", ", mangSapXep));
    }
}
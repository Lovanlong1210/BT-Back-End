using System;
using System.Text;

public class Bai1
{
    public static int TinhTongSoChan(int[] mang)
    {
        int tong = 0;
        foreach (int so in mang)
        {
            if (so % 2 == 0)
            {
                tong += so;
            }
        }
        return tong;
    }

    public static void Main(string[] args)
    {
        int[] mang = { 1, 2, 3, 4, 5, 6 };
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Tổng các số chẵn trong mảng là: " + TinhTongSoChan(mang));
    }
}
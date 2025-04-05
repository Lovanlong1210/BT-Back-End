using System;
using System.Linq;

public class Bai4
{
    public static int TimSoLonThuHai(int[] mang)
    {
        Array.Sort(mang);
        Array.Reverse(mang);
        return mang[1];
    }

    public static void Main(string[] args)
    {
        int[] mang = { 1, 5, 2, 8, 3 };
        Console.WriteLine("Số lớn thứ hai trong mảng là: " + TimSoLonThuHai(mang));
    }
}
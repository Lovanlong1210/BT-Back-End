using System;
using System.Text;

public class Bai2
{
    public static bool LaSoNguyenTo(int n)
    {
        if (n <= 1)
        {
            return false;
        }
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    public static void TimSoNguyenTo(int[] mang)
    {
        for (int i = 0; i < mang.Length; i++)
        {
            if (LaSoNguyenTo(mang[i]))
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine($"Phần tử thứ {i} có giá trị {mang[i]} là số nguyên tố.");
            }
        }
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
        TimSoNguyenTo(mang);
    }
}
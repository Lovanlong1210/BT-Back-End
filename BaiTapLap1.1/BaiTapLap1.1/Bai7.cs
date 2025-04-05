using System;
using System.Text;

public class Bai7
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Nhập năm: ");
        int nam = int.Parse(Console.ReadLine());

        if ((nam % 4 == 0 && nam % 100 != 0) || nam % 400 == 0)
        {
            Console.WriteLine($"{nam} là năm nhuận.");
        }
        else
        {
            Console.WriteLine($"{nam} không phải là năm nhuận.");
        }
    }
}
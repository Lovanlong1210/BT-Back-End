using System;
using System.Text;

public class Bai5
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Nhập số thứ nhất: ");
        double so1 = double.Parse(Console.ReadLine());

        Console.Write("Nhập số thứ hai: ");
        double so2 = double.Parse(Console.ReadLine());

        double tong = so1 + so2;
        double tich = so1 * so2;

        Console.WriteLine($"Tổng hai số là: {tong}");
        Console.WriteLine($"Tích hai số là: {tich}");
    }
}
using System;
using System.Text;

public class Bai2
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Nhập chiều dài hình chữ nhật: ");
        double chieuDai = double.Parse(Console.ReadLine());

        Console.Write("Nhập chiều rộng hình chữ nhật: ");
        double chieuRong = double.Parse(Console.ReadLine());

        double dienTich = chieuDai * chieuRong;
        Console.WriteLine($"Diện tích hình chữ nhật là: {dienTich}");
    }
}
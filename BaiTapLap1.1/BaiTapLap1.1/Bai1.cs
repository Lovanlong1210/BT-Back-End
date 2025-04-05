using System;
using System.Text;

public class Bai1
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Nhập tên của bạn: ");
        string ten = Console.ReadLine();

        Console.Write("Nhập tuổi của bạn: ");
        int tuoi = int.Parse(Console.ReadLine());

        Console.WriteLine($"Xin chào {ten}, bạn {tuoi} tuổi!");
    }
}
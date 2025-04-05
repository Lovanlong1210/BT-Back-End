using System;
using System.Text;

public class Bai3
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Nhập nhiệt độ (độ C): ");
        double doC = double.Parse(Console.ReadLine());

        double doF = (doC * 9 / 5) + 32;
        Console.WriteLine($"Nhiệt độ (độ F) là: {doF}");
    }
}
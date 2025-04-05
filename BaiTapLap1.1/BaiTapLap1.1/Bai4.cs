using System;
using System.Text;

public class Bai4
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Nhập một số nguyên: ");
        int so = int.Parse(Console.ReadLine());

        if (so % 2 == 0)
        {
            Console.WriteLine($"{so} là số chẵn.");
        }
        else
        {
            Console.WriteLine($"{so} không phải là số chẵn.");
        }
    }
}
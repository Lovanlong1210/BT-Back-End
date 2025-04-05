using System;
using System.Text;

public class Bai6
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Nhập một số: ");
        double so = double.Parse(Console.ReadLine());

        if (so > 0)
        {
            Console.WriteLine($"{so} là số dương.");
        }
        else if (so < 0)
        {
            Console.WriteLine($"{so} là số âm.");
        }
        else
        {
            Console.WriteLine($"{so} là số không.");
        }
    }
}
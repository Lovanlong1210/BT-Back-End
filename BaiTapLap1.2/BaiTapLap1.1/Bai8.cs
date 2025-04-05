using System;
using System.Text;

public class Bai8
{
    public static void Main(string[] args)
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine($"Bảng cửu chương {i}:");
            for (int j = 1; j <= 10; j++)
            {
                Console.WriteLine($"{i} x {j} = {i * j}");
            }
        }
    }
}
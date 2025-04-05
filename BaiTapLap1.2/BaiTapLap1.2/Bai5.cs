using System;

public class Bai5
{
    public static (int, int) HoanVi(int a, int b)
    {
        return (b, a);
    }

    public static void Main(string[] args)
    {
        Console.Write("Nhập số a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Nhập số b: ");
        int b = int.Parse(Console.ReadLine());

        (int newA, int newB) = HoanVi(a, b);
        Console.WriteLine("Giá trị của a sau khi hoán vị: " + newA);
        Console.WriteLine("Giá trị của b sau khi hoán vị: " + newB);
    }
}
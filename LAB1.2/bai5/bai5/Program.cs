using System;

class Program
{
    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    static void Main()
    {
        Console.Write("Nhap so a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Nhap so b: ");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine($"truoc khi hoan vi: a = {a}, b = {b}");
        Swap(ref a, ref b);
        Console.WriteLine($"Sau khi hoan vi: a = {a}, b = {b}");
    }
}
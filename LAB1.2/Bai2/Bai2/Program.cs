using System;

class Program
{
    static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        for (int i = 3; i * i <= number; i += 2)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    static void Main()
    {
        Console.Write("Nhap so phan tu cua mang: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];

        Console.WriteLine("Nhap cac phan tu cua mang:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Phan tu thu {i + 1}: ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Cac so nguyen to trong mang:");
        for (int i = 0; i < arr.Length; i++)
        {
            if (IsPrime(arr[i]))
            {
                Console.WriteLine($"chi so: {i}, Gia tri: {arr[i]}");
            }
        }
    }
}
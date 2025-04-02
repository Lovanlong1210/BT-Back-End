using System;

class Program
{
    static void CountPositivesAndNegatives(int[] arr, out int positiveCount, out int negativeCount)
    {
        positiveCount = 0;
        negativeCount = 0;

        foreach (int num in arr)
        {
            if (num > 0)
                positiveCount++;
            else if (num < 0)
                negativeCount++;
        }
    }

    static void Main()
    {
        Console.Write("Nhap so phan tu cua mang: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];

        Console.WriteLine("Nhap cac phan tu cua mang:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"phan tu thu {i + 1}: ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        CountPositivesAndNegatives(arr, out int positiveCount, out int negativeCount);
        Console.WriteLine($"so luong so duong: {positiveCount}");
        Console.WriteLine($"so luong so am: {negativeCount}");
    }
}
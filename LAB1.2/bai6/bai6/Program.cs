using System;

class Program
{
    static void SortArray(double[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] > arr[j])
                {
                    double temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
        }
    }

    static void Main()
    {
        Console.Write("Nhap so phan tu mang: ");
        int n = int.Parse(Console.ReadLine());
        double[] arr = new double[n];

        Console.WriteLine("Nhap cac phan tu mang:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Phan tu thu {i + 1}: ");
            arr[i] = double.Parse(Console.ReadLine());
        }

        SortArray(arr);

        Console.WriteLine("Mang sau khi sap xep tang dan:");
        foreach (double num in arr)
        {
            Console.Write(num + " ");
        }
    }
}
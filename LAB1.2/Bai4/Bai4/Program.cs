using System;
using System.Linq;

class Program
{
    static int FindSecondLargest(int[] arr)
    {
        if (arr.Length < 2)
        {
            throw new ArgumentException("Mang phai co tu 2 phan tu");
        }

        int first = int.MinValue;
        int second = int.MinValue;

        foreach (int num in arr)
        {
            if (num > first)
            {
                second = first;
                first = num;
            }
            else if (num > second && num != first)
            {
                second = num;
            }
        }

        if (second == int.MinValue)
        {
            throw new ArgumentException("khong tim thay so lon thu 2");
        }

        return second;
    }

    static void Main()
    {
        int[] numbers = { 12, 35, 1, 10, 34, 1 };
        Console.WriteLine("so lon thu 2 cua mang: " + FindSecondLargest(numbers));
    }
}
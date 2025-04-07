using System;
using System.Linq;

public class DaGiac
{
    public int SoCanh { get; set; }
    public int[] KichThuocCanh { get; set; }

    public void NhapDaGiac()
    {
        Console.Write("Số cạnh của đa giác: ");
        SoCanh = int.Parse(Console.ReadLine());
        KichThuocCanh = new int[SoCanh];
        for (int i = 0; i < SoCanh; i++)
        {
            Console.Write($"Kích thước cạnh thứ {i + 1}: ");
            KichThuocCanh[i] = int.Parse(Console.ReadLine());
        }
    }

    public int TinhChuVi()
    {
        return KichThuocCanh.Sum();
    }

    public void InKichThuocCanh()
    {
        Console.WriteLine("Kích thước các cạnh của đa giác:");
        for (int i = 0; i < SoCanh; i++)
        {
            Console.Write($"{KichThuocCanh[i]} ");
        }
        Console.WriteLine();
    }
}

public class TamGiac : DaGiac
{
    public TamGiac()
    {
        SoCanh = 3;
    }

    public double TinhDienTich()
    {
        double p = TinhChuVi() / 2.0;
        return Math.Sqrt(p * (p - KichThuocCanh[0]) * (p - KichThuocCanh[1]) * (p - KichThuocCanh[2]));
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Nhập số lượng tam giác: ");
        int n = int.Parse(Console.ReadLine());
        TamGiac[] cacTamGiac = new TamGiac[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhập thông tin tam giác thứ {i + 1}:");
            cacTamGiac[i] = new TamGiac();
            cacTamGiac[i].NhapDaGiac();
        }

        Console.WriteLine("Các tam giác thỏa mãn định lý Pitago:");
        foreach (var tamGiac in cacTamGiac)
        {
            Array.Sort(tamGiac.KichThuocCanh);
            if (tamGiac.KichThuocCanh[0] * tamGiac.KichThuocCanh[0] + tamGiac.KichThuocCanh[1] * tamGiac.KichThuocCanh[1] == tamGiac.KichThuocCanh[2] * tamGiac.KichThuocCanh[2])
            {
                tamGiac.InKichThuocCanh();
            }
        }
    }
}
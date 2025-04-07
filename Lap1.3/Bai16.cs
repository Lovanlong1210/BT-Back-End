using System;
using System.Collections.Generic;

public class Diem
{
    public double HoanhDo { get; set; }
    public double TungDo { get; set; }

    public Diem(double x = 0, double y = 0)
    {
        HoanhDo = x;
        TungDo = y;
    }

    public void InDiem()
    {
        Console.WriteLine($"({HoanhDo}, {TungDo})");
    }

    public double TinhKhoangCach(Diem diemKhac)
    {
        return Math.Sqrt(Math.Pow(HoanhDo - diemKhac.HoanhDo, 2) + Math.Pow(TungDo - diemKhac.TungDo, 2));
    }
}

public class TamGiac
{
    public Diem Diem1 { get; set; }
    public Diem Diem2 { get; set; }
    public Diem Diem3 { get; set; }

    public TamGiac(Diem d1 = null, Diem d2 = null, Diem d3 = null)
    {
        Diem1 = d1 ?? new Diem();
        Diem2 = d2 ?? new Diem();
        Diem3 = d3 ?? new Diem();
    }

    public double TinhDienTich()
    {
        double a = Diem1.TinhKhoangCach(Diem2);
        double b = Diem2.TinhKhoangCach(Diem3);
        double c = Diem3.TinhKhoangCach(Diem1);
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public double TinhChuVi()
    {
        return Diem1.TinhKhoangCach(Diem2) + Diem2.TinhKhoangCach(Diem3) + Diem3.TinhKhoangCach(Diem1);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Nhập số lượng tam giác: ");
        int n = int.Parse(Console.ReadLine());
        List<TamGiac> danhSachTamGiac = new List<TamGiac>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhập thông tin tam giác thứ {i + 1}:");
            Diem d1 = new Diem();
            Diem d2 = new Diem();
            Diem d3 = new Diem();

            Console.WriteLine("Nhập điểm thứ nhất:");
            Console.Write("Hoành độ: ");
            d1.HoanhDo = double.Parse(Console.ReadLine());
            Console.Write("Tung độ: ");
            d1.TungDo = double.Parse(Console.ReadLine());

            Console.WriteLine("Nhập điểm thứ hai:");
            Console.Write("Hoành độ: ");
            d2.HoanhDo = double.Parse(Console.ReadLine());
            Console.Write("Tung độ: ");
            d2.TungDo = double.Parse(Console.ReadLine());

            Console.WriteLine("Nhập điểm thứ ba:");
            Console.Write("Hoành độ: ");
            d3.HoanhDo = double.Parse(Console.ReadLine());
            Console.Write("Tung độ: ");
            d3.TungDo = double.Parse(Console.ReadLine());

            danhSachTamGiac.Add(new TamGiac(d1, d2, d3));
        }

        double tongChuVi = 0;
        double tongDienTich = 0;
        foreach (var tamGiac in danhSachTamGiac)
        {
            tongChuVi += tamGiac.TinhChuVi();
            tongDienTich += tamGiac.TinhDienTich();
        }

        Console.WriteLine($"Tổng chu vi của các tam giác: {tongChuVi}");
        Console.WriteLine($"Tổng diện tích của các tam giác: {tongDienTich}");
    }
}
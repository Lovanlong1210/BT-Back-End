using System;
using System.Collections.Generic;

public class Diem
{
    // Giống như bài 16
}

public class HinhTron
{
    public Diem Tam { get; set; }
    public float BanKinh { get; set; }

    public HinhTron(Diem d = null, float bk = 0)
    {
        Tam = d ?? new Diem();
        BanKinh = bk;
    }

    public double TinhChuVi()
    {
        return 2 * Math.PI * BanKinh;
    }

    public double TinhDienTich()
    {
        return Math.PI * BanKinh * BanKinh;
    }

    public bool GiaoNhau(HinhTron hinhTronKhac)
    {
        double khoangCachTam = Tam.TinhKhoangCach(hinhTronKhac.Tam);
        return khoangCachTam <= BanKinh + hinhTronKhac.BanKinh;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Nhập số lượng hình tròn: ");
        int n = int.Parse(Console.ReadLine());
        List<HinhTron> danhSachHinhTron = new List<HinhTron>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhập thông tin hình tròn thứ {i + 1}:");
            Diem tam = new Diem();
            Console.Write("Hoành độ tâm: ");
            tam.HoanhDo = double.Parse(Console.ReadLine());
            Console.Write("Tung độ tâm: ");
            tam.TungDo = double.Parse(Console.ReadLine());
            Console.Write("Bán kính: ");
            float banKinh = float.Parse(Console.ReadLine());
            danhSachHinhTron.Add(new HinhTron(tam, banKinh));
        }

        HinhTron hinhTronGiaoNhieuNhat = null;
        int soGiaoNhauNhieuNhat = 0;

        foreach (var hinhTron in danhSachHinhTron)
        {
            int demGiaoNhau = 0;
            foreach (var hinhTronKhac in danhSachHinhTron)
            {
                if (hinhTron != hinhTronKhac && hinhTron.GiaoNhau(hinhTronKhac))
                {
                    demGiaoNhau++;
                }
            }
            if (demGiaoNhau > soGiaoNhauNhieuNhat)
            {
                soGiaoNhauNhieuNhat = demGiaoNhau;
                hinhTronGiaoNhieuNhat = hinhTron;
            }
        }

        if (hinhTronGiaoNhieuNhat != null)
        {
            Console.WriteLine("Hình tròn giao với nhiều hình tròn nhất:");
            Console.WriteLine($"Tâm: ({hinhTronGiaoNhieuNhat.Tam.HoanhDo}, {hinhTronGiaoNhieuNhat.Tam.TungDo})");
            Console.WriteLine($"Bán kính: {hinhTronGiaoNhieuNhat.BanKinh}");
        }
        else
        {
            Console.WriteLine("Không có hình tròn nào giao với hình tròn khác.");
        }
    }
}
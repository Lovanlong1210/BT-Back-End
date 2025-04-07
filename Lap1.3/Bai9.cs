using System;
using System.Collections.Generic;

public class KhachHang
{
    public string HoTenChuHo { get; set; }
    public string SoNha { get; set; }
    public string MaCongTo { get; set; }

    public void NhapThongTin()
    {
        Console.Write("Họ tên chủ hộ: ");
        HoTenChuHo = Console.ReadLine();
        Console.Write("Số nhà: ");
        SoNha = Console.ReadLine();
        Console.Write("Mã công tơ: ");
        MaCongTo = Console.ReadLine();
    }

    public void HienThiThongTin()
    {
        Console.WriteLine($"Họ tên chủ hộ: {HoTenChuHo}, Số nhà: {SoNha}, Mã công tơ: {MaCongTo}");
    }
}

public class BienLai
{
    public KhachHang KhachHang { get; set; }
    public int ChiSoCu { get; set; }
    public int ChiSoMoi { get; set; }

    public BienLai()
    {
        KhachHang = new KhachHang();
    }

    public void NhapThongTin()
    {
        KhachHang.NhapThongTin();
        Console.Write("Chỉ số cũ: ");
        ChiSoCu = int.Parse(Console.ReadLine());
        Console.Write("Chỉ số mới: ");
        ChiSoMoi = int.Parse(Console.ReadLine());
    }

    public void HienThiThongTin()
    {
        KhachHang.HienThiThongTin();
        Console.WriteLine($"Chỉ số cũ: {ChiSoCu}, Chỉ số mới: {ChiSoMoi}, Tiền phải trả: {TinhTien()}");
    }

    public double TinhTien()
    {
        int soDien = ChiSoMoi - ChiSoCu;
        if (soDien <= 50)
        {
            return soDien * 1250;
        }
        else if (soDien <= 100)
        {
            return 50 * 1250 + (soDien - 50) * 1500;
        }
        else
        {
            return 50 * 1250 + 50 * 1500 + (soDien - 100) * 2000;
        }
    }
}

public class QuanLyTienDien
{
    private List<BienLai> danhSachBienLai = new List<BienLai>();

    public void NhapBienLai(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhập thông tin biên lai thứ {i + 1}:");
            BienLai bienLai = new BienLai();
            bienLai.NhapThongTin();
            danhSachBienLai.Add(bienLai);
        }
    }

    public void HienThiDanhSachBienLai()
    {
        Console.WriteLine("Danh sách biên lai:");
        foreach (var bl in danhSachBienLai)
        {
            bl.HienThiThongTin();
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        QuanLyTienDien quanLyTienDien = new QuanLyTienDien();
        Console.Write("Nhập số lượng hộ dùng điện: ");
        int n = int.Parse(Console.ReadLine());
        quanLyTienDien.NhapBienLai(n);

        int luaChon;
        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Hiển thị danh sách biên lai");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn: ");
            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    quanLyTienDien.HienThiDanhSachBienLai();
                    break;
                case 0:
                    Console.WriteLine("Thoát chương trình.");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    break;
            }
        } while (luaChon != 0);
    }
}
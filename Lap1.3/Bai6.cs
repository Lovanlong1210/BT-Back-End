using System;
using System.Collections.Generic;

public class Nguoi
{
    public string HoTen { get; set; }
    public int Tuoi { get; set; }
    public int NamSinh { get; set; }
    public string QueQuan { get; set; }
    public string GioiTinh { get; set; }

    public void NhapThongTin()
    {
        Console.Write("Họ tên: ");
        HoTen = Console.ReadLine();
        Console.Write("Tuổi: ");
        Tuoi = int.Parse(Console.ReadLine());
        Console.Write("Năm sinh: ");
        NamSinh = int.Parse(Console.ReadLine());
        Console.Write("Quê quán: ");
        QueQuan = Console.ReadLine();
        Console.Write("Giới tính: ");
        GioiTinh = Console.ReadLine();
    }

    public void HienThiThongTin()
    {
        Console.WriteLine($"Họ tên: {HoTen}, Tuổi: {Tuoi}, Năm sinh: {NamSinh}, Quê quán: {QueQuan}, Giới tính: {GioiTinh}");
    }
}

public class HoSoHocSinh
{
    public Nguoi Nguoi { get; set; }
    public string Lop { get; set; }
    public int KhoaHoc { get; set; }
    public int KyHoc { get; set; }

    public HoSoHocSinh()
    {
        Nguoi = new Nguoi();
    }

    public void NhapThongTin()
    {
        Nguoi.NhapThongTin();
        Console.Write("Lớp: ");
        Lop = Console.ReadLine();
        Console.Write("Khóa học: ");
        KhoaHoc = int.Parse(Console.ReadLine());
        Console.Write("Kỳ học: ");
        KyHoc = int.Parse(Console.ReadLine());
    }

    public void HienThiThongTin()
    {
        Nguoi.HienThiThongTin();
        Console.WriteLine($"Lớp: {Lop}, Khóa học: {KhoaHoc}, Kỳ học: {KyHoc}");
    }
}

public class QuanLyHocSinh
{
    private List<HoSoHocSinh> danhSachHocSinh = new List<HoSoHocSinh>();

    public void NhapHocSinh(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhập thông tin học sinh thứ {i + 1}:");
            HoSoHocSinh hocSinh = new HoSoHocSinh();
            hocSinh.NhapThongTin();
            danhSachHocSinh.Add(hocSinh);
        }
    }

    public void HienThiHocSinhNu1985()
    {
        Console.WriteLine("Danh sách học sinh nữ sinh năm 1985:");
        foreach (var hs in danhSachHocSinh)
        {
            if (hs.Nguoi.GioiTinh.ToLower() == "nữ" && hs.Nguoi.NamSinh == 1985)
            {
                hs.HienThiThongTin();
            }
        }
    }

    public void TimKiemTheoQueQuan(string queQuan)
    {
        var ketQua = danhSachHocSinh.FindAll(hs => hs.Nguoi.QueQuan.Contains(queQuan));
        if (ketQua.Count > 0)
        {
            Console.WriteLine("Kết quả tìm kiếm:");
            foreach (var hs in ketQua)
            {
                hs.HienThiThongTin();
            }
        }
        else
        {
            Console.WriteLine("Không tìm thấy học sinh nào.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        QuanLyHocSinh quanLyHocSinh = new QuanLyHocSinh();
        Console.Write("Nhập số lượng học sinh: ");
        int n = int.Parse(Console.ReadLine());
        quanLyHocSinh.NhapHocSinh(n);

        int luaChon;
        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Hiển thị học sinh nữ sinh năm 1985");
            Console.WriteLine("2. Tìm kiếm học sinh theo quê quán");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn: ");
            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    quanLyHocSinh.HienThiHocSinhNu1985();
                    break;
                case 2:
                    Console.Write("Nhập quê quán cần tìm: ");
                    string queQuanTimKiem = Console.ReadLine();
                    quanLyHocSinh.TimKiemTheoQueQuan(queQuanTimKiem);
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
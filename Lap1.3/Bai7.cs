using System;
using System.Collections.Generic;

public class Nguoi
{
    public string HoTen { get; set; }
    public int NamSinh { get; set; }
    public string QueQuan { get; set; }
    public string CMND { get; set; }

    public void NhapThongTin()
    {
        Console.Write("Họ tên: ");
        HoTen = Console.ReadLine();
        Console.Write("Năm sinh: ");
        NamSinh = int.Parse(Console.ReadLine());
        Console.Write("Quê quán: ");
        QueQuan = Console.ReadLine();
        Console.Write("Số CMND: ");
        CMND = Console.ReadLine();
    }

    public void HienThiThongTin()
    {
        Console.WriteLine($"Họ tên: {HoTen}, Năm sinh: {NamSinh}, Quê quán: {QueQuan}, CMND: {CMND}");
    }
}

public class CBGV
{
    public Nguoi Nguoi { get; set; }
    public double LuongCung { get; set; }
    public double Thuong { get; set; }
    public double Phat { get; set; }

    public CBGV()
    {
        Nguoi = new Nguoi();
    }

    public void NhapThongTin()
    {
        Nguoi.NhapThongTin();
        Console.Write("Lương cứng: ");
        LuongCung = double.Parse(Console.ReadLine());
        Console.Write("Thưởng: ");
        Thuong = double.Parse(Console.ReadLine());
        Console.Write("Phạt: ");
        Phat = double.Parse(Console.ReadLine());
    }

    public void HienThiThongTin()
    {
        Nguoi.HienThiThongTin();
        Console.WriteLine($"Lương cứng: {LuongCung}, Thưởng: {Thuong}, Phạt: {Phat}, Lương thực lĩnh: {TinhLuong()}");
    }

    public double TinhLuong()
    {
        return LuongCung + Thuong - Phat;
    }
}

public class QuanLyCBGV
{
    private List<CBGV> danhSachCBGV = new List<CBGV>();

    public void NhapCBGV(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhập thông tin cán bộ giáo viên thứ {i + 1}:");
            CBGV cbgv = new CBGV();
            cbgv.NhapThongTin();
            danhSachCBGV.Add(cbgv);
        }
    }

    public void TimKiemTheoQueQuan(string queQuan)
    {
        var ketQua = danhSachCBGV.FindAll(cbgv => cbgv.Nguoi.QueQuan.Contains(queQuan));
        if (ketQua.Count > 0)
        {
            Console.WriteLine("Kết quả tìm kiếm:");
            foreach (var cbgv in ketQua)
            {
                cbgv.HienThiThongTin();
            }
        }
        else
        {
            Console.WriteLine("Không tìm thấy cán bộ giáo viên nào.");
        }
    }

    public void HienThiCBGVLuongTren5Trieu()
    {
        Console.WriteLine("Danh sách cán bộ giáo viên có lương thực lĩnh trên 5 triệu đồng:");
        foreach (var cbgv in danhSachCBGV)
        {
            if (cbgv.TinhLuong() > 5000000)
            {
                cbgv.HienThiThongTin();
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        QuanLyCBGV quanLyCBGV = new QuanLyCBGV();
        Console.Write("Nhập số lượng cán bộ giáo viên: ");
        int n = int.Parse(Console.ReadLine());
        quanLyCBGV.NhapCBGV(n);

        int luaChon;
        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Tìm kiếm theo quê quán");
            Console.WriteLine("2. Hiển thị cán bộ giáo viên lương trên 5 triệu");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn: ");
            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    Console.Write("Nhập quê quán cần tìm: ");
                    string queQuanTimKiem = Console.ReadLine();
                    quanLyCBGV.TimKiemTheoQueQuan(queQuanTimKiem);
                    break;
                case 2:
                    quanLyCBGV.HienThiCBGVLuongTren5Trieu();
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
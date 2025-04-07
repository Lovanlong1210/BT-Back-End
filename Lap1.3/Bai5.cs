using System;
using System.Collections.Generic;

public class Nguoi
{
    public string HoTen { get; set; }
    public int NamSinh { get; set; }
    public string CMND { get; set; }

    public void NhapThongTin()
    {
        Console.Write("Họ tên: ");
        HoTen = Console.ReadLine();
        Console.Write("Năm sinh: ");
        NamSinh = int.Parse(Console.ReadLine());
        Console.Write("Số CMND: ");
        CMND = Console.ReadLine();
    }

    public void HienThiThongTin()
    {
        Console.WriteLine($"Họ tên: {HoTen}, Năm sinh: {NamSinh}, CMND: {CMND}");
    }
}

public class KhachTro
{
    public Nguoi Nguoi { get; set; }
    public int SoNgayTro { get; set; }
    public string LoaiPhong { get; set; }
    public double GiaPhong { get; set; }

    public KhachTro()
    {
        Nguoi = new Nguoi();
    }

    public void NhapThongTin()
    {
        Nguoi.NhapThongTin();
        Console.Write("Số ngày trọ: ");
        SoNgayTro = int.Parse(Console.ReadLine());
        Console.Write("Loại phòng: ");
        LoaiPhong = Console.ReadLine();
        Console.Write("Giá phòng: ");
        GiaPhong = double.Parse(Console.ReadLine());
    }

    public void HienThiThongTin()
    {
        Nguoi.HienThiThongTin();
        Console.WriteLine($"Số ngày trọ: {SoNgayTro}, Loại phòng: {LoaiPhong}, Giá phòng: {GiaPhong}");
    }

    public double TinhTien()
    {
        return SoNgayTro * GiaPhong;
    }
}

public class KhachSan
{
    private List<KhachTro> danhSachKhachTro = new List<KhachTro>();

    public void NhapKhachTro(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhập thông tin khách trọ thứ {i + 1}:");
            KhachTro khachTro = new KhachTro();
            khachTro.NhapThongTin();
            danhSachKhachTro.Add(khachTro);
        }
    }

    public void HienThiDanhSachKhachTro()
    {
        Console.WriteLine("Danh sách khách trọ:");
        foreach (var kt in danhSachKhachTro)
        {
            kt.HienThiThongTin();
        }
    }

    public void TimKiemTheoHoTen(string hoTen)
    {
        var ketQua = danhSachKhachTro.FindAll(kt => kt.Nguoi.HoTen.Contains(hoTen));
        if (ketQua.Count > 0)
        {
            Console.WriteLine("Kết quả tìm kiếm:");
            foreach (var kt in ketQua)
            {
                kt.HienThiThongTin();
            }
        }
        else
        {
            Console.WriteLine("Không tìm thấy khách trọ nào.");
        }
    }

    public void TinhTienKhachTro()
    {
        Console.Write("Nhập họ tên khách trọ cần tính tiền: ");
        string hoTen = Console.ReadLine();
        var khachTro = danhSachKhachTro.Find(kt => kt.Nguoi.HoTen.Contains(hoTen));
        if (khachTro != null)
        {
            Console.WriteLine($"Số tiền khách {khachTro.Nguoi.HoTen} cần thanh toán là: {khachTro.TinhTien()}");
        }
        else
        {
            Console.WriteLine("Không tìm thấy khách trọ nào.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        KhachSan khachSan = new KhachSan();
        Console.Write("Nhập số lượng khách trọ: ");
        int n = int.Parse(Console.ReadLine());
        khachSan.NhapKhachTro(n);

        int luaChon;
        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Hiển thị danh sách khách trọ");
            Console.WriteLine("2. Tìm kiếm khách trọ theo họ tên");
            Console.WriteLine("3. Tính tiền khách trọ");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn: ");
            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    khachSan.HienThiDanhSachKhachTro();
                    break;
                case 2:
                    Console.Write("Nhập họ tên cần tìm: ");
                    string hoTenTimKiem = Console.ReadLine();
                    khachSan.TimKiemTheoHoTen(hoTenTimKiem);
                    break;
                case 3:
                    khachSan.TinhTienKhachTro();
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

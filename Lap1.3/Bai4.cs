using System;
using System.Collections.Generic;

public class Nguoi
{
    public string HoTen { get; set; }
    public int Tuoi { get; set; }
    public int NamSinh { get; set; }
    public string NgheNghiep { get; set; }
    public string CMND { get; set; }

    public void NhapThongTin()
    {
        Console.Write("Họ tên: ");
        HoTen = Console.ReadLine();
        Console.Write("Tuổi: ");
        Tuoi = int.Parse(Console.ReadLine());
        Console.Write("Năm sinh: ");
        NamSinh = int.Parse(Console.ReadLine());
        Console.Write("Nghề nghiệp: ");
        NgheNghiep = Console.ReadLine();
        Console.Write("Số CMND: ");
        CMND = Console.ReadLine();
    }

    public void HienThiThongTin()
    {
        Console.WriteLine($"Họ tên: {HoTen}, Tuổi: {Tuoi}, Năm sinh: {NamSinh}, Nghề nghiệp: {NgheNghiep}, CMND: {CMND}");
    }
}

public class HoDan
{
    public int SoThanhVien { get; set; }
    public string SoNha { get; set; }
    public List<Nguoi> ThanhVien { get; set; }

    public HoDan()
    {
        ThanhVien = new List<Nguoi>();
    }

    public void NhapThongTin()
    {
        Console.Write("Số thành viên trong hộ: ");
        SoThanhVien = int.Parse(Console.ReadLine());
        Console.Write("Số nhà: ");
        SoNha = Console.ReadLine();

        for (int i = 0; i < SoThanhVien; i++)
        {
            Console.WriteLine($"Nhập thông tin thành viên thứ {i + 1}:");
            Nguoi nguoi = new Nguoi();
            nguoi.NhapThongTin();
            ThanhVien.Add(nguoi);
        }
    }

    public void HienThiThongTin()
    {
        Console.WriteLine($"Số nhà: {SoNha}, Số thành viên: {SoThanhVien}");
        foreach (var thanhVien in ThanhVien)
        {
            thanhVien.HienThiThongTin();
        }
    }
}

public class KhuPho
{
    private List<HoDan> danhSachHoDan = new List<HoDan>();

    public void NhapHoDan(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhập thông tin hộ dân thứ {i + 1}:");
            HoDan hoDan = new HoDan();
            hoDan.NhapThongTin();
            danhSachHoDan.Add(hoDan);
        }
    }

    public void TimKiemTheoHoTen(string hoTen)
    {
        var ketQua = danhSachHoDan.FindAll(hd => hd.ThanhVien.Exists(tv => tv.HoTen.Contains(hoTen)));
        if (ketQua.Count > 0)
        {
            Console.WriteLine("Kết quả tìm kiếm:");
            foreach (var hd in ketQua)
            {
                hd.HienThiThongTin();
            }
        }
        else
        {
            Console.WriteLine("Không tìm thấy hộ dân nào.");
        }
    }

    public void TimKiemTheoSoNha(string soNha)
    {
        var hoDan = danhSachHoDan.Find(hd => hd.SoNha == soNha);
        if (hoDan != null)
        {
            Console.WriteLine("Thông tin hộ dân:");
            hoDan.HienThiThongTin();
        }
        else
        {
            Console.WriteLine("Không tìm thấy hộ dân nào.");
        }
    }

    public void HienThiDanhSachHoDan()
    {
        Console.WriteLine("Danh sách hộ dân:");
        foreach (var hd in danhSachHoDan)
        {
            hd.HienThiThongTin();
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        KhuPho khuPho = new KhuPho();
        Console.Write("Nhập số lượng hộ dân: ");
        int n = int.Parse(Console.ReadLine());
        khuPho.NhapHoDan(n);

        int luaChon;
        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Tìm kiếm theo họ tên");
            Console.WriteLine("2. Tìm kiếm theo số nhà");
            Console.WriteLine("3. Hiển thị danh sách hộ dân");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn: ");
            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    Console.Write("Nhập họ tên cần tìm: ");
                    string hoTenTimKiem = Console.ReadLine();
                    khuPho.TimKiemTheoHoTen(hoTenTimKiem);
                    break;
                case 2:
                    Console.Write("Nhập số nhà cần tìm: ");
                    string soNhaTimKiem = Console.ReadLine();
                    khuPho.TimKiemTheoSoNha(soNhaTimKiem);
                    break;
                case 3:
                    khuPho.HienThiDanhSachHoDan();
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
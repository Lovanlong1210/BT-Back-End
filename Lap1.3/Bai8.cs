using System;
using System.Collections.Generic;

public class SinhVien
{
    public string HoTen { get; set; }
    public int NamSinh { get; set; }
    public string Lop { get; set; }
    public string MaSV { get; set; }

    public void NhapThongTin()
    {
        Console.Write("Họ tên: ");
        HoTen = Console.ReadLine();
        Console.Write("Năm sinh: ");
        NamSinh = int.Parse(Console.ReadLine());
        Console.Write("Lớp: ");
        Lop = Console.ReadLine();
        Console.Write("Mã sinh viên: ");
        MaSV = Console.ReadLine();
    }

    public void HienThiThongTin()
    {
        Console.WriteLine($"Họ tên: {HoTen}, Năm sinh: {NamSinh}, Lớp: {Lop}, Mã sinh viên: {MaSV}");
    }
}

public class TheMuon
{
    public SinhVien SinhVien { get; set; }
    public string SoPhieuMuon { get; set; }
    public DateTime NgayMuon { get; set; }
    public DateTime HanTra { get; set; }
    public string SoHieuSach { get; set; }

    public TheMuon()
    {
        SinhVien = new SinhVien();
    }

    public void NhapThongTin()
    {
        SinhVien.NhapThongTin();
        Console.Write("Số phiếu mượn: ");
        SoPhieuMuon = Console.ReadLine();
        Console.Write("Ngày mượn (yyyy-MM-dd): ");
        NgayMuon = DateTime.Parse(Console.ReadLine());
        Console.Write("Hạn trả (yyyy-MM-dd): ");
        HanTra = DateTime.Parse(Console.ReadLine());
        Console.Write("Số hiệu sách: ");
        SoHieuSach = Console.ReadLine();
    }

    public void HienThiThongTin()
    {
        SinhVien.HienThiThongTin();
        Console.WriteLine($"Số phiếu mượn: {SoPhieuMuon}, Ngày mượn: {NgayMuon.ToShortDateString()}, Hạn trả: {HanTra.ToShortDateString()}, Số hiệu sách: {SoHieuSach}");
    }
}

public class QuanLyMuonSach
{
    private List<TheMuon> danhSachMuonSach = new List<TheMuon>();

    public void NhapMuonSach(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhập thông tin mượn sách thứ {i + 1}:");
            TheMuon theMuon = new TheMuon();
            theMuon.NhapThongTin();
            danhSachMuonSach.Add(theMuon);
        }
    }

    public void TimKiemTheoMaSV(string maSV)
    {
        var ketQua = danhSachMuonSach.FindAll(tm => tm.SinhVien.MaSV == maSV);
        if (ketQua.Count > 0)
        {
            Console.WriteLine("Kết quả tìm kiếm:");
            foreach (var tm in ketQua)
            {
                tm.HienThiThongTin();
            }
        }
        else
        {
            Console.WriteLine("Không tìm thấy sinh viên nào.");
        }
    }

    public void HienThiSinhVienQuaHanTra()
    {
        Console.WriteLine("Danh sách sinh viên quá hạn trả sách:");
        foreach (var tm in danhSachMuonSach)
        {
            if (tm.HanTra < DateTime.Now)
            {
                tm.HienThiThongTin();
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        QuanLyMuonSach quanLyMuonSach = new QuanLyMuonSach();
        Console.Write("Nhập số lượng sinh viên mượn sách: ");
        int n = int.Parse(Console.ReadLine());
        quanLyMuonSach.NhapMuonSach(n);

        int luaChon;
        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Tìm kiếm theo mã sinh viên");
            Console.WriteLine("2. Hiển thị sinh viên quá hạn trả sách");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn: ");
            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    Console.Write("Nhập mã sinh viên cần tìm: ");
                    string maSVTimKiem = Console.ReadLine();
                    quanLyMuonSach.TimKiemTheoMaSV(maSVTimKiem);
                    break;
                case 2:
                    quanLyMuonSach.HienThiSinhVienQuaHanTra();
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
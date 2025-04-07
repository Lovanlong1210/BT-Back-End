using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

public class HocSinh
{
    public string HoTen { get; set; }
    public int NamSinh { get; set; }
    public double TongDiem { get; set; }

    public void NhapThongTin()
    {
        Console.Write("Họ tên: ");
        HoTen = Console.ReadLine();
        Console.Write("Năm sinh: ");
        NamSinh = int.Parse(Console.ReadLine());
        Console.Write("Tổng điểm: ");
        TongDiem = double.Parse(Console.ReadLine());
    }

    public void HienThiThongTin()
    {
        Console.WriteLine($"Họ tên: {ChuanHoaTen(HoTen)}, Năm sinh: {NamSinh}, Tổng điểm: {TongDiem}");
    }

    private string ChuanHoaTen(string ten)
    {
        if (string.IsNullOrEmpty(ten))
        {
            return "";
        }

        TextInfo textInfo = new CultureInfo("vi-VN", false).TextInfo;
        string chuanHoa = textInfo.ToTitleCase(Regex.Replace(ten.Trim(), @"\s+", " "));
        return chuanHoa;
    }
}

public class QuanLyHocSinh
{
    private List<HocSinh> danhSachHocSinh = new List<HocSinh>();

    public void NhapDanhSachHocSinh(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhập thông tin học sinh thứ {i + 1}:");
            HocSinh hocSinh = new HocSinh();
            hocSinh.NhapThongTin();
            danhSachHocSinh.Add(hocSinh);
        }
    }

    public void SapXepVaHienThiDanhSach()
    {
        danhSachHocSinh.Sort((hs1, hs2) =>
        {
            int compareDiem = hs2.TongDiem.CompareTo(hs1.TongDiem); // Sắp xếp giảm dần theo tổng điểm
            if (compareDiem != 0)
            {
                return compareDiem;
            }
            return hs1.NamSinh.CompareTo(hs2.NamSinh); // Nếu tổng điểm bằng nhau, sắp xếp tăng dần theo năm sinh
        });

        Console.WriteLine("\nDanh sách học sinh sau khi sắp xếp:");
        foreach (var hocSinh in danhSachHocSinh)
        {
            hocSinh.HienThiThongTin();
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Nhập số lượng học sinh: ");
        int n = int.Parse(Console.ReadLine());

        QuanLyHocSinh quanLyHocSinh = new QuanLyHocSinh();
        quanLyHocSinh.NhapDanhSachHocSinh(n);
        quanLyHocSinh.SapXepVaHienThiDanhSach();
    }
}
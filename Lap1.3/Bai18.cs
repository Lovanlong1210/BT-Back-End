using System;
using System.Collections.Generic;

public class Nguoi
{
    public string HoTen { get; set; }
    public string GioiTinh { get; set; }
    public int Tuoi { get; set; }

    public Nguoi(string hoTen = "", string gioiTinh = "", int tuoi = 0)
    {
        HoTen = hoTen;
        GioiTinh = gioiTinh;
        Tuoi = tuoi;
    }

    public virtual void InThongTin()
    {
        Console.WriteLine($"Họ tên: {HoTen}, Giới tính: {GioiTinh}, Tuổi: {Tuoi}");
    }
}

public class CoQuan : Nguoi
{
    public string DonViCongTac { get; set; }
    public double HeSoLuong { get; set; }

    public CoQuan(string hoTen = "", string gioiTinh = "", int tuoi = 0, string donViCongTac = "", double heSoLuong = 0) : base(hoTen, gioiTinh, tuoi)
    {
        DonViCongTac = donViCongTac;
        HeSoLuong = heSoLuong;
    }

    public override void InThongTin()
    {
        base.InThongTin();
        Console.WriteLine($"Đơn vị: {DonViCongTac}, Hệ số lương: {HeSoLuong}, Lương: {TinhLuong()}");
    }

    public double TinhLuong()
    {
        return HeSoLuong * 1050000;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Nhập số lượng cá nhân trong cơ quan: ");
        int n = int.Parse(Console.ReadLine());
        List<CoQuan> danhSachCoQuan = new List<CoQuan>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhập thông tin cá nhân thứ {i + 1}:");
            Console.Write("Họ tên: ");
            string hoTen = Console.ReadLine();
            Console.Write("Giới tính: ");
            string gioiTinh = Console.ReadLine();
            Console.Write("Tuổi: ");
            int tuoi = int.Parse(Console.ReadLine());
            Console.Write("Đơn vị công tác: ");
            string donViCongTac = Console.ReadLine();
            Console.Write("Hệ số lương: ");
            double heSoLuong = double.Parse(Console.ReadLine());
            danhSachCoQuan.Add(new CoQuan(hoTen, gioiTinh, tuoi, donViCongTac, heSoLuong));
        }

        Console.WriteLine("\nThông tin cá nhân thuộc phòng Tài chính:");
        foreach (var caNhan in danhSachCoQuan)
        {
            if (caNhan.DonViCongTac.ToLower() == "phòng tài chính")
            {
                caNhan.InThongTin();
            }
        }

        Console.Write("\nNhập họ tên cần tìm: ");
        string hoTenTimKiem = Console.ReadLine();
        Console.WriteLine($"\nThông tin cá nhân có họ tên '{hoTenTimKiem}':");
        foreach (var caNhan in danhSachCoQuan)
        {
            if (caNhan.HoTen.ToLower().Contains(hoTenTimKiem.ToLower()))
            {
                caNhan.InThongTin();
            }
        }
    }
}
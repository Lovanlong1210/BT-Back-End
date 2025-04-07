using System;
using System.Collections.Generic;

public class ThiSinh
{
    public string SoBaoDanh { get; set; }
    public string HoTen { get; set; }
    public string DiaChi { get; set; }
    public int UuTien { get; set; }

    public virtual void NhapThongTin()
    {
        Console.Write("Số báo danh: ");
        SoBaoDanh = Console.ReadLine();
        Console.Write("Họ tên: ");
        HoTen = Console.ReadLine();
        Console.Write("Địa chỉ: ");
        DiaChi = Console.ReadLine();
        Console.Write("Ưu tiên: ");
        UuTien = int.Parse(Console.ReadLine());
    }

    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Số báo danh: {SoBaoDanh}, Họ tên: {HoTen}, Địa chỉ: {DiaChi}, Ưu tiên: {UuTien}");
    }
}

public class ThiSinhKhoiA : ThiSinh
{
    public double Toan { get; set; }
    public double Ly { get; set; }
    public double Hoa { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Điểm Toán: ");
        Toan = double.Parse(Console.ReadLine());
        Console.Write("Điểm Lý: ");
        Ly = double.Parse(Console.ReadLine());
        Console.Write("Điểm Hóa: ");
        Hoa = double.Parse(Console.ReadLine());
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Điểm Toán: {Toan}, Điểm Lý: {Ly}, Điểm Hóa: {Hoa}");
    }

    public double TongDiem()
    {
        return Toan + Ly + Hoa;
    }
}

public class ThiSinhKhoiB : ThiSinh
{
    public double Toan { get; set; }
    public double Hoa { get; set; }
    public double Sinh { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Điểm Toán: ");
        Toan = double.Parse(Console.ReadLine());
        Console.Write("Điểm Hóa: ");
        Hoa = double.Parse(Console.ReadLine());
        Console.Write("Điểm Sinh: ");
        Sinh = double.Parse(Console.ReadLine());
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Điểm Toán: {Toan}, Điểm Hóa: {Hoa}, Điểm Sinh: {Sinh}");
    }

    public double TongDiem()
    {
        return Toan + Hoa + Sinh;
    }
}

public class ThiSinhKhoiC : ThiSinh
{
    public double Van { get; set; }
    public double Su { get; set; }
    public double Dia { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Điểm Văn: ");
        Van = double.Parse(Console.ReadLine());
        Console.Write("Điểm Sử: ");
        Su = double.Parse(Console.ReadLine());
        Console.Write("Điểm Địa: ");
        Dia = double.Parse(Console.ReadLine());
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Điểm Văn: {Van}, Điểm Sử: {Su}, Điểm Địa: {Dia}");
    }

    public double TongDiem()
    {
        return Van + Su + Dia;
    }
}

public class TuyenSinh
{
    private List<ThiSinh> danhSachThiSinh = new List<ThiSinh>();

    public void NhapThiSinh()
    {
        Console.WriteLine("Chọn khối thi (A, B, C):");
        string khoiThi = Console.ReadLine().ToUpper();

        ThiSinh thiSinh;
        switch (khoiThi)
        {
            case "A":
                thiSinh = new ThiSinhKhoiA();
                break;
            case "B":
                thiSinh = new ThiSinhKhoiB();
                break;
            case "C":
                thiSinh = new ThiSinhKhoiC();
                break;
            default:
                Console.WriteLine("Khối thi không hợp lệ.");
                return;
        }

        thiSinh.NhapThongTin();
        danhSachThiSinh.Add(thiSinh);
    }

    public void HienThiThiSinhTrungTuyen()
    {
        Console.WriteLine("Danh sách thí sinh trúng tuyển:");
        foreach (var ts in danhSachThiSinh)
        {
            double diemChuan = 0;
            double tongDiem = 0;
            if (ts is ThiSinhKhoiA)
            {
                diemChuan = 15;
                tongDiem = ((ThiSinhKhoiA)ts).TongDiem();
            }
            else if (ts is ThiSinhKhoiB)
            {
                diemChuan = 16;
                tongDiem = ((ThiSinhKhoiB)ts).TongDiem();
            }
            else if (ts is ThiSinhKhoiC)
            {
                diemChuan = 13.5;
                tongDiem = ((ThiSinhKhoiC)ts).TongDiem();
            }

            if (tongDiem >= diemChuan)
            {
                ts.HienThiThongTin();
            }
        }
    }

    public void TimKiemTheoSBD(string soBaoDanh)
    {
        var thiSinh = danhSachThiSinh.Find(ts => ts.SoBaoDanh == soBaoDanh);
        if (thiSinh != null)
        {
            Console.WriteLine("Thông tin thí sinh:");
            thiSinh.HienThiThongTin();
        }
        else
        {
            Console.WriteLine("Không tìm thấy thí sinh nào.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        TuyenSinh tuyenSinh = new TuyenSinh();
        int luaChon;
        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Nhập thông tin thí sinh");
            Console.WriteLine("2. Hiển thị thí sinh trúng tuyển");
            Console.WriteLine("3. Tìm kiếm thí sinh theo SBD");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn: ");
            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    tuyenSinh.NhapThiSinh();
                    break;
                case 2:
                    tuyenSinh.HienThiThiSinhTrungTuyen();
                    break;
                case 3:
                    Console.Write("Nhập số báo danh cần tìm: ");
                    string sbdTimKiem = Console.ReadLine();
                    tuyenSinh.TimKiemTheoSBD(sbdTimKiem);
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

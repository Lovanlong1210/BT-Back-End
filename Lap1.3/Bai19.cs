using System;
using System.Collections.Generic;

public struct HoTen
{
    public string Ho;
    public string TenDem;
    public string Ten;
}

public struct QueQuan
{
    public string Xa;
    public string Huyen;
    public string Tinh;
}

public struct DiemThi
{
    public double Toan;
    public double Ly;
    public double Hoa;
}

public class Thisinh
{
    public HoTen HoTen;
    public QueQuan QueQuan;
    public string Truong;
    public int Tuoi;
    public string SoBaoDanh;
    public DiemThi DiemThi;

    public void NhapThongTin()
    {
        Console.Write("Họ: ");
        HoTen.Ho = Console.ReadLine();
        Console.Write("Tên đệm: ");
        HoTen.TenDem = Console.ReadLine();
        Console.Write("Tên: ");
        HoTen.Ten = Console.ReadLine();

        Console.Write("Xã: ");
        QueQuan.Xa = Console.ReadLine();
        Console.Write("Huyện: ");
        QueQuan.Huyen = Console.ReadLine();
        Console.Write("Tỉnh: ");
        QueQuan.Tinh = Console.ReadLine();

        Console.Write("Trường: ");
        Truong = Console.ReadLine();
        Console.Write("Tuổi: ");
        Tuoi = int.Parse(Console.ReadLine());
        Console.Write("Số báo danh: ");
        SoBaoDanh = Console.ReadLine();

        Console.Write("Điểm Toán: ");
        DiemThi.Toan = double.Parse(Console.ReadLine());
        Console.Write("Điểm Lý: ");
        DiemThi.Ly = double.Parse(Console.ReadLine());
        Console.Write("Điểm Hoá: ");
        DiemThi.Hoa = double.Parse(Console.ReadLine());
    }

    public void HienThiThongTin()
    {
        Console.WriteLine($"Họ tên: {HoTen.Ho} {HoTen.TenDem} {HoTen.Ten}");
        Console.WriteLine($"Quê quán: {QueQuan.Xa}, {QueQuan.Huyen}, {QueQuan.Tinh}");
        Console.WriteLine($"Trường: {Truong}, Tuổi: {Tuoi}, Số báo danh: {SoBaoDanh}");
        Console.WriteLine($"Điểm: Toán={DiemThi.Toan}, Lý={DiemThi.Ly}, Hoá={DiemThi.Hoa}");
    }

    public double TinhTongDiem()
    {
        return DiemThi.Toan + DiemThi.Ly + DiemThi.Hoa;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Nhập số lượng thí sinh: ");
        int n = int.Parse(Console.ReadLine());
        List<Thisinh> danhSachThiSinh = new List<Thisinh>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhập thông tin thí sinh thứ {i + 1}:");
            Thisinh thiSinh = new Thisinh();
            thiSinh.NhapThongTin();
            danhSachThiSinh.Add(thiSinh);
        }

        Console.WriteLine("\nThí sinh có tổng điểm trên 15:");
        foreach (var thiSinh in danhSachThiSinh)
        {
            if (thiSinh.TinhTongDiem() > 15)
            {
                thiSinh.HienThiThongTin();
            }
        }

        danhSachThiSinh.Sort((a, b) => b.TinhTongDiem().CompareTo(a.TinhTongDiem()));

        Console.WriteLine("\nDanh sách thí sinh sau khi sắp xếp theo tổng điểm giảm dần:");
        Console.WriteLine("Họ tên\tQuê quán\tSBD\tToán\tLý\tHoá");
        foreach (var thiSinh in danhSachThiSinh)
        {
            Console.WriteLine($"{thiSinh.HoTen.Ho} {thiSinh.HoTen.TenDem} {thiSinh.HoTen.Ten}\t{thiSinh.QueQuan.Xa}, {thiSinh.QueQuan.Huyen}, {thiSinh.QueQuan.Tinh}\t{thiSinh.SoBaoDanh}\t{thiSinh.DiemThi.Toan}\t{thiSinh.DiemThi.Ly}\t{thiSinh.DiemThi.Hoa}");
        }
    }
}
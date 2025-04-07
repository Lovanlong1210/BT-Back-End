using System;
using System.Collections.Generic;

public class HocSinh
{
    public string HoTen { get; set; }
    public string GioiTinh { get; set; }
    public double DiemToan { get; set; }
    public double DiemLy { get; set; }
    public double DiemHoa { get; set; }

    public void NhapThongTin()
    {
        Console.Write("Họ tên: ");
        HoTen = Console.ReadLine();
        Console.Write("Giới tính: ");
        GioiTinh = Console.ReadLine();
        Console.Write("Điểm Toán: ");
        DiemToan = double.Parse(Console.ReadLine());
        Console.Write("Điểm Lý: ");
        DiemLy = double.Parse(Console.ReadLine());
        Console.Write("Điểm Hoá: ");
        DiemHoa = double.Parse(Console.ReadLine());
    }

    public void HienThiThongTin()
    {
        Console.WriteLine($"Họ tên: {HoTen}, Giới tính: {GioiTinh}, Toán: {DiemToan}, Lý: {DiemLy}, Hoá: {DiemHoa}");
    }
}

public class HocSinhNam : HocSinh
{
    public double DiemKyThuat { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Điểm Kỹ thuật: ");
        DiemKyThuat = double.Parse(Console.ReadLine());
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Kỹ thuật: {DiemKyThuat}");
    }
}

public class HocSinhNu : HocSinh
{
    public double DiemNuCong { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Điểm Nữ công: ");
        DiemNuCong = double.Parse(Console.ReadLine());
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Nữ công: {DiemNuCong}");
    }
}

public class QuanLyHocSinh
{
    private List<HocSinh> danhSachHocSinh = new List<HocSinh>();

    public void NhapDanhSachHocSinh(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhập thông tin học sinh thứ {i + 1}:");
            Console.Write("Nhập giới tính (Nam/Nữ): ");
            string gioiTinh = Console.ReadLine().ToLower();

            HocSinh hocSinh;
            if (gioiTinh == "nam")
            {
                hocSinh = new HocSinhNam();
            }
            else if (gioiTinh == "nữ")
            {
                hocSinh = new HocSinhNu();
            }
            else
            {
                Console.WriteLine("Giới tính không hợp lệ, bỏ qua học sinh này.");
                continue;
            }

            hocSinh.NhapThongTin();
            danhSachHocSinh.Add(hocSinh);
        }
    }

    public void HienThiHocSinhNamKyThuatLonHon8()
    {
        Console.WriteLine("\nHọc sinh nam có điểm Kỹ thuật không nhỏ hơn 8:");
        foreach (var hs in danhSachHocSinh)
        {
            if (hs is HocSinhNam && ((HocSinhNam)hs).DiemKyThuat >= 8)
            {
                hs.HienThiThongTin();
            }
        }
    }

    public void InDanhSachHocSinhTheoGioiTinh()
    {
        Console.WriteLine("\nDanh sách học sinh (Nam trước, Nữ sau):");
        foreach (var hs in danhSachHocSinh)
        {
            if (hs is HocSinhNam)
            {
                hs.HienThiThongTin();
            }
        }
        foreach (var hs in danhSachHocSinh)
        {
            if (hs is HocSinhNu)
            {
                hs.HienThiThongTin();
            }
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

        quanLyHocSinh.HienThiHocSinhNamKyThuatLonHon8();
        quanLyHocSinh.InDanhSachHocSinhTheoGioiTinh();
    }
}
using System;
using System.Collections.Generic;

public class TaiLieu
{
    public string MaTaiLieu { get; set; }
    public string TenNhaXuatBan { get; set; }
    public int SoBanPhatHanh { get; set; }

    public virtual void NhapThongTin()
    {
        Console.Write("Mã tài liệu: ");
        MaTaiLieu = Console.ReadLine();
        Console.Write("Tên nhà xuất bản: ");
        TenNhaXuatBan = Console.ReadLine();
        Console.Write("Số bản phát hành: ");
        SoBanPhatHanh = int.Parse(Console.ReadLine());
    }

    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Mã tài liệu: {MaTaiLieu}, Tên nhà xuất bản: {TenNhaXuatBan}, Số bản phát hành: {SoBanPhatHanh}");
    }
}

public class Sach : TaiLieu
{
    public string TenTacGia { get; set; }
    public int SoTrang { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Tên tác giả: ");
        TenTacGia = Console.ReadLine();
        Console.Write("Số trang: ");
        SoTrang = int.Parse(Console.ReadLine());
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Tên tác giả: {TenTacGia}, Số trang: {SoTrang}");
    }
}

public class TapChi : TaiLieu
{
    public int SoPhatHanh { get; set; }
    public int ThangPhatHanh { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Số phát hành: ");
        SoPhatHanh = int.Parse(Console.ReadLine());
        Console.Write("Tháng phát hành: ");
        ThangPhatHanh = int.Parse(Console.ReadLine());
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Số phát hành: {SoPhatHanh}, Tháng phát hành: {ThangPhatHanh}");
    }
}

public class Bao : TaiLieu
{
    public string NgayPhatHanh { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Ngày phát hành: ");
        NgayPhatHanh = Console.ReadLine();
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Ngày phát hành: {NgayPhatHanh}");
    }
}

public class QuanLyTaiLieu
{
    private List<TaiLieu> danhSachTaiLieu = new List<TaiLieu>();

    public void NhapTaiLieu()
    {
        Console.WriteLine("Chọn loại tài liệu muốn nhập (1: Sách, 2: Tạp chí, 3: Báo):");
        int loaiTaiLieu = int.Parse(Console.ReadLine());

        TaiLieu taiLieu;
        switch (loaiTaiLieu)
        {
            case 1:
                taiLieu = new Sach();
                break;
            case 2:
                taiLieu = new TapChi();
                break;
            case 3:
                taiLieu = new Bao();
                break;
            default:
                Console.WriteLine("Lựa chọn không hợp lệ.");
                return;
        }

        taiLieu.NhapThongTin();
        danhSachTaiLieu.Add(taiLieu);
    }

    public void HienThiDanhSachTaiLieu()
    {
        Console.WriteLine("Danh sách tài liệu:");
        foreach (var tl in danhSachTaiLieu)
        {
            tl.HienThiThongTin();
        }
    }

    public void TimKiemTheoLoai(string loai)
    {
        List<TaiLieu> ketQua = new List<TaiLieu>();
        switch (loai.ToLower())
        {
            case "sach":
                ketQua = danhSachTaiLieu.FindAll(tl => tl is Sach);
                break;
            case "tapchi":
                ketQua = danhSachTaiLieu.FindAll(tl => tl is TapChi);
                break;
            case "bao":
                ketQua = danhSachTaiLieu.FindAll(tl => tl is Bao);
                break;
            default:
                Console.WriteLine("Loại tài liệu không hợp lệ.");
                return;
        }

        if (ketQua.Count > 0)
        {
            Console.WriteLine($"Kết quả tìm kiếm theo loại '{loai}':");
            foreach (var tl in ketQua)
            {
                tl.HienThiThongTin();
            }
        }
        else
        {
            Console.WriteLine("Không tìm thấy tài liệu nào.");
        }
    }
}

public class Application
{
    public static void Main(string[] args)
    {
        QuanLyTaiLieu quanLyTaiLieu = new QuanLyTaiLieu();
        int luaChon;
        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Nhập thông tin tài liệu");
            Console.WriteLine("2. Hiển thị danh sách tài liệu");
            Console.WriteLine("3. Tìm kiếm tài liệu theo loại");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn: ");
            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    quanLyTaiLieu.NhapTaiLieu();
                    break;
                case 2:
                    quanLyTaiLieu.HienThiDanhSachTaiLieu();
                    break;
                case 3:
                    Console.Write("Nhập loại tài liệu cần tìm (Sách, Tạp chí, Báo): ");
                    string loaiTimKiem = Console.ReadLine();
                    quanLyTaiLieu.TimKiemTheoLoai(loaiTimKiem);
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
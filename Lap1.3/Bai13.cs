using System;
using System.Collections.Generic;

public class PTGT
{
    public string HangSanXuat { get; set; }
    public int NamSanXuat { get; set; }
    public double GiaBan { get; set; }
    public string Mau { get; set; }

    public virtual void NhapThongTin()
    {
        Console.Write("Hãng sản xuất: ");
        HangSanXuat = Console.ReadLine();
        Console.Write("Năm sản xuất: ");
        NamSanXuat = int.Parse(Console.ReadLine());
        Console.Write("Giá bán: ");
        GiaBan = double.Parse(Console.ReadLine());
        Console.Write("Màu: ");
        Mau = Console.ReadLine();
    }

    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Hãng SX: {HangSanXuat}, Năm SX: {NamSanXuat}, Giá: {GiaBan}, Màu: {Mau}");
    }
}

public class OTo : PTGT
{
    public int SoChoNgoi { get; set; }
    public string KieuDongCo { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Số chỗ ngồi: ");
        SoChoNgoi = int.Parse(Console.ReadLine());
        Console.Write("Kiểu động cơ: ");
        KieuDongCo = Console.ReadLine();
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Số chỗ: {SoChoNgoi}, Động cơ: {KieuDongCo}");
    }
}

public class XeMay : PTGT
{
    public double CongSuat { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Công suất: ");
        CongSuat = double.Parse(Console.ReadLine());
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Công suất: {CongSuat}");
    }
}

public class XeTai : PTGT
{
    public double TrongTai { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Trọng tải: ");
        TrongTai = double.Parse(Console.ReadLine());
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Trọng tải: {TrongTai}");
    }
}

public class QLPTGT
{
    private List<PTGT> danhSachPTGT = new List<PTGT>();

    public void NhapPTGT()
    {
        Console.WriteLine("Chọn loại phương tiện (1: Ô tô, 2: Xe máy, 3: Xe tải):");
        int loaiPTGT = int.Parse(Console.ReadLine());

        PTGT ptgt;
        switch (loaiPTGT)
        {
            case 1:
                ptgt = new OTo();
                break;
            case 2:
                ptgt = new XeMay();
                break;
            case 3:
                ptgt = new XeTai();
                break;
            default:
                Console.WriteLine("Lựa chọn không hợp lệ.");
                return;
        }

        ptgt.NhapThongTin();
        danhSachPTGT.Add(ptgt);
    }

    public void TimTheoMauHoacNam(string timKiem)
    {
        var ketQua = danhSachPTGT.FindAll(pt => pt.Mau.Contains(timKiem) || pt.NamSanXuat.ToString() == timKiem);
        if (ketQua.Count > 0)
        {
            Console.WriteLine("Kết quả tìm kiếm:");
            foreach (var pt in ketQua)
            {
                pt.HienThiThongTin();
            }
        }
        else
        {
            Console.WriteLine("Không tìm thấy phương tiện nào.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        QLPTGT quanLyPTGT = new QLPTGT();

        int luaChon;
        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Nhập đăng ký phương tiện");
            Console.WriteLine("2. Tìm kiếm phương tiện");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn: ");
            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    quanLyPTGT.NhapPTGT();
                    break;
                case 2:
                    Console.Write("Nhập màu hoặc năm sản xuất cần tìm: ");
                    string timKiem = Console.ReadLine();
                    quanLyPTGT.TimTheoMauHoacNam(timKiem);
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
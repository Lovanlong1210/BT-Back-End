using System;
using System.Collections.Generic;
using System.Text;

public class CanBo
{

    public string HoTen { get; set; }
    public int NamSinh { get; set; }
    public string GioiTinh { get; set; }
    public string DiaChi { get; set; }

    public virtual void NhapThongTin()
    {
        Console.Write("Họ tên: ");
        HoTen = Console.ReadLine();
        Console.Write("Năm sinh: ");
        NamSinh = int.Parse(Console.ReadLine());
        Console.Write("Giới tính: ");
        GioiTinh = Console.ReadLine();
        Console.Write("Địa chỉ: ");
        DiaChi = Console.ReadLine();
    }

    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Họ tên: {HoTen}, Năm sinh: {NamSinh}, Giới tính: {GioiTinh}, Địa chỉ: {DiaChi}");
    }
}

public class CongNhan : CanBo
{
    public string Bac { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Bậc: ");
        Bac = Console.ReadLine();
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Bậc: {Bac}");
    }
}

public class KySu : CanBo
{
    public string NganhDaoTao { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Ngành đào tạo: ");
        NganhDaoTao = Console.ReadLine();
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Ngành đào tạo: {NganhDaoTao}");
    }
}

public class NhanVienPhucVu : CanBo
{
    public string CongViec { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Công việc: ");
        CongViec = Console.ReadLine();
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Công việc: {CongViec}");
    }
}

public class QLCB
{
    private List<CanBo> danhSachCanBo = new List<CanBo>();

    public void NhapCanBo()
    {
        Console.WriteLine("Chọn loại cán bộ muốn nhập (1: Công nhân, 2: Kỹ sư, 3: Nhân viên):");
        int loaiCanBo = int.Parse(Console.ReadLine());

        CanBo canBo;
        switch (loaiCanBo)
        {
            case 1:
                canBo = new CongNhan();
                break;
            case 2:
                canBo = new KySu();
                break;
            case 3:
                canBo = new NhanVienPhucVu();
                break;
            default:
                Console.WriteLine("Lựa chọn không hợp lệ.");
                return;
        }

        canBo.NhapThongTin();
        danhSachCanBo.Add(canBo);
    }

    public void TimKiemTheoHoTen(string hoTen)
    {
        var ketQua = danhSachCanBo.FindAll(cb => cb.HoTen.Contains(hoTen));
        if (ketQua.Count > 0)
        {
            Console.WriteLine("Kết quả tìm kiếm:");
            foreach (var cb in ketQua)
            {
                cb.HienThiThongTin();
            }
        }
        else
        {
            Console.WriteLine("Không tìm thấy cán bộ nào.");
        }
    }

    public void HienThiDanhSachCanBo()
    {
        Console.WriteLine("Danh sách cán bộ:");
        foreach (var cb in danhSachCanBo)
        {
            cb.HienThiThongTin();
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        QLCB quanLyCanBo = new QLCB();
        int luaChon;
        do
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Nhập thông tin cán bộ");
            Console.WriteLine("2. Tìm kiếm theo họ tên");
            Console.WriteLine("3. Hiển thị danh sách cán bộ");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn: ");
            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    quanLyCanBo.NhapCanBo();
                    break;
                case 2:
                    Console.Write("Nhập họ tên cần tìm: ");
                    string hoTenTimKiem = Console.ReadLine();
                    quanLyCanBo.TimKiemTheoHoTen(hoTenTimKiem);
                    break;
                case 3:
                    quanLyCanBo.HienThiDanhSachCanBo();
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
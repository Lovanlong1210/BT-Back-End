using System;
using System.Collections.Generic;

// Lớp cơ sở CanBo
public class CanBo
{
    public string HoTen { get; set; }
    public int NamSinh { get; set; }
    public string GioiTinh { get; set; }
    public string DiaChi { get; set; }

    public virtual void NhapThongTin()
    {
        Console.Write("Nhập họ tên: ");
        HoTen = Console.ReadLine();

        Console.Write("Nhập năm sinh: ");
        NamSinh = int.Parse(Console.ReadLine());

        Console.Write("Nhập giới tính: ");
        GioiTinh = Console.ReadLine();

        Console.Write("Nhập địa chỉ: ");
        DiaChi = Console.ReadLine();
    }

    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Họ tên: {HoTen}");
        Console.WriteLine($"Năm sinh: {NamSinh}");
        Console.WriteLine($"Giới tính: {GioiTinh}");
        Console.WriteLine($"Địa chỉ: {DiaChi}");
    }
}

// Lớp CongNhan kế thừa từ CanBo
public class CongNhan : CanBo
{
    public string Bac { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Nhập bậc công nhân (ví dụ: 3/7): ");
        Bac = Console.ReadLine();
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Bậc: {Bac}");
        Console.WriteLine("Chức vụ: Công nhân");
    }
}

// Lớp KySu kế thừa từ CanBo
public class KySu : CanBo
{
    public string NganhDaoTao { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Nhập ngành đào tạo: ");
        NganhDaoTao = Console.ReadLine();
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Ngành đào tạo: {NganhDaoTao}");
        Console.WriteLine("Chức vụ: Kỹ sư");
    }
}

// Lớp NhanVien kế thừa từ CanBo
public class NhanVien : CanBo
{
    public string CongViec { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Nhập công việc: ");
        CongViec = Console.ReadLine();
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Công việc: {CongViec}");
        Console.WriteLine("Chức vụ: Nhân viên phục vụ");
    }
}

// Lớp quản lý cán bộ
public class QLCB
{
    private List<CanBo> danhSachCanBo = new List<CanBo>();

    public void ThemCanBo()
    {
        Console.WriteLine("Chọn loại cán bộ:");
        Console.WriteLine("1. Công nhân");
        Console.WriteLine("2. Kỹ sư");
        Console.WriteLine("3. Nhân viên phục vụ");
        Console.Write("Lựa chọn của bạn: ");
        int luaChon = int.Parse(Console.ReadLine());

        CanBo canBo = null;

        switch (luaChon)
        {
            case 1:
                canBo = new CongNhan();
                break;
            case 2:
                canBo = new KySu();
                break;
            case 3:
                canBo = new NhanVien();
                break;
            default:
                Console.WriteLine("Lựa chọn không hợp lệ!");
                return;
        }

        canBo.NhapThongTin();
        danhSachCanBo.Add(canBo);
        Console.WriteLine("Đã thêm cán bộ thành công!");
    }

    public void TimKiemTheoHoTen()
    {
        Console.Write("Nhập họ tên cần tìm: ");
        string hoTen = Console.ReadLine();

        bool found = false;
        foreach (var cb in danhSachCanBo)
        {
            if (cb.HoTen.ToLower().Contains(hoTen.ToLower()))
            {
                cb.HienThiThongTin();
                Console.WriteLine("-------------------");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Không tìm thấy cán bộ nào có tên như trên!");
        }
    }

    public void HienThiDanhSachCanBo()
    {
        if (danhSachCanBo.Count == 0)
        {
            Console.WriteLine("Danh sách cán bộ trống!");
            return;
        }

        Console.WriteLine("===== DANH SÁCH CÁN BỘ =====");
        foreach (var cb in danhSachCanBo)
        {
            cb.HienThiThongTin();
            Console.WriteLine("-------------------");
        }
    }
}

// Chương trình chính
class Program
{
    static void Main(string[] args)
    {
        QLCB qlcb = new QLCB();
        int luaChon;

        do
        {
            Console.WriteLine("\n===== QUẢN LÝ CÁN BỘ =====");
            Console.WriteLine("1. Thêm cán bộ mới");
            Console.WriteLine("2. Tìm kiếm theo họ tên");
            Console.WriteLine("3. Hiển thị danh sách cán bộ");
            Console.WriteLine("4. Thoát chương trình");
            Console.Write("Lựa chọn của bạn: ");
            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    qlcb.ThemCanBo();
                    break;
                case 2:
                    qlcb.TimKiemTheoHoTen();
                    break;
                case 3:
                    qlcb.HienThiDanhSachCanBo();
                    break;
                case 4:
                    Console.WriteLine("Cảm ơn đã sử dụng chương trình!");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ! Vui lòng chọn lại.");
                    break;
            }
        } while (luaChon != 4);
    }
}
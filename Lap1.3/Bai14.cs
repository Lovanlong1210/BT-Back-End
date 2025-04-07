using System;

public class PhanSo
{
    public int TuSo { get; set; }
    public int MauSo { get; set; }

    public PhanSo()
    {
        TuSo = 0;
        MauSo = 1;
    }

    public PhanSo(int tu, int mau)
    {
        TuSo = tu;
        MauSo = mau;
    }

    public void NhapPhanSo()
    {
        Console.Write("Tử số: ");
        TuSo = int.Parse(Console.ReadLine());
        Console.Write("Mẫu số: ");
        MauSo = int.Parse(Console.ReadLine());
    }

    public void HienThiPhanSo()
    {
        Console.WriteLine($"{TuSo}/{MauSo}");
    }

    public void RutGon()
    {
        int ucln = TimUCLN(TuSo, MauSo);
        TuSo /= ucln;
        MauSo /= ucln;
    }

    private int TimUCLN(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public static PhanSo Cong(PhanSo a, PhanSo b)
    {
        int tu = a.TuSo * b.MauSo + b.TuSo * a.MauSo;
        int mau = a.MauSo * b.MauSo;
        PhanSo ketQua = new PhanSo(tu, mau);
        ketQua.RutGon();
        return ketQua;
    }

    public static PhanSo Tru(PhanSo a, PhanSo b)
    {
        int tu = a.TuSo * b.MauSo - b.TuSo * a.MauSo;
        int mau = a.MauSo * b.MauSo;
        PhanSo ketQua = new PhanSo(tu, mau);
        ketQua.RutGon();
        return ketQua;
    }

    public static PhanSo Nhan(PhanSo a, PhanSo b)
    {
        int tu = a.TuSo * b.TuSo;
        int mau = a.MauSo * b.MauSo;
        PhanSo ketQua = new PhanSo(tu, mau);
        ketQua.RutGon();
        return ketQua;
    }

    public static PhanSo Chia(PhanSo a, PhanSo b)
    {
        int tu = a.TuSo * b.MauSo;
        int mau = a.MauSo * b.TuSo;
        PhanSo ketQua = new PhanSo(tu, mau);
        ketQua.RutGon();
        return ketQua;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        PhanSo a = new PhanSo();
        PhanSo b = new PhanSo();

        Console.WriteLine("Nhập phân số A:");
        a.NhapPhanSo();

        Console.WriteLine("Nhập phân số B:");
        b.NhapPhanSo();

        int luaChon;
        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Cộng hai phân số");
            Console.WriteLine("2. Trừ hai phân số");
            Console.WriteLine("3. Nhân hai phân số");
            Console.WriteLine("4. Chia hai phân số");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn: ");
            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    PhanSo.Cong(a, b).HienThiPhanSo();
                    break;
                case 2:
                    PhanSo.Tru(a, b).HienThiPhanSo();
                    break;
                case 3:
                    PhanSo.Nhan(a, b).HienThiPhanSo();
                    break;
                case 4:
                    PhanSo.Chia(a, b).HienThiPhanSo();
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
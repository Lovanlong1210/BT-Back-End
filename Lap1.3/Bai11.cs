using System;

public class SoPhuc
{
    public double PhanThuc { get; set; }
    public double PhanAo { get; set; }

    public SoPhuc()
    {
        PhanThuc = 0;
        PhanAo = 0;
    }

    public SoPhuc(double a, double b)
    {
        PhanThuc = a;
        PhanAo = b;
    }

    public void NhapSoPhuc()
    {
        Console.Write("Phần thực: ");
        PhanThuc = double.Parse(Console.ReadLine());
        Console.Write("Phần ảo: ");
        PhanAo = double.Parse(Console.ReadLine());
    }

    public void HienThiSoPhuc()
    {
        Console.WriteLine($"{PhanThuc} + {PhanAo}i");
    }

    public static SoPhuc Cong(SoPhuc a, SoPhuc b)
    {
        return new SoPhuc(a.PhanThuc + b.PhanThuc, a.PhanAo + b.PhanAo);
    }

    public static SoPhuc Tru(SoPhuc a, SoPhuc b)
    {
        return new SoPhuc(a.PhanThuc - b.PhanThuc, a.PhanAo - b.PhanAo);
    }

    public static SoPhuc Nhan(SoPhuc a, SoPhuc b)
    {
        return new SoPhuc(a.PhanThuc * b.PhanThuc - a.PhanAo * b.PhanAo, a.PhanThuc * b.PhanAo + a.PhanAo * b.PhanThuc);
    }

    public static SoPhuc Chia(SoPhuc a, SoPhuc b)
    {
        double mau = b.PhanThuc * b.PhanThuc + b.PhanAo * b.PhanAo;
        return new SoPhuc((a.PhanThuc * b.PhanThuc + a.PhanAo * b.PhanAo) / mau, (a.PhanAo * b.PhanThuc - a.PhanThuc * b.PhanAo) / mau);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        SoPhuc a = new SoPhuc();
        SoPhuc b = new SoPhuc();

        Console.WriteLine("Nhập số phức A:");
        a.NhapSoPhuc();

        Console.WriteLine("Nhập số phức B:");
        b.NhapSoPhuc();

        int luaChon;
        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("a. Tính tổng hai số phức");
            Console.WriteLine("b. Tính hiệu hai số phức");
            Console.WriteLine("c. Tính tích hai số phức");
            Console.WriteLine("d. Tính thương hai số phức");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn: ");
            luaChon = Console.ReadLine()[0];

            switch (luaChon)
            {
                case 'a':
                    SoPhuc.Cong(a, b).HienThiSoPhuc();
                    break;
                case 'b':
                    SoPhuc.Tru(a, b).HienThiSoPhuc();
                    break;
                case 'c':
                    SoPhuc.Nhan(a, b).HienThiSoPhuc();
                    break;
                case 'd':
                    SoPhuc.Chia(a, b).HienThiSoPhuc();
                    break;
                case '0':
                    Console.WriteLine("Thoát chương trình.");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    break;
            }
        } while (luaChon != '0');
    }
}
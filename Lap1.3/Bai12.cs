using System;

public class MaTran
{
    public int SoDong { get; set; }
    public int SoCot { get; set; }
    public int[,] PhanTu { get; set; }

    public MaTran()
    {
        SoDong = 0;
        SoCot = 0;
        PhanTu = null;
    }

    public MaTran(int n, int m)
    {
        SoDong = n;
        SoCot = m;
        PhanTu = new int[n, m];
    }

    public void NhapMaTran()
    {
        Console.Write("Số dòng: ");
        SoDong = int.Parse(Console.ReadLine());
        Console.Write("Số cột: ");
        SoCot = int.Parse(Console.ReadLine());
        PhanTu = new int[SoDong, SoCot];

        for (int i = 0; i < SoDong; i++)
        {
            for (int j = 0; j < SoCot; j++)
            {
                Console.Write($"Phần tử [{i},{j}]: ");
                PhanTu[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }

    public void HienThiMaTran()
    {
        for (int i = 0; i < SoDong; i++)
        {
            for (int j = 0; j < SoCot; j++)
            {
                Console.Write($"{PhanTu[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    public static MaTran Cong(MaTran a, MaTran b)
    {
        if (a.SoDong != b.SoDong || a.SoCot != b.SoCot)
        {
            Console.WriteLine("Lỗi: Hai ma trận không cùng kích thước.");
            return null;
        }

        MaTran ketQua = new MaTran(a.SoDong, a.SoCot);
        for (int i = 0; i < a.SoDong; i++)
        {
            for (int j = 0; j < a.SoCot; j++)
            {
                ketQua.PhanTu[i, j] = a.PhanTu[i, j] + b.PhanTu[i, j];
            }
        }
        return ketQua;
    }

    public static MaTran Tru(MaTran a, MaTran b)
    {
        if (a.SoDong != b.SoDong || a.SoCot != b.SoCot)
        {
            Console.WriteLine("Lỗi: Hai ma trận không cùng kích thước.");
            return null;
        }

        MaTran ketQua = new MaTran(a.SoDong, a.SoCot);
        for (int i = 0; i < a.SoDong; i++)
        {
            for (int j = 0; j < a.SoCot; j++)
            {
                ketQua.PhanTu[i, j] = a.PhanTu[i, j] - b.PhanTu[i, j];
            }
        }
        return ketQua;
    }

    public static MaTran Nhan(MaTran a, MaTran b)
    {
        if (a.SoCot != b.SoDong)
        {
            Console.WriteLine("Lỗi: Số cột ma trận A phải bằng số dòng ma trận B.");
            return null;
        }

        MaTran ketQua = new MaTran(a.SoDong, b.SoCot);
        for (int i = 0; i < a.SoDong; i++)
        {
            for (int j = 0; j < b.SoCot; j++)
            {
                for (int k = 0; k < a.SoCot; k++)
                {
                    ketQua.PhanTu[i, j] += a.PhanTu[i, k] * b.PhanTu[k, j];
                }
            }
        }
        return ketQua;
    }

    public static MaTran Chia(MaTran a, MaTran b)
    {
        Console.WriteLine("Phép chia ma trận phức tạp, chỉ demo trường hợp chia từng phần tử (nếu có thể).");
        if (a.SoDong != b.SoDong || a.SoCot != b.SoCot)
        {
            Console.WriteLine("Lỗi: Hai ma trận không cùng kích thước.");
            return null;
        }

        MaTran ketQua = new MaTran(a.SoDong, a.SoCot);
        for (int i = 0; i < a.SoDong; i++)
        {
            for (int j = 0; j < a.SoCot; j++)
            {
                if (b.PhanTu[i, j] != 0)
                {
                    ketQua.PhanTu[i, j] = a.PhanTu[i, j] / b.PhanTu[i, j];
                }
                else
                {
                    ketQua.PhanTu[i, j] = 0; // Xử lý chia cho 0
                }
            }
        }
        return ketQua;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        MaTran a = new MaTran();
        MaTran b = new MaTran();

        Console.WriteLine("Nhập ma trận A:");
        a.NhapMaTran();

        Console.WriteLine("Nhập ma trận B:");
        b.NhapMaTran();

        int luaChon;
        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("a. Tính tổng hai ma trận");
            Console.WriteLine("b. Tính tích hai ma trận");
            Console.WriteLine("c. Tính hiệu hai ma trận");
            Console.WriteLine("d. Tính thương hai ma trận (chia từng phần tử)");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn: ");
            luaChon = Console.ReadLine()[0];

            switch (luaChon)
            {
                case 'a':
                    MaTran.Cong(a, b)?.HienThiMaTran();
                    break;
                case 'b':
                    MaTran.Nhan(a, b)?.HienThiMaTran();
                    break;
                case 'c':
                    MaTran.Tru(a, b)?.HienThiMaTran();
                    break;
                case 'd':
                    MaTran.Chia(a, b)?.HienThiMaTran();
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
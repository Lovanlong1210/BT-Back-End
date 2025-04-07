using System;
using System.Text.RegularExpressions;

public class VanBan
{
    public string Chuoi { get; set; }

    public VanBan()
    {
        Chuoi = "";
    }

    public VanBan(string st)
    {
        Chuoi = st;
    }

    public int DemSoTu()
    {
        if (string.IsNullOrEmpty(Chuoi))
        {
            return 0;
        }
        string[] cacTu = Regex.Split(Chuoi.Trim(), @"\s+");
        return cacTu.Length;
    }

    public int DemKyTuH()
    {
        if (string.IsNullOrEmpty(Chuoi))
        {
            return 0;
        }
        int dem = 0;
        foreach (char c in Chuoi.ToLower())
        {
            if (c == 'h')
            {
                dem++;
            }
        }
        return dem;
    }

    public string ChuanHoa()
    {
        if (string.IsNullOrEmpty(Chuoi))
        {
            return "";
        }
        string chuoiChuanHoa = Regex.Replace(Chuoi.Trim(), @"\s+", " ");
        return chuoiChuanHoa;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Nhập chuỗi văn bản: ");
        string chuoi = Console.ReadLine();
        VanBan vanBan = new VanBan(chuoi);

        int luaChon;
        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Đếm số từ");
            Console.WriteLine("2. Đếm số ký tự H");
            Console.WriteLine("3. Chuẩn hóa chuỗi");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn: ");
            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    Console.WriteLine($"Số từ trong chuỗi: {vanBan.DemSoTu()}");
                    break;
                case 2:
                    Console.WriteLine($"Số ký tự H trong chuỗi: {vanBan.DemKyTuH()}");
                    break;
                case 3:
                    Console.WriteLine($"Chuỗi chuẩn hóa: {vanBan.ChuanHoa()}");
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
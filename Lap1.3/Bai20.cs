using System;
using System.Collections.Generic;

public class HoiVien
{
    public string HoTen { get; set; }
    public string DiaChi { get; set; }
    public string HoTenVo { get; set; }
    public DateTime NgayCuoi { get; set; }
    public string HoTenNguoiYeu { get; set; }
    public string SoDienThoaiNguoiYeu { get; set; }

    public void NhapThongTin()
    {
        Console.Write("Họ tên: ");
        HoTen = Console.ReadLine();
        Console.Write("Địa chỉ: ");
        DiaChi = Console.ReadLine();
        Console.Write("Họ tên vợ (nếu có): ");
        HoTenVo = Console.ReadLine();
        if (!string.IsNullOrEmpty(HoTenVo))
        {
            Console.Write("Ngày cưới (yyyy-MM-dd): ");
            NgayCuoi = DateTime.Parse(Console.ReadLine());
        }
        Console.Write("Họ tên người yêu (nếu có): ");
        HoTenNguoiYeu = Console.ReadLine();
        if (!string.IsNullOrEmpty(HoTenNguoiYeu))
        {
            Console.Write("Số điện thoại người yêu:
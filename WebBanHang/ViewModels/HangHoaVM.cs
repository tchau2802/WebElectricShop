namespace WebBanHang.ViewModels
{
    public class HangHoaVM
    {
        public int MaHang {  get; set; }
        public string TenHang { get; set;}
        public string HinhHang { get; set;}
        public double DonGiaHang { get; set;}
        public string MoTaNganHang { get;set; }
        public string TenLoaiHang { get; set; }
    }
    public class ChiTietHangHoaVM
    {
        public int MaHang { get; set; }
        public string TenHang { get; set; }
        public string HinhHang { get; set; }
        public double DonGiaHang { get; set; }
        public string MoTaNganHang { get; set; }
        public string TenLoaiHang { get; set; }
        public string ChiTietHang { get; set; }
        public int DiemDanhGiaHang { get; set; }
        public int SoLuongTon { get; set; }
    }
}

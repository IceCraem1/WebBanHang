using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Models.Model
{
    public class tblNguoiDung
    {
        [Key]
        public int iIDNguoiDung { get; set; }
        public string sTenNguoiDung { get; set; }
        public string sTenDangNhap { get; set; }
        public string sMatKhau { get; set; }
        public string sSoDienThoai { get; set; }
        public string sDiaChi { get; set; }
    }
}

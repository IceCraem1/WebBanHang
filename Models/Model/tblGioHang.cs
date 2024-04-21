using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Models.Model
{
    public class tblGioHang
    {
        [Key]
        public int iIDNguoiDung { get; set; }
        public int iSoLuongHang { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Models.Model
{
    public class tblPhanQuyen
    {
        [Key]
        public int iIDNguoiDung { get; set; }
        public string sTenNguoiDung { get; set; }
        public int iCapDo { get; set; }
        public string sChucVu { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Models.Model
{
    public class tblTrangThaiHang
    {
        [Key]
        public int iIDNguoiDung { get; set; }
        public int iIDHang { get; set; }
        public string sThanhToan { get; set; }
        public int idMaGiam { get; set; }
    }
}

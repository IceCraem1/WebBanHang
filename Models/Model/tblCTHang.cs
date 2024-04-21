using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Models.Model
{
    public class tblCTHang
    {
        [Key]
        public int iIDHang { get; set; }
        public string sTenHang { get; set; }
        public float fGiaTien { get; set; }
        public int iSoLuongCon { get; set; }
    }
}

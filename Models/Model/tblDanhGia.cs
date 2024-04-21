using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanHang.Models.Model
{
    public class tblDanhGia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int iIDDanhGia { get; set; }
        public int iSoSao { get; set; }
        public string sDanhGia { get; set; }
        public DateTime dThoiGian { get; set; }
        public int iIDHang { get; set; }
        public int iIDNguoiDung { get; set; }
    }
}

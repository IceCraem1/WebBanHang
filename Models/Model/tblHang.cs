using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanHang.Models.Model
{
    public class tblHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int iIDHang { get; set; }
        public int iIDLoai { get; set; }
        public int iIDNguoiDung { get; set; }
    }
}

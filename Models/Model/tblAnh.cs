using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Models.Model
{
    public class tblAnh
    {
        [Key]
        public int iIDHang { get; set; }
        public int iIDAnh { get; set; }
    }
}

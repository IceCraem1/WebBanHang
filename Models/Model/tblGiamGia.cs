using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanHang.Models.Model
{
    public class tblGiamGia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int iIDGiamGia { get; set; }
        public float fGiaGiam { get; set; }
        public int iIDHang { get; set; }
    }
}

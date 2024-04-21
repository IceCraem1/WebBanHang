
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanHang.Models.Model
{
    public class tblLoaiHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int iIDLoai { get; set; }
        public string sHang { get; set; }
        public string sDang { get; set; }
    }
}

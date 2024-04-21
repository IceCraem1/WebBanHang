using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebBanHang.Models.Model;

namespace WebBanHang.Data
{
    public class DBFile : DbContext
    {
        public DBFile(DbContextOptions<DBFile> options) : base(options)
        {
        }
        public DbSet<tblAnh> tblAnh { get; set; }
        public DbSet<tblHang> tblHang { get; set; }
        public DbSet<tblCTHang> tblCTHang { get; set; }
        public DbSet<tblDanhGia> tblDanhGia { get; set; }
        public DbSet<tblGiamGia> tblGiamGia { get; set; }
        public DbSet<tblGioHang> tblGioHang { get; set; }
        public DbSet<tblLoaiHang> tblLoaiHang { get; set; }
        public DbSet<tblNguoiDung> tblNguoiDung { get; set; }
        public DbSet<tblPhanQuyen> tblPhanQuyen { get; set; }
        public DbSet<tblTrangThaiHang> tblTrangThaiHang { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("ConnectionString");
            }
        }
    }
}

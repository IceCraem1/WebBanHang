using WebBanHang.Models;
using WebBanHang.Models.Model;
namespace WebBanHang.Models.Reponsitory
{
    public class LoaiHangReponsitory
    {
        private List<tblLoaiHang> loaiHangList = new List<tblLoaiHang>();
        public tblLoaiHang gettblLoaiHang(int iIDLoai)
        {
            return loaiHangList.FirstOrDefault(a => a.iIDLoai == iIDLoai);
        }
        public List<tblLoaiHang> GetloaiHangList(int pageNumber = 1)
        {
            int pageSize = 10;
            int skip = pageSize * (pageNumber - 1);
            //SessionExtensions.SetObject("Authors",authors);
            if (loaiHangList.Count < pageSize)
                pageSize = loaiHangList.Count;
            return loaiHangList
            .Skip(skip)
            .Take(pageSize).ToList();
        }
        public bool savetblLoaiHang(tblLoaiHang loaiHang)
        {
            var result = loaiHangList.Where(a => a.iIDLoai == loaiHang.iIDLoai);
            if (result != null)
            {
                if (result.Count() == 0)
                {
                    loaiHangList.Add(loaiHang);
                    return true;
                }
            }
            return false;
        }
    }
}

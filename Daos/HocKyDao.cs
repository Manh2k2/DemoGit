using QuanLyRenLuyen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyRenLuyen.Daos
{
    public class HocKyDao
    {
        DbConTextQl myDb = new DbConTextQl();

        public List<HocKy> getHocKyByIdUser(int idUser)
        {
            // Lấy danh sách IdHocKy từ bảng ChamDiemRenLuyen dựa trên IdSinhVien
            var listHocKy = myDb.ChamDiemRenLuyens.Where(x => x.IdSinhVien == idUser).Select(x => x.IdHocKy).ToList();
            // Lấy danh sách các HocKy từ bảng HocKies mà không có trong danh sách listHocKy
            var list = myDb.HocKies.Where(x => !listHocKy.Contains(x.IdHocKy)).ToList();
            return list;
        }

    }
}
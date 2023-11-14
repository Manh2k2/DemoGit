using QuanLyRenLuyen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyRenLuyen.Daos
{
    public class CoVanDao
    {
        DbConTextQl myDb = new DbConTextQl();
        public bool checkLogin(string macvht,string matkhau)
        {
            // truy vấn cơ sở dữ liệu và kiểm tra xem có bản ghi nào khớp với mã và mật khẩu không
            var cvht = myDb.CoVanHocTaps.FirstOrDefault(x => x.MaCVHT == macvht && x.MatKhau == matkhau);
            if(cvht != null) // Nếu cvht không null, tức là có bản ghi khớp, trả về true
            {
                return true;
            }
            return false;     // Ngược lại, trả về false
        }
        public CoVanHocTap getCVByMaCV(string macv)
        {
            return myDb.CoVanHocTaps.FirstOrDefault(x => x.MaCVHT == macv); //truy vấn cơ sở dữ liệu và lấy phần tử đầu tiên khớp với mã cố vấn
        }
    }
}
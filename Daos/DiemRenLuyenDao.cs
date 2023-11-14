using QuanLyRenLuyen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyRenLuyen.Daos
{
    public class DiemRenLuyenDao
    {
        DbConTextQl myDb = new DbConTextQl();
        //truy vấn tất cả các bản ghi từ bảng DiemRenLuyen và chuyển chúng thành một danh sách
        public List<DiemRenLuyen> getAll()
        {
            return myDb.Set<DiemRenLuyen>().ToList(); 
        }
        //  truy vấn các bản ghi từ bảng DiemRenLuyen dựa trên khoảng giá trị của tổng điểm
        public List<DiemRenLuyen> getFilter(int from, int to)
        {
            return myDb.DiemRenLuyens.Where(x => x.TongDiem >= from && x.TongDiem <= to).ToList();
        }

        public void update(DiemRenLuyen diemRenLuyen)
        {
            var obj = myDb.DiemRenLuyens.FirstOrDefault(x => x.IdDiemRenLuyen == diemRenLuyen.IdDiemRenLuyen); // Tìm kiếm bản ghi điểm rèn luyện cần cập nhật dựa trên IdDiemRenLuyen
            obj.TongDiem = diemRenLuyen.TongDiem; // Cập nhật thông tin tổng điểm của bản ghi
            myDb.SaveChanges(); // Lưu các thay đổi vào cơ sở dữ liệu
        }
        public void delete(int id)
        {
            var obj = myDb.DiemRenLuyens.FirstOrDefault(x => x.IdDiemRenLuyen == id);  // Tìm kiếm bản ghi điểm rèn luyện cần xóa dựa trên IdDiemRenLuyen
            myDb.DiemRenLuyens.Remove(obj);  // Xóa bản ghi điểm rèn luyện
            var obj1 = myDb.ChamDiemRenLuyens.Where(x => x.IdSinhVien == obj.IdSinhVien && x.HocKy == obj.HocKy).ToList();// Tìm kiếm và xóa các bản ghi ChamDiemRenLuyen liên quan
            myDb.ChamDiemRenLuyens.RemoveRange(obj1);
            myDb.SaveChanges(); // Lưu các thay đổi vào cơ sở dữ liệu
        }

        public  void Add(List<ChamDiemRenLuyen> chamDiemRenLuyens)
        {
            foreach (var item in chamDiemRenLuyens)
            {
                myDb.ChamDiemRenLuyens.Add(item);   // Thêm từng đối tượng ChamDiemRenLuyen vào DbSet (tập hợp thực thể) myDb.ChamDiemRenLuyens
            }
            myDb.SaveChanges();// Lưu các thay đổi vào cơ sở dữ liệu
        }

        public void AddDiem(DiemRenLuyen diemRenLuyen)
        {
            myDb.DiemRenLuyens.Add(diemRenLuyen); // Thêm đối tượng DiemRenLuyen vào DbSet (tập hợp thực thể) myDb.DiemRenLuyens
            myDb.SaveChanges();// Lưu các thay đổi vào cơ sở dữ liệu
        }

        public int TongDiem(int idSinhvien , int hocKy)
        {
            int tong = 0;
            //  truy vấn các bản ghi từ bảng ChamDiemRenLuyen dựa trên IdHocKy và IdSinhVien
            // Sau đó, chọn trường Diem và tính tổng các giá trị
            tong = myDb.ChamDiemRenLuyens.Where(x => x.IdHocKy == hocKy && x.IdSinhVien == idSinhvien).Select(x => x.Diem).ToList().Sum();         
            return tong;
        }
        public List<ChamDiemRenLuyen> GetByHocKyAndId(int idHocKy, int idSinhVien)
        {
            //truy vấn các bản ghi từ bảng ChamDiemRenLuyen dựa trên IdHocKy và IdSinhVien
            return myDb.ChamDiemRenLuyens.Where(x => x.IdHocKy == idHocKy && x.IdSinhVien == idSinhVien).ToList();
        }
        public DiemRenLuyen GetDiem(int idHocKy, int idSinhVien)
        {
            //truy vấn các bản ghi từ bảng ChamDiemRenLuyen dựa trên IdHocKy và IdSinhVien
            return myDb.DiemRenLuyens.FirstOrDefault(x => x.IdHocKy == idHocKy && x.IdSinhVien == idSinhVien);
        }
    }
}
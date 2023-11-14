using QuanLyRenLuyen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyRenLuyen.Daos
{
    public class SinhVienDao
    {
        DbConTextQl myDb = new DbConTextQl();
        public bool checkLogin(string masv, string matkhau)
        {
            //  tìm kiếm sinh viên dựa trên MaSinhVien và MatKhau
            var cvht = myDb.SinhViens.FirstOrDefault(x => x.MaSinhVien == masv && x.MatKhau == matkhau);
            if (cvht != null) // Kiểm tra xem sinh viên có tồn tại không
            {
                return true;
            }
            return false;
        }
        public SinhVien getSVByMaSV(string masv)
        {
            return myDb.SinhViens.FirstOrDefault(x => x.MaSinhVien == masv); //tìm kiếm sinh viên dựa trên MaSinhVien
        }
        public SinhVien getSVById(int id)
        {
            return myDb.SinhViens.FirstOrDefault(x => x.IdSinhVien == id); //tìm kiếm sinh viên dựa trên IdSinhVien
        }

        public List<SinhVien> getList()
        {
            return myDb.SinhViens.OrderByDescending(x =>x.IdSinhVien).ToList(); //lấy danh sách sinh viên từ bảng SinhViens sắp xếp theo IdSinhVien giảm dần
        }

        public void add(SinhVien sinhVien)
        {
            myDb.SinhViens.Add(sinhVien); // Thêm đối tượng SinhVien vào DbSet (tập hợp thực thể) myDb.SinhViens
            myDb.SaveChanges();   // Lưu các thay đổi vào cơ sở dữ liệu
        }

        public bool checkExistMaSV(string masv)
        {
            var obj = getSVByMaSV(masv); // Gọi phương thức getSVByMaSV để lấy thông tin của sinh viên dựa trên MaSinhVien
            if (obj != null)  // Kiểm tra xem sinh viên có tồn tại không
            {
                return true; 
            }
            return false;
        }

        public bool checkDelete(int id)
        {
            // lọc các bản ghi từ bảng ChamDiemRenLuyens dựa trên IdSinhVien
            var obj = myDb.ChamDiemRenLuyens.Where(x => x.IdSinhVien == id).ToList();
            if (obj.Count > 0) // Kiểm tra xem có bản ghi nào hay không
            {
                return true; 
            }
            return false;
        }

        public void delete(int id)
        {
            var obj = getSVById(id); // Gọi phương thức getSVById để lấy thông tin của sinh viên dựa trên IdSinhVien
            myDb.SinhViens.Remove(obj);// Xóa sinh viên từ DbSet (tập hợp thực thể) myDb.SinhViens
            myDb.SaveChanges();  // Lưu các thay đổi vào cơ sở dữ liệu
        }

        public void update(SinhVien sinhVien)
        {
            // Gọi phương thức getSVById để lấy thông tin của sinh viên dựa trên IdSinhVien
            var obj = getSVById(sinhVien.IdSinhVien);
            // Cập nhật thông tin của sinh viên từ đối tượng sinhVien được truyền vào
            obj.HoTen = sinhVien.HoTen;
            obj.NgaySinh = sinhVien.NgaySinh;
            obj.SoDienThoai = sinhVien.SoDienThoai;
            obj.DiaChi = sinhVien.DiaChi;
            obj.IdLopTaiChinh = sinhVien.IdLopTaiChinh;
            myDb.SaveChanges();
        }
        
        public List<LopTaiChinh> getLop()
        {
            return myDb.LopTaiChinhs.ToList();//lấy danh sách các LopTaiChinh từ bảng LopTaiChinhs
        }
    }
}
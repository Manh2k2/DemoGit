using QuanLyRenLuyen.Daos;
using QuanLyRenLuyen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyRenLuyen.Controllers
{
    public class SinhVienController : Controller
    {
        SinhVienDao sinhVienDao = new SinhVienDao();
        DiemRenLuyenDao diemRenLuyenDao = new DiemRenLuyenDao();
        HocKyDao hocKyDao = new HocKyDao();
        // GET: SinhVien
        public ActionResult Index(string msg)
        {
            var listStudent = sinhVienDao.getList();// Lấy danh sách sinh viên từ cơ sở dữ liệu
            ViewBag.MSG = msg;// Đặt giá trị của biến msg vào ViewBag.MSG để hiển thị trên view
            ViewBag.Lop = sinhVienDao.getLop();// Lấy danh sách các lớp từ cơ sở dữ liệu
            return View(listStudent);// Trả về view để hiển thị danh sách sinh viên
        }

        public ActionResult ChamDiem(string mess)
        {
            var sinhvien = (SinhVien)Session["sv"]; // Lấy thông tin sinh viên từ Session
            ViewBag.mess = mess; // Đặt thông báo (nếu có) để hiển thị trên view
            ViewBag.listHocKy = hocKyDao.getHocKyByIdUser(sinhvien.IdSinhVien);// Lấy danh sách các học kỳ của sinh viên từ cơ sở dữ liệu
            return View();// Trả về view để hiển thị trang chấm điểm
        }

        [HttpPost]
        public ActionResult ChamDiem(ChamDiemModel chamDiem)
        {
            //xử lý ghi chú mục 
            ChamDiemRenLuyen obj1Three = null;
            // Điều kiện kiểm tra nếu one1 trong chamDiem có giá trị là 15 hoặc 12 hoặc hocky có giá trị là 1. Nếu điều kiện này đúng, sẽ thực hiện đoạn mã trong khối if.
            if (chamDiem.one1.Equals(15) || chamDiem.one1.Equals(12) || chamDiem.hocky.Equals(1))
            {
                //Nếu điều kiện trong if là đúng, sẽ tạo một đối tượng ChamDiemRenLuyen mới với các giá trị cứng nhất định. Trong trường hợp này, giá trị của one3 là 5, và các giá trị khác được chọn dựa trên điều kiện của if.
                obj1Three = new ChamDiemRenLuyen(chamDiem.hocky, 5, Constants.Constants.ONE_THREE, chamDiem.IdSinhVien, 0);
            }
            else //Nếu điều kiện trong if là sai, sẽ thực hiện đoạn mã trong khối else.
            {
                //Trong khối else, tạo một đối tượng ChamDiemRenLuyen mới, nhưng giá trị của one3 được lấy từ chamDiem và chuyển đổi từ kiểu chuỗi sang kiểu số nguyên (Int32.Parse).
                obj1Three = new ChamDiemRenLuyen(chamDiem.hocky, Int32.Parse(chamDiem.one3), Constants.Constants.ONE_THREE, chamDiem.IdSinhVien, 0);
            }
            List<ChamDiemRenLuyen> chamDiemRenLuyens = new List<ChamDiemRenLuyen>()
            {
                new ChamDiemRenLuyen(chamDiem.hocky,Int32.Parse(chamDiem.one1),Constants.Constants.ONE_ONE,chamDiem.IdSinhVien, 0),
                new ChamDiemRenLuyen(chamDiem.hocky, Int32.Parse(chamDiem.one2a), Constants.Constants.ONE_TW0_A, chamDiem.IdSinhVien, 0),
                new ChamDiemRenLuyen(chamDiem.hocky, Int32.Parse(chamDiem.one2b), Constants.Constants.ONE_TW0_B, chamDiem.IdSinhVien, 0),
                new ChamDiemRenLuyen(chamDiem.hocky, Int32.Parse(chamDiem.one2c), Constants.Constants.ONE_TW0_C, chamDiem.IdSinhVien, 0),
                obj1Three,
                new ChamDiemRenLuyen(chamDiem.hocky, Int32.Parse(chamDiem.two1), Constants.Constants.TWO_ONE, chamDiem.IdSinhVien, 0),
                new ChamDiemRenLuyen(chamDiem.hocky, Int32.Parse(chamDiem.two2), Constants.Constants.TWO_TWO, chamDiem.IdSinhVien, 0),
                new ChamDiemRenLuyen(chamDiem.hocky, Int32.Parse(chamDiem.two3), Constants.Constants.TWO_THREE, chamDiem.IdSinhVien, 0),
                new ChamDiemRenLuyen(chamDiem.hocky, Int32.Parse(chamDiem.two4), Constants.Constants.TWO_FOUR, chamDiem.IdSinhVien, 0),
                new ChamDiemRenLuyen(chamDiem.hocky, Int32.Parse(chamDiem.two5), Constants.Constants.TWO_FIVE, chamDiem.IdSinhVien, 0),
                new ChamDiemRenLuyen(chamDiem.hocky, Int32.Parse(chamDiem.two6), Constants.Constants.TWO_SIX, chamDiem.IdSinhVien, 0),
                new ChamDiemRenLuyen(chamDiem.hocky, Int32.Parse(chamDiem.two7), Constants.Constants.TWO_SEVEN, chamDiem.IdSinhVien, 0),
                new ChamDiemRenLuyen(chamDiem.hocky, Int32.Parse(chamDiem.three1), Constants.Constants.THREE_ONE, chamDiem.IdSinhVien, 0),
                new ChamDiemRenLuyen(chamDiem.hocky, Int32.Parse(chamDiem.three2), Constants.Constants.THREE_TWO, chamDiem.IdSinhVien, 0),
                new ChamDiemRenLuyen(chamDiem.hocky, Int32.Parse(chamDiem.four), Constants.Constants.FOUR, chamDiem.IdSinhVien, 0),
                new ChamDiemRenLuyen(chamDiem.hocky, Int32.Parse(chamDiem.five), Constants.Constants.FIVE, chamDiem.IdSinhVien, 0),
                new ChamDiemRenLuyen(chamDiem.hocky, Int32.Parse(chamDiem.six), Constants.Constants.SIX, chamDiem.IdSinhVien, 0)
            };
            diemRenLuyenDao.Add(chamDiemRenLuyens);
            //tính tổng điểm rèn luyện
            int tongDiem = diemRenLuyenDao.TongDiem(chamDiem.IdSinhVien,chamDiem.hocky);
            DiemRenLuyen diemRenLuyen = new DiemRenLuyen(chamDiem.hocky, tongDiem, chamDiem.IdSinhVien, 0);
            diemRenLuyenDao.AddDiem(diemRenLuyen);
            return RedirectToAction("ChamDiem","SinhVien", new {mess = "1"});
        }

        public ActionResult Add(SinhVien sinhVien)
        {
            sinhVien.TrangThai = 1;// Đặt trạng thái của sinh viên thành 1
            bool checkExist = sinhVienDao.checkExistMaSV(sinhVien.MaSinhVien);// Kiểm tra sự tồn tại của Mã Sinh Viên
            // Nếu Mã Sinh Viên đã tồn tại, chuyển hướng đến trang Index với mã thông báo "2"
            if (checkExist)
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
            else
            {
                // Nếu Mã Sinh Viên chưa tồn tại, thêm sinh viên và chuyển hướng đến trang Index với mã thông báo "1"
                sinhVienDao.add(sinhVien);
                return RedirectToAction("Index", new { msg = "1" });
            }

        }

        public ActionResult Update(SinhVien sinhVien)
        {
            // Gọi phương thức update từ đối tượng sinhVienDao để cập nhật thông tin sinh viên
            sinhVienDao.update(sinhVien);
            // Chuyển hướng đến action "Index" của cùng controller với thông báo "1"
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Delete(int id)
        {
            // Kiểm tra xem việc xóa có thể thực hiện được hay không
            bool check = sinhVienDao.checkDelete(id);
            // Nếu không thể xóa, chuyển hướng đến action "Index" của cùng controller với thông báo "3"
            if (check)
            {
                return RedirectToAction("Index", new { msg = "3" });
            }
            
            else
            {
                // Nếu có thể xóa, gọi phương thức delete từ đối tượng sinhVienDao
                sinhVienDao.delete(id);
                // Chuyển hướng đến action "Index" của cùng controller với thông báo "1"
                return RedirectToAction("Index", new { msg = "1" });
            }
        }
        // Đây là một action trong một controller của ASP.NET MVC, có tên là "XemDiem". Nhận hai tham số là idHocKy và idSinhVien.
        public ActionResult XemDiem(int idHocKy, int idSinhVien)
        {
            // Gọi phương thức GetByHocKyAndId từ đối tượng diemRenLuyenDao để lấy danh sách điểm rèn luyện dựa trên học kỳ và ID sinh viên
            var list = diemRenLuyenDao.GetByHocKyAndId(idHocKy, idSinhVien);
            // Gọi phương thức GetDiem từ đối tượng diemRenLuyenDao để lấy thông tin điểm rèn luyện dựa trên học kỳ và ID sinh viên
            var obj = diemRenLuyenDao.GetDiem(idHocKy, idSinhVien);
            // Đặt thông tin điểm rèn luyện vào ViewBag để truyền dữ liệu sang view
            ViewBag.Diem = obj;
            // Đặt giá trị IdHocKy vào ViewBag để truyền dữ liệu sang view
            ViewBag.IdHocKy = idHocKy;
            // Trả về view và chuyển kèm theo danh sách điểm rèn luyện
            return View(list);
        }

    }
}
using QuanLyRenLuyen.Daos;
using QuanLyRenLuyen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyRenLuyen.Controllers
{
    public class DiemRenLuyenController : Controller  
    {
        DiemRenLuyenDao diemRenLuyenDao = new DiemRenLuyenDao();
        //Sử dụng đối tượng diemRenLuyenDao để thao tác với dữ liệu

        // GET: DiemRenLuyen
        public ActionResult Index(string msg)//tham số kiểu string có tên là "msg"
        {
            // Gán giá trị msg vào ViewBag để truyền thông điệp từ controller đến view
            ViewBag.MSG = msg;
            // Gọi phương thức getAll() từ đối tượng diemRenLuyenDao để lấy danh sách điểm rèn luyện
            var list = diemRenLuyenDao.getAll();
            // Trả về view "Index" và truyền danh sách điểm rèn luyện đến view
            return View(list);
        }
        public ActionResult Update(DiemRenLuyen diemRenLuyen)
        {
            diemRenLuyenDao.update(diemRenLuyen);       // Gọi phương thức update() từ đối tượng diemRenLuyenDao để cập nhật thông tin điểm rèn luyện
            return RedirectToAction("Index", new { msg = "1" });   // Sau khi cập nhật, chuyển hướng đến action "Index" và truyền một thông điệp (msg) có giá trị "1"
        }

        public ActionResult Delete(int id)
        {
            diemRenLuyenDao.delete(id); // Gọi phương thức delete() từ đối tượng diemRenLuyenDao để xóa bản ghi với ID tương ứng
            return RedirectToAction("Index", new { msg = "1" });
        }
        public ActionResult XepLoai(FormCollection form) //Đây là một phương thức hành động có tên là "XepLoai" và nhận một tham số kiểu FormCollection chứa dữ liệu được gửi từ form trong request HTTP.
        {
            var from =form["from"];  // Lấy giá trị từ các trường "from" và "to" từ FormCollection
            var to = form["to"];
            if ( from != null || to != null)
            {

                // Nếu có giá trị từ và to, chuyển chúng thành kiểu số nguyên

                var tu = Int32.Parse(from);
                var den = Int32.Parse(to);
                ViewBag.List = diemRenLuyenDao.getFilter(tu, den); // Gọi phương thức getFilter() từ đối tượng diemRenLuyenDao để lấy danh sách điểm rèn luyện theo khoảng giá trị
            }
            else
            {
                ViewBag.List = diemRenLuyenDao.getAll(); // Nếu không có giá trị từ và to, lấy toàn bộ danh sách điểm rèn luyện
            }
            return View();  // Trả về view để hiển thị danh sách
        }

      
    }
}
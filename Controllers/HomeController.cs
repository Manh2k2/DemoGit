using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyRenLuyen.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = Session["CVHT"]; // Lấy thông tin người dùng từ Session, giả sử thông tin này có tên là "CVHT"
            if (user == null) // Kiểm tra xem người dùng đã đăng nhập hay chưa
            {
                return RedirectToAction("Login", "Authentication"); // Nếu không có thông tin người dùng trong Session, chuyển hướng đến trang đăng nhập
            }
            else
            {
                return View(); // Nếu có thông tin người dùng, hiển thị trang chính (Index)
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page."; // Gán một thông điệp cho ViewBag, có thể được sử dụng trong view

            return View();  // Trả về view để hiển thị trang mô tả
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
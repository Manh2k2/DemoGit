using QuanLyRenLuyen.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyRenLuyen.Controllers
{
    public class AuthenticationController : Controller
    {
        SinhVienDao sinhVienDao = new SinhVienDao();
        CoVanDao coVanDao = new CoVanDao();
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection form) //hiển thị tài khoản người dùng
        {
            var role = form["role"];
            var ma = form["ma"];
            var mk = form["mk"];
            if(role == "1") // Kiểm tra xem vai trò của người dùng có phải là "1" hay không
            {
                bool check = coVanDao.checkLogin(ma, mk);//Gọi phương thức checkLogin từ đối tượng coVanDao để kiểm tra thông tin đăng nhập
                if (check) //kiểm tra
                {
                    var userInformation = coVanDao.getCVByMaCV(ma);// Gọi phương thức getCVByMaCV từ coVanDao để lấy thông tin của cố vấn dựa trên mã cố vấn(ma). Kết quả được lưu trong biến userInformation.
                    Session.Add("CVHT", userInformation); //Lưu thông tin của cố vấn vào session với key là "CVHT".
                    return RedirectToAction("Index", "Home");//Chuyển hướng đến action "Index" trong controller "Home".
                }
                ViewBag.mess = "Thông tin không chính xác"; //Nếu thông tin đăng nhập không chính xác, đặt thông báo trong ViewBag để hiển thị thông báo trên view.
                return View("Login"); //Nếu đăng nhập không thành công, hiển thị lại trang đăng nhập.
            }
            else //Nếu vai trò không phải là "1"
            {
                bool check = sinhVienDao.checkLogin(ma, mk);
                if (check)
                {
                    var userInformation = sinhVienDao.getSVByMaSV(ma);
                    Session.Add("SV", userInformation);//: Lưu thông tin của sinh viên vào session với key là "SV".
                    return RedirectToAction("ChamDiem", "SinhVien");//Chuyển hướng đến action "ChamDiem" trong controller "SinhVien"
                }
                ViewBag.mess = "Thông tin không chính xác";
                return View("Login");
            }
        }
        public ActionResult SVLogout()// Đây là một phương thức (action) trong controller, được gọi khi người dùng muốn đăng xuất.
        {
            Session.Remove("SV");// Xóa thông tin của sinh viên khỏi Session khi họ đăng xuất
            return Redirect("/");// Chuyển hướng đến trang chính (ở đây là trang "/")
        }
        public ActionResult Logout()//Phương thức này được gọi khi người dùng cố vấn học tập muốn đăng xuất.
        {
            Session.Remove("CVHT");//// Xóa thông tin của cố vấn học tập khỏi Session khi họ đăng xuất
            return Redirect("/");
        }
    }
}
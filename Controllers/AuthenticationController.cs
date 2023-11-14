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
            if(role == "1")
            {
                bool check = coVanDao.checkLogin(ma, mk);
                if (check)
                {
                    var userInformation = coVanDao.getCVByMaCV(ma);
                    Session.Add("CVHT", userInformation);
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.mess = "Thông tin không chính xác";
                return View("Login");
            }
            else
            {
                bool check = sinhVienDao.checkLogin(ma, mk);
                if (check)
                {
                    var userInformation = sinhVienDao.getSVByMaSV(ma);
                    Session.Add("SV", userInformation);
                    return RedirectToAction("ChamDiem", "SinhVien");
                }
                ViewBag.mess = "Thông tin không chính xác";
                return View("Login");
            }
        }
        public ActionResult SVLogout()
        {
            Session.Remove("SV");
            return Redirect("/");
        }
        public ActionResult Logout()
        {
            Session.Remove("CVHT");
            return Redirect("/");
        }
    }
}
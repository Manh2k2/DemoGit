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
            var listStudent = sinhVienDao.getList();
            ViewBag.MSG = msg;
            ViewBag.Lop = sinhVienDao.getLop();
            return View(listStudent);
        }

        public ActionResult ChamDiem(string mess)
        {
            var sinhvien = (SinhVien)Session["sv"];
            ViewBag.mess = mess;
            ViewBag.listHocKy = hocKyDao.getHocKyByIdUser(sinhvien.IdSinhVien);
            return View();
        }

        [HttpPost]
        public ActionResult ChamDiem(ChamDiemModel chamDiem)
        {
            //xử lý ghi chú mục 1.3
            ChamDiemRenLuyen obj1Three = null;
            if (chamDiem.one1.Equals(15) || chamDiem.one1.Equals(12) || chamDiem.hocky.Equals(1))
            {
                obj1Three = new ChamDiemRenLuyen(chamDiem.hocky, 5, Constants.Constants.ONE_THREE, chamDiem.IdSinhVien, 0);
            }
            else
            {
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
            sinhVien.TrangThai = 1;
            bool checkExist = sinhVienDao.checkExistMaSV(sinhVien.MaSinhVien);
            if (checkExist)
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
            else
            {
                sinhVienDao.add(sinhVien);
                return RedirectToAction("Index", new { msg = "1" });
            }

        }

        public ActionResult Update(SinhVien sinhVien)
        {
            sinhVienDao.update(sinhVien);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Delete(int id)
        {
            bool check = sinhVienDao.checkDelete(id);
            if (check)
            {
                return RedirectToAction("Index", new { msg = "3" });
            }
            else
            {
                sinhVienDao.delete(id);
                return RedirectToAction("Index", new { msg = "1" });
            }
        }

        public ActionResult XemDiem(int idHocKy, int idSinhVien)
        {
            var list = diemRenLuyenDao.GetByHocKyAndId(idHocKy, idSinhVien);
            var obj = diemRenLuyenDao.GetDiem(idHocKy, idSinhVien);
            ViewBag.Diem = obj;
            ViewBag.IdHocKy = idHocKy;
            return View(list);
        }

    }
}
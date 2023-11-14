using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyRenLuyen.Models
{
    public class ChamDiemRenLuyen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdChamDiemRenLuyen{ get; set; }

        public int IdHocKy { get; set; }

        public int Diem { get; set; }

        [Required]
        public string TieuChi { get; set; }

        public int IdSinhVien { get; set; }

        public int TrangThai { get; set; }

        public virtual SinhVien SinhVien { get; set; }
        public virtual HocKy HocKy { get; set; }

        public ChamDiemRenLuyen(int hocky, int diem,string tieuchi,int idSinhVien,int trangThai)
        {
            IdHocKy = hocky;
            Diem = diem;
            TieuChi = tieuchi;
            IdSinhVien = idSinhVien;
            TrangThai = trangThai;
        }
        public ChamDiemRenLuyen()
        {

        }
    }
}
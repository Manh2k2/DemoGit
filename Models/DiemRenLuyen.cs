using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyRenLuyen.Models
{
    public class DiemRenLuyen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDiemRenLuyen { get; set; }

        public int IdHocKy { get; set; }

        public int TongDiem { get; set; }

        public int IdSinhVien { get; set; }

        public int TrangThai { get; set; }

        public virtual SinhVien SinhVien { get; set; }
        public virtual HocKy HocKy { get; set; }

        public DiemRenLuyen(int hocKy,int tongDiem, int idSinhVien, int trangThai)
        {
            IdHocKy = hocKy;
            TongDiem = tongDiem;
            IdSinhVien = idSinhVien;
            TrangThai = trangThai;
        }
        public DiemRenLuyen()
        {

        }
    }
}
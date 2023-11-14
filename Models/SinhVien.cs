using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyRenLuyen.Models
{
    public class SinhVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSinhVien { get; set; }

        [StringLength(255)]
        [Required]
        public string MaSinhVien { get; set; }

        [StringLength(255)]
        public string MatKhau { get; set; }

        [StringLength(255)]
        public string HoTen { get; set; }

        public DateTime NgaySinh { get; set; }

        public int IdLopTaiChinh { get; set; }

        public virtual LopTaiChinh LopTaiChinh { get; set; }

        [StringLength(255)]
        public string SoDienThoai { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        public int TrangThai { get; set; }

        public virtual ICollection<DiemRenLuyen> DiemRenLuyens { get; set; }

        public virtual ICollection<ChamDiemRenLuyen> ChamDiemRenLuyens { get; set; }
    }
}
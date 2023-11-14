using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyRenLuyen.Models
{
    public class LopTaiChinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLopTaiChinh { get; set; }

        [StringLength(255)]
        [Required]
        public string TenLop { get; set; }

        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
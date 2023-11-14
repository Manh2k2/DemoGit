using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyRenLuyen.Models
{
    public class HocKy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHocKy { get; set; }

        public string Ten { get; set; }

        public ICollection<ChamDiemRenLuyen> ChamDiemRenLuyens { get; set; }
        public ICollection<DiemRenLuyen> DiemRenLuyens { get; set; }
    }
}
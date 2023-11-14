using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyRenLuyen.Models
{
    public class CoVanHocTap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCoVanHocTap { get; set; }

        [StringLength(255)]
        [Required]
        public string MaCVHT { get; set; }

        [StringLength(255)]
        [Required]
        public string MatKhau { get; set; }

        [StringLength(255)]
        [Required]
        public string HoTen { get; set; }
    }
}
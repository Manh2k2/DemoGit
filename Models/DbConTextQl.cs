using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace QuanLyRenLuyen.Models
{
    public class DbConTextQl : DbContext
    {
        public DbConTextQl() : base("DBConnectionString")
        {

        }

        public DbSet<CoVanHocTap> CoVanHocTaps { get; set; }
        public DbSet<DiemRenLuyen> DiemRenLuyens { get; set; }
        public DbSet<ChamDiemRenLuyen> ChamDiemRenLuyens { get; set; }
        public DbSet<LopTaiChinh> LopTaiChinhs { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<HocKy> HocKies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.PropertyName + ": " + x.ErrorMessage));
                throw new DbEntityValidationException(errorMessages);
            }
        }
    }
}
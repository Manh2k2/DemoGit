namespace QuanLyRenLuyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChamDiemRenLuyens",
                c => new
                    {
                        IdChamDiemRenLuyen = c.Int(nullable: false, identity: true),
                        HocKy = c.Int(nullable: false),
                        Diem = c.Int(nullable: false),
                        TieuChi = c.String(nullable: false),
                        IdSinhVien = c.Int(nullable: false),
                        TrangThai = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdChamDiemRenLuyen)
                .ForeignKey("dbo.SinhViens", t => t.IdSinhVien)
                .Index(t => t.IdSinhVien);
            
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        IdSinhVien = c.Int(nullable: false, identity: true),
                        MaSinhVien = c.String(nullable: false, maxLength: 255),
                        MatKhau = c.String(maxLength: 255),
                        HoTen = c.String(maxLength: 255),
                        NgaySinh = c.DateTime(nullable: false),
                        IdLoaiTaiChinh = c.Int(nullable: false),
                        SoDienThoai = c.String(maxLength: 255),
                        DiaChi = c.String(maxLength: 255),
                        TrangThai = c.Int(nullable: false),
                        LopTaiChinh_IdLopTaiChinh = c.Int(),
                    })
                .PrimaryKey(t => t.IdSinhVien)
                .ForeignKey("dbo.LopTaiChinhs", t => t.LopTaiChinh_IdLopTaiChinh)
                .Index(t => t.LopTaiChinh_IdLopTaiChinh);
            
            CreateTable(
                "dbo.DiemRenLuyens",
                c => new
                    {
                        IdDiemRenLuyen = c.Int(nullable: false, identity: true),
                        HocKy = c.Int(nullable: false),
                        TongDiem = c.Int(nullable: false),
                        IdSinhVien = c.Int(nullable: false),
                        TrangThai = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDiemRenLuyen)
                .ForeignKey("dbo.SinhViens", t => t.IdSinhVien)
                .Index(t => t.IdSinhVien);
            
            CreateTable(
                "dbo.LopTaiChinhs",
                c => new
                    {
                        IdLopTaiChinh = c.Int(nullable: false, identity: true),
                        TenLop = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.IdLopTaiChinh);
            
            CreateTable(
                "dbo.CoVanHocTaps",
                c => new
                    {
                        IdCoVanHocTap = c.Int(nullable: false, identity: true),
                        MaCVHT = c.String(nullable: false, maxLength: 255),
                        MatKhau = c.String(nullable: false, maxLength: 255),
                        HoTen = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.IdCoVanHocTap);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SinhViens", "LopTaiChinh_IdLopTaiChinh", "dbo.LopTaiChinhs");
            DropForeignKey("dbo.DiemRenLuyens", "IdSinhVien", "dbo.SinhViens");
            DropForeignKey("dbo.ChamDiemRenLuyens", "IdSinhVien", "dbo.SinhViens");
            DropIndex("dbo.DiemRenLuyens", new[] { "IdSinhVien" });
            DropIndex("dbo.SinhViens", new[] { "LopTaiChinh_IdLopTaiChinh" });
            DropIndex("dbo.ChamDiemRenLuyens", new[] { "IdSinhVien" });
            DropTable("dbo.CoVanHocTaps");
            DropTable("dbo.LopTaiChinhs");
            DropTable("dbo.DiemRenLuyens");
            DropTable("dbo.SinhViens");
            DropTable("dbo.ChamDiemRenLuyens");
        }
    }
}

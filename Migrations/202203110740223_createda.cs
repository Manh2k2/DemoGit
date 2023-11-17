namespace QuanLyRenLuyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createda : DbMigration
    {
        public override void Up()
        {
            //Tạo bảng có tên là "ChamDiemRenLuyens" với các cột được mô tả trong dấu ngoặc nhọn.
            CreateTable(
                "dbo.ChamDiemRenLuyens",
                c => new
                    {
                        IdChamDiemRenLuyen = c.Int(nullable: false, identity: true),//giá trị của nó sẽ tự động tăng khi một bản ghi mới được thêm vào.
                        HocKy = c.Int(nullable: false),//Cột HocKy là một cột kiểu số nguyên không cho phép giá trị null, đại diện cho học kỳ.
                        Diem = c.Int(nullable: false),//Cột Diem là một cột kiểu số nguyên không cho phép giá trị null, đại diện cho điểm.
                        TieuChi = c.String(nullable: false),//Cột TieuChi là một cột kiểu chuỗi không cho phép giá trị null, đại diện cho tiêu chí.
                        IdSinhVien = c.Int(nullable: false),//Cột IdSinhVien là một cột kiểu số nguyên không cho phép giá trị null, đại diện cho Id của SinhVien.
                        TrangThai = c.Int(nullable: false),//Cột TrangThai là một cột kiểu số nguyên không cho phép giá trị null, đại diện cho trạng thái.
                })
                .PrimaryKey(t => t.IdChamDiemRenLuyen)//Thiết lập cột IdChamDiemRenLuyen làm khóa chính cho bảng.
                .ForeignKey("dbo.SinhViens", t => t.IdSinhVien)//Thiết lập mối quan hệ ngoại tuyến giữa cột IdSinhVien trong bảng ChamDiemRenLuyens và cột Id trong bảng SinhViens.
                .Index(t => t.IdSinhVien);//Tạo một chỉ mục trên cột IdSinhVien, có thể giúp tối ưu hóa hiệu suất truy vấn liên quan đến cột này.

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

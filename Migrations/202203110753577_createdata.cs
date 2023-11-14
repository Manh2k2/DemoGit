namespace QuanLyRenLuyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdata : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SinhViens", new[] { "LopTaiChinh_IdLopTaiChinh" });
            RenameColumn(table: "dbo.SinhViens", name: "LopTaiChinh_IdLopTaiChinh", newName: "IdLopTaiChinh");
            AlterColumn("dbo.SinhViens", "IdLopTaiChinh", c => c.Int(nullable: false));
            CreateIndex("dbo.SinhViens", "IdLopTaiChinh");
            DropColumn("dbo.SinhViens", "IdLoaiTaiChinh");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SinhViens", "IdLoaiTaiChinh", c => c.Int(nullable: false));
            DropIndex("dbo.SinhViens", new[] { "IdLopTaiChinh" });
            AlterColumn("dbo.SinhViens", "IdLopTaiChinh", c => c.Int());
            RenameColumn(table: "dbo.SinhViens", name: "IdLopTaiChinh", newName: "LopTaiChinh_IdLopTaiChinh");
            CreateIndex("dbo.SinhViens", "LopTaiChinh_IdLopTaiChinh");
        }
    }
}

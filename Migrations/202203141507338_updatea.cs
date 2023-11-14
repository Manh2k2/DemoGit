namespace QuanLyRenLuyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatea : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HocKies",
                c => new
                    {
                        IdHocKy = c.Int(nullable: false, identity: true),
                        Ten = c.String(),
                    })
                .PrimaryKey(t => t.IdHocKy);
            
            AddColumn("dbo.ChamDiemRenLuyens", "IdHocKy", c => c.Int(nullable: false));
            AddColumn("dbo.DiemRenLuyens", "IdHocKy", c => c.Int(nullable: false));
            CreateIndex("dbo.ChamDiemRenLuyens", "IdHocKy");
            CreateIndex("dbo.DiemRenLuyens", "IdHocKy");
            AddForeignKey("dbo.ChamDiemRenLuyens", "IdHocKy", "dbo.HocKies", "IdHocKy");
            AddForeignKey("dbo.DiemRenLuyens", "IdHocKy", "dbo.HocKies", "IdHocKy");
            DropColumn("dbo.ChamDiemRenLuyens", "HocKy");
            DropColumn("dbo.DiemRenLuyens", "HocKy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DiemRenLuyens", "HocKy", c => c.Int(nullable: false));
            AddColumn("dbo.ChamDiemRenLuyens", "HocKy", c => c.Int(nullable: false));
            DropForeignKey("dbo.DiemRenLuyens", "IdHocKy", "dbo.HocKies");
            DropForeignKey("dbo.ChamDiemRenLuyens", "IdHocKy", "dbo.HocKies");
            DropIndex("dbo.DiemRenLuyens", new[] { "IdHocKy" });
            DropIndex("dbo.ChamDiemRenLuyens", new[] { "IdHocKy" });
            DropColumn("dbo.DiemRenLuyens", "IdHocKy");
            DropColumn("dbo.ChamDiemRenLuyens", "IdHocKy");
            DropTable("dbo.HocKies");
        }
    }
}

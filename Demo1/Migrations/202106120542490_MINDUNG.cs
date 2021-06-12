namespace ProductVertificationDesktopApp.csproj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MINDUNG : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestingConfigurations",
                c => new
                    {
                        TestID = c.Int(nullable: false, identity: true),
                        TestName = c.String(),
                        Sốlầnđóngnắpcàiđặt = c.Int(name: "Số lần đóng nắp cài đặt "),
                        Sốlầnđóngnắphiệntại = c.Int(name: "Số lần đóng nắp hiện tại "),
                        ThờigiangiữnắpđóngSP = c.Short(name: "Thời gian giữ nắp đóng :SP "),
                        SốlầngiữnắpmởSP = c.Short(name: "Số lần giữ nắp mở :SP"),
                    })
                .PrimaryKey(t => t.TestID);
            
            CreateTable(
                "dbo.TestSheets",
                c => new
                    {
                        TestSheetID = c.Int(nullable: false, identity: true),
                        NumberTesting = c.String(),
                        TimeSmoothClosingLid = c.String(),
                        StatusLidNotFall = c.String(),
                        StatusLidNotLeak = c.String(),
                        StatusLidResult = c.String(),
                        TimeSmoothClosingPlinth = c.String(),
                        StatusPlinthNotFall = c.String(),
                        StatusPlinthNotLeak = c.String(),
                        StatusPlinthResult = c.String(),
                        TotalMistake = c.String(),
                        Note = c.String(),
                        StaffCheck = c.String(),
                    })
                .PrimaryKey(t => t.TestSheetID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TestSheets");
            DropTable("dbo.TestingConfigurations");
        }
    }
}

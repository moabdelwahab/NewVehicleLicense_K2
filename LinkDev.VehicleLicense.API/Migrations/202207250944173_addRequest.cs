namespace LinkDev.VehicleLicense.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestNumber = c.String(),
                        CreatedBy = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        VehicleNumber = c.String(),
                        VehicleOwnerName = c.String(),
                        NationalId = c.String(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ProcessInsId = c.Int(nullable: false),
                        RequestStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Requests");
        }
    }
}

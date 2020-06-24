namespace Training38.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleV2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "Type");
        }
    }
}

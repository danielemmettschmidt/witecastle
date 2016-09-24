namespace dev_sbpcoveragetoolService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBoundingBoxToAreaAndUpdateTestSets : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Areas", "BoundingBox", c => c.String());
            AddColumn("dbo.TestSets", "BER", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.TestSets", "SSI", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.TestSets", "BERLat", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.TestSets", "BERLong", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestSets", "BERLong");
            DropColumn("dbo.TestSets", "BERLat");
            DropColumn("dbo.TestSets", "SSI");
            DropColumn("dbo.TestSets", "BER");
            DropColumn("dbo.Areas", "BoundingBox");
        }
    }
}

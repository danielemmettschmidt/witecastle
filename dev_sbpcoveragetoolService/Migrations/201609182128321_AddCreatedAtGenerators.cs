namespace dev_sbpcoveragetoolService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedAtGenerators : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Areas", new[] { "CreatedAt" });
            DropIndex("dbo.Projects", new[] { "CreatedAt" });
            DropIndex("dbo.Scenarios", new[] { "CreatedAt" });
            DropIndex("dbo.Methodologies", new[] { "CreatedAt" });
            DropIndex("dbo.TestSets", new[] { "CreatedAt" });
            DropIndex("dbo.DiscrepancyTypes", new[] { "CreatedAt" });
            DropIndex("dbo.TestPointAttempts", new[] { "CreatedAt" });
            DropIndex("dbo.Tiles", new[] { "CreatedAt" });
            DropIndex("dbo.SubAreas", new[] { "CreatedAt" });
            AlterColumn("dbo.Areas", "CreatedAt", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.Projects", "CreatedAt", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.Scenarios", "BERThreshold", c => c.Decimal(precision: 18, scale: 8));
            AlterColumn("dbo.Scenarios", "DAQThreshold", c => c.Decimal(precision: 18, scale: 8));
            AlterColumn("dbo.Scenarios", "CreatedAt", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.Methodologies", "CreatedAt", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.TestSets", "CreatedAt", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.DiscrepancyTypes", "CreatedAt", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.TestPointAttempts", "DAQIn", c => c.Decimal(precision: 18, scale: 8));
            AlterColumn("dbo.TestPointAttempts", "DAQOut", c => c.Decimal(precision: 18, scale: 8));
            AlterColumn("dbo.TestPointAttempts", "LatIn", c => c.Decimal(precision: 18, scale: 8));
            AlterColumn("dbo.TestPointAttempts", "LongIn", c => c.Decimal(precision: 18, scale: 8));
            AlterColumn("dbo.TestPointAttempts", "LatOut", c => c.Decimal(precision: 18, scale: 8));
            AlterColumn("dbo.TestPointAttempts", "LongOut", c => c.Decimal(precision: 18, scale: 8));
            AlterColumn("dbo.TestPointAttempts", "CreatedAt", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.Tiles", "CreatedAt", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.SubAreas", "CreatedAt", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.BerSets", "BER", c => c.Decimal(precision: 18, scale: 8));
            AlterColumn("dbo.BerSets", "SSI", c => c.Decimal(precision: 18, scale: 8));
            AlterColumn("dbo.BerSets", "BERLat", c => c.Decimal(precision: 18, scale: 8));
            AlterColumn("dbo.BerSets", "BERLong", c => c.Decimal(precision: 18, scale: 8));
            CreateIndex("dbo.Areas", "CreatedAt", clustered: true);
            CreateIndex("dbo.Projects", "CreatedAt", clustered: true);
            CreateIndex("dbo.Scenarios", "CreatedAt", clustered: true);
            CreateIndex("dbo.Methodologies", "CreatedAt", clustered: true);
            CreateIndex("dbo.TestSets", "CreatedAt", clustered: true);
            CreateIndex("dbo.DiscrepancyTypes", "CreatedAt", clustered: true);
            CreateIndex("dbo.TestPointAttempts", "CreatedAt", clustered: true);
            CreateIndex("dbo.Tiles", "CreatedAt", clustered: true);
            CreateIndex("dbo.SubAreas", "CreatedAt", clustered: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.SubAreas", new[] { "CreatedAt" });
            DropIndex("dbo.Tiles", new[] { "CreatedAt" });
            DropIndex("dbo.TestPointAttempts", new[] { "CreatedAt" });
            DropIndex("dbo.DiscrepancyTypes", new[] { "CreatedAt" });
            DropIndex("dbo.TestSets", new[] { "CreatedAt" });
            DropIndex("dbo.Methodologies", new[] { "CreatedAt" });
            DropIndex("dbo.Scenarios", new[] { "CreatedAt" });
            DropIndex("dbo.Projects", new[] { "CreatedAt" });
            DropIndex("dbo.Areas", new[] { "CreatedAt" });
            AlterColumn("dbo.BerSets", "BERLong", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.BerSets", "BERLat", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.BerSets", "SSI", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.BerSets", "BER", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.SubAreas", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Tiles", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.TestPointAttempts", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.TestPointAttempts", "LongOut", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.TestPointAttempts", "LatOut", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.TestPointAttempts", "LongIn", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.TestPointAttempts", "LatIn", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.TestPointAttempts", "DAQOut", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.TestPointAttempts", "DAQIn", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.DiscrepancyTypes", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.TestSets", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Methodologies", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Scenarios", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Scenarios", "DAQThreshold", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Scenarios", "BERThreshold", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Projects", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Areas", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            CreateIndex("dbo.SubAreas", "CreatedAt", clustered: true);
            CreateIndex("dbo.Tiles", "CreatedAt", clustered: true);
            CreateIndex("dbo.TestPointAttempts", "CreatedAt", clustered: true);
            CreateIndex("dbo.DiscrepancyTypes", "CreatedAt", clustered: true);
            CreateIndex("dbo.TestSets", "CreatedAt", clustered: true);
            CreateIndex("dbo.Methodologies", "CreatedAt", clustered: true);
            CreateIndex("dbo.Scenarios", "CreatedAt", clustered: true);
            CreateIndex("dbo.Projects", "CreatedAt", clustered: true);
            CreateIndex("dbo.Areas", "CreatedAt", clustered: true);
        }
    }
}

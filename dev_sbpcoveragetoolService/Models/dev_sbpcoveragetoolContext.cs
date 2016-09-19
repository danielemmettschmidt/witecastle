using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using dev_sbpcoveragetoolService.DataObjects;
using Microsoft.Azure.Mobile.Server.Tables;

namespace dev_sbpcoveragetoolService.Models
{
    public class dev_sbpcoveragetoolContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to alter your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        private const string connectionStringName = "Name=MS_TableConnectionString";

        public dev_sbpcoveragetoolContext() : base(connectionStringName)
        {
        } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Methodology>()
                .Property(m => m.CreatedAt)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            modelBuilder.Entity<Area>()
                .Property(m => m.CreatedAt)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            modelBuilder.Entity<SubArea>()
                .Property(m => m.CreatedAt)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            modelBuilder.Entity<Project>()
                .Property(m => m.CreatedAt)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            modelBuilder.Entity<Tile>()
                .Property(m => m.CreatedAt)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            modelBuilder.Entity<TestSet>()
                .Property(m => m.CreatedAt)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            modelBuilder.Entity<BerSet>()
                .Property(t => t.BER)
                .HasPrecision(18, 8);

            modelBuilder.Entity<BerSet>()
                .Property(t => t.SSI)
                .HasPrecision(18, 8);

            modelBuilder.Entity<BerSet>()
                .Property(t => t.BERLat)
                .HasPrecision(18, 8);

            modelBuilder.Entity<BerSet>()
                .Property(t => t.BERLong)
                .HasPrecision(18, 8);

            modelBuilder.Entity<TestPointAttempt>()
                .Property(m => m.CreatedAt)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            modelBuilder.Entity<TestPointAttempt>()
                .Property(t => t.DAQIn)
                .HasPrecision(18, 8);

            modelBuilder.Entity<TestPointAttempt>()
                .Property(t => t.DAQOut)
                .HasPrecision(18, 8);

            modelBuilder.Entity<TestPointAttempt>()
                .Property(t => t.LatIn)
                .HasPrecision(18, 8);

            modelBuilder.Entity<TestPointAttempt>()
                .Property(t => t.LatOut)
                .HasPrecision(18, 8);

            modelBuilder.Entity<TestPointAttempt>()
                .Property(t => t.LongIn)
                .HasPrecision(18, 8);

            modelBuilder.Entity<TestPointAttempt>()
                .Property(t => t.LongOut)
                .HasPrecision(18, 8);

            modelBuilder.Entity<Scenario>()
                .Property(m => m.CreatedAt)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            modelBuilder.Entity<Scenario>()
                .Property(s => s.BERThreshold)
                .HasPrecision(18, 8);

            modelBuilder.Entity<Scenario>()
                .Property(s => s.DAQThreshold)
                .HasPrecision(18, 8);

            modelBuilder.Entity<DiscrepancyType>()
                .Property(m => m.CreatedAt)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<SubArea> SubAreas { get; set; }

        public DbSet<Tile> Tiles { get; set; }

        public DbSet<TestSet> TestSets { get; set; }

        public DbSet<TestPointAttempt> TestPointAttempts { get; set; }

        public DbSet<Scenario> Scenarios { get; set; }

        public DbSet<Methodology> Methodologies { get; set; }

        public DbSet<BerSet> BerSets { get; set; }

        public DbSet<DiscrepancyType> DiscrepancyTypes { get; set; }
    }

}

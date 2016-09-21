using System.Collections.Generic;
using System.Data.Entity.Spatial;
using dev_sbpcoveragetoolService.DataObjects;
using dev_sbpcoveragetoolService.Utilities;

namespace dev_sbpcoveragetoolService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<dev_sbpcoveragetoolService.Models.dev_sbpcoveragetoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "dev_sbpcoveragetoolService.Models.dev_sbpcoveragetoolContext";
        }

        protected override void Seed(dev_sbpcoveragetoolService.Models.dev_sbpcoveragetoolContext context)
        {
            context.Methodologies.AddOrUpdate(
                m => m.Id,
                new Methodology { Id = "Methodology1", Name = "NormalRoundTrip", EntryMethod = "P/F", PassCriteria = "P/F", Dependency = "None", ExtraInfo = false, TestDirection = "Round" },
                new Methodology { Id = "Methodology2", Name = "BestRoundTrip", EntryMethod = "P/F", PassCriteria = "Best", Dependency = "None", ExtraInfo = false, TestDirection = "Round" },
                new Methodology { Id = "Methodology3", Name = "NormalInOnly", EntryMethod = "P/F", PassCriteria = "Best", Dependency = "None", ExtraInfo = false, TestDirection = "In" },
                new Methodology { Id = "Methodology4", Name = "NormalOutOnly", EntryMethod = "P/F", PassCriteria = "Best", Dependency = "None", ExtraInfo = false, TestDirection = "Out" }
            );

            context.Projects.AddOrUpdate(
                p => p.Id,
                new Project { Id = "Project1", Name = "Harford", ProjectManager = "", LeadEngineer = "", CustomerContactName = "", CustomerContactPhone = "", DateStarted = null, DateCompleted = null, RequirementNotes = "", Active = true },
                new Project { Id = "Project2", Name = "Berks", ProjectManager = "", LeadEngineer = "", CustomerContactName = "", CustomerContactPhone = "", DateStarted = null, DateCompleted = null, RequirementNotes = "", Active = true },
                new Project { Id = "Project3", Name = "Nelson", ProjectManager = "", LeadEngineer = "", CustomerContactName = "", CustomerContactPhone = "", DateStarted = null, DateCompleted = null, RequirementNotes = "", Active = true }
            );

            context.Areas.AddOrUpdate(
                new Area { Id = "Area1", Name = "Harford County", ShapeFile = "", ProjectId = "Project1" },
                new Area { Id = "Area2", Name = "In-Street", ShapeFile = "", ProjectId = "Project2" },
                new Area { Id = "Area3", Name = "12dB Building", ShapeFile = "", ProjectId = "Project2" },
                new Area { Id = "Area4", Name = "20dB Building", ShapeFile = "", ProjectId = "Project2" },
                new Area { Id = "Area5", Name = "Nelson County", ShapeFile = "", ProjectId = "Project3" }
            );

            context.SubAreas.AddOrUpdate(
                new SubArea { Id = "SubArea1", Name = "6 dB", SubAreaAttenuation = 6, Comment = "", AreaId = "Area1", ProjectId = "Project1" },
                new SubArea { Id = "SubArea2", Name = "12 dB", SubAreaAttenuation = 12, Comment = "", AreaId = "Area1", ProjectId = "Project1" },
                new SubArea { Id = "SubArea3", Name = "18 dB", SubAreaAttenuation = 18, Comment = "", AreaId = "Area1", ProjectId = "Project1" },
                new SubArea { Id = "SubArea4", Name = "In-Street", SubAreaAttenuation = 0, Comment = "", AreaId = "Area2", ProjectId = "Project2" },
                new SubArea { Id = "SubArea5", Name = "12 dB", SubAreaAttenuation = 12, Comment = "", AreaId = "Area3", ProjectId = "Project2" },
                new SubArea { Id = "SubArea6", Name = "20 dB", SubAreaAttenuation = 20, Comment = "", AreaId = "Area4", ProjectId = "Project2" },
                new SubArea { Id = "SubArea7", Name = "In-Street", SubAreaAttenuation = 0, Comment = "", AreaId = "Area5", ProjectId = "Project3" }
                );

            context.Scenarios.AddOrUpdate(
                new Scenario { Id = "Scenario1", Name = "CMARC", NumberOfAttempts = 2, BERTested = true, SSITested = true, BERThreshold = 2.0M, DAQThreshold = 3.0M, Comments = "", ProjectId = "Project1", MethodologyId = "Methodology1" },
                new Scenario { Id = "Scenario2", Name = "HACO", NumberOfAttempts = 2, BERTested = true, SSITested = true, BERThreshold = 2.0M, DAQThreshold = 3.0M, Comments = "", ProjectId = "Project1", MethodologyId = "Methodology1" },
                new Scenario { Id = "Scenario3", Name = "800MHz", NumberOfAttempts = 3, BERTested = true, SSITested = true, BERThreshold = 2.4M, DAQThreshold = 3.0M, Comments = "", ProjectId = "Project2", MethodologyId = "Methodology3" },
                new Scenario { Id = "Scenario4", Name = "Audio", NumberOfAttempts = 3, BERTested = true, SSITested = true, BERThreshold = 2.0M, DAQThreshold = 3.0M, Comments = "", ProjectId = "Project3", MethodologyId = "Methodology2" },
                new Scenario { Id = "Scenario5", Name = "Pager", NumberOfAttempts = 3, BERTested = false, SSITested = false, BERThreshold = 0, DAQThreshold = 0, Comments = "", ProjectId = "Project3", MethodologyId = "Methodology4" }
            );

            var tiles = new List<Tile>
            {
                new Tile
                {
                    Id = "b558ef1f-499f-499c-b776-289f3ae62f01",
                    X = 55,
                    Y = 142,
                    Geometry =
                        DbGeometry.FromText(
                            "POLYGON((-90.735 38.48,-90.73083 38.48,-90.73083 38.47667,-90.735 38.47667,-90.735 38.48))",
                            4326),
                    SubAreaId = "SubArea1",
                    ProjectId = "Project1"
                },
                new Tile
                {
                    Id = "1d675827-e7f6-4c3a-a3ea-53ca444c6d52",
                    X = 55,
                    Y = 143,
                    Geometry =
                        DbGeometry.FromText(
                            "POLYGON((-90.735 38.48333,-90.73083 38.48333,-90.73083 38.48,-90.735 38.48,-90.735 38.48333))",
                            4326),
                    SubAreaId = "SubArea2",
                    ProjectId = "Project1"
                },
                new Tile
                {
                    Id = "240a8efc-7ca7-45e9-b009-18a4bf8f598f",
                    X = 55,
                    Y = 144,
                    Geometry =
                        DbGeometry.FromText(
                            "POLYGON((-90.735 38.48667,-90.73083 38.48667,-90.73083 38.48333,-90.735 38.48333,-90.735 38.48667))",
                            4326),
                    SubAreaId = "SubArea3",
                    ProjectId = "Project1"
                },
                new Tile
                {
                    Id = "10a66498-794d-49c3-830f-402064c42f0a",
                    X = 55,
                    Y = 145,
                    Geometry =
                        DbGeometry.FromText(
                            "POLYGON((-90.735 38.49,-90.73083 38.49,-90.73083 38.48667,-90.735 38.48667,-90.735 38.49))",
                            4326),
                    SubAreaId = "SubArea4",
                    ProjectId = "Project1"
                },
                new Tile
                {
                    Id = "1a71feb9-8978-4bf0-bcb7-a879a74d33a7",
                    X = 55,
                    Y = 146,
                    Geometry =
                        DbGeometry.FromText(
                            "POLYGON((-90.735 38.49333,-90.73083 38.49333,-90.73083 38.49,-90.735 38.49,-90.735 38.49333))",
                            4326),
                    SubAreaId = "SubArea5",
                    ProjectId = "Project1"
                },
                new Tile
                {
                    Id = "5b125f08-f1a9-448e-b482-f84213b13efa",
                    X = 55,
                    Y = 147,
                    Geometry =
                        DbGeometry.FromText(
                            "POLYGON((-90.735 38.49667,-90.73083 38.49667,-90.73083 38.49333,-90.735 38.49333,-90.735 38.49667))",
                            4326),
                    SubAreaId = "SubArea6",
                    ProjectId = "Project1"
                },
                new Tile()
                {
                    Id = "36bcb1e8-8057-4da3-a5ac-6a63e6508dbc",
                    X = 55,
                    Y = 148,
                    Geometry =
                        DbGeometry.FromText(
                            "POLYGON((-90.735 38.5,-90.73083 38.5,-90.73083 38.49667,-90.735 38.49667,-90.735 38.5))",
                            4326),
                    SubAreaId = "SubArea7",
                    ProjectId = "Project1"
                }
            };

            foreach (var tile in tiles)
            {
                context.Tiles.AddOrUpdate(tile);
            }

            context.TestSets.AddOrUpdate(
                new TestSet() { Id = "TestSet1", TileId = tiles[0].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea1", ProjectId = "Project1", Outcome = true, Deleted = false },
                new TestSet() { Id = "TestSet2", TileId = tiles[0].Id, FieldTeamNumber = 2, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea1", ProjectId = "Project1", Outcome = false, Deleted = false },
                new TestSet() { Id = "TestSet3", TileId = tiles[1].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea2", ProjectId = "Project1", Outcome = false, Deleted = false },
                new TestSet() { Id = "TestSet4", TileId = tiles[2].Id, FieldTeamNumber = 3, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea1", ProjectId = "Project1", Outcome = false, Deleted = false },
                new TestSet() { Id = "TestSet5", TileId = tiles[1].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea2", ProjectId = "Project1", Outcome = false, Deleted = false },
                new TestSet() { Id = "TestSet6", TileId = tiles[0].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea3", ProjectId = "Project1", Outcome = false, Deleted = false },
                new TestSet() { Id = "TestSet11", TileId = tiles[3].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea1", ProjectId = "Project1", Outcome = false, Deleted = false },
                new TestSet() { Id = "TestSet21", TileId = tiles[2].Id, FieldTeamNumber = 2, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea1", ProjectId = "Project1", Outcome = true, Deleted = false },
                new TestSet() { Id = "TestSet31", TileId = tiles[1].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea2", ProjectId = "Project1", Outcome = true, Deleted = false },
                new TestSet() { Id = "TestSet41", TileId = tiles[0].Id, FieldTeamNumber = 3, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea1", ProjectId = "Project1", Outcome = true, Deleted = false },
                new TestSet() { Id = "TestSet51", TileId = tiles[1].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea2", ProjectId = "Project1", Outcome = true, Deleted = false },
                new TestSet() { Id = "TestSet61", TileId = tiles[0].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea3", ProjectId = "Project1", Outcome = false, Deleted = false },
                new TestSet() { Id = "TestSet12", TileId = tiles[1].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea1", ProjectId = "Project1", Outcome = true, Deleted = false },
                new TestSet() { Id = "TestSet22", TileId = tiles[2].Id, FieldTeamNumber = 2, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea1", ProjectId = "Project1", Outcome = false, Deleted = false },
                new TestSet() { Id = "TestSet32", TileId = tiles[3].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea2", ProjectId = "Project1", Outcome = true, Deleted = false },
                new TestSet() { Id = "TestSet42", TileId = tiles[4].Id, FieldTeamNumber = 3, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea1", ProjectId = "Project1", Outcome = true, Deleted = false },
                new TestSet() { Id = "TestSet52", TileId = tiles[5].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea2", ProjectId = "Project1", Outcome = true, Deleted = false },
                new TestSet() { Id = "TestSet62", TileId = tiles[6].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea3", ProjectId = "Project1", Outcome = false, Deleted = false },
                new TestSet() { Id = "TestSet14", TileId = tiles[0].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea1", ProjectId = "Project1", Outcome = true, Deleted = false },
                new TestSet() { Id = "TestSet24", TileId = tiles[1].Id, FieldTeamNumber = 2, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea1", ProjectId = "Project1", Outcome = false, Deleted = false },
                new TestSet() { Id = "TestSet34", TileId = tiles[2].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea2", ProjectId = "Project1", Outcome = false, Deleted = false },
                new TestSet() { Id = "TestSet44", TileId = tiles[3].Id, FieldTeamNumber = 3, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea1", ProjectId = "Project1", Outcome = false, Deleted = false },
                new TestSet() { Id = "TestSet54", TileId = tiles[1].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea2", ProjectId = "Project1", Outcome = false, Deleted = false },
                new TestSet() { Id = "TestSet64", TileId = tiles[4].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea3", ProjectId = "Project1", Outcome = false, Deleted = false },
                new TestSet() { Id = "TestSet114", TileId = tiles[5].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea1", ProjectId = "Project1", Outcome = false, Deleted = false },
                new TestSet() { Id = "TestSet214", TileId = tiles[5].Id, FieldTeamNumber = 2, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea1", ProjectId = "Project1", Outcome = true, Deleted = false },
                new TestSet() { Id = "TestSet314", TileId = tiles[6].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea2", ProjectId = "Project1", Outcome = true, Deleted = false },
                new TestSet() { Id = "TestSet414", TileId = tiles[4].Id, FieldTeamNumber = 3, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea1", ProjectId = "Project1", Outcome = true, Deleted = false },
                new TestSet() { Id = "TestSet514", TileId = tiles[5].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea2", ProjectId = "Project1", Outcome = true, Deleted = false },
                new TestSet() { Id = "TestSet614", TileId = tiles[1].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea3", ProjectId = "Project1", Outcome = false, Deleted = false },
                new TestSet() { Id = "TestSet124", TileId = tiles[0].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea1", ProjectId = "Project1", Outcome = true, Deleted = false },
                new TestSet() { Id = "TestSet224", TileId = tiles[0].Id, FieldTeamNumber = 2, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea1", ProjectId = "Project1", Outcome = false, Deleted = false },
                new TestSet() { Id = "TestSet324", TileId = tiles[1].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea2", ProjectId = "Project1", Outcome = true, Deleted = false },
                new TestSet() { Id = "TestSet424", TileId = tiles[2].Id, FieldTeamNumber = 3, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea1", ProjectId = "Project1", Outcome = true, Deleted = false },
                new TestSet() { Id = "TestSet524", TileId = tiles[1].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea2", ProjectId = "Project1", Outcome = true, Deleted = false },
                new TestSet() { Id = "TestSet624", TileId = tiles[0].Id, FieldTeamNumber = 1, DispatchTeamNumber = 1, TestTeamType = "F", SubAreaId = "SubArea3", ProjectId = "Project1", Outcome = false, Deleted = false }
                );

            context.DiscrepancyTypes.AddOrUpdate(
                new DiscrepancyType { Id = "Missing", Comment = "A missing test set. Please make sure this test set has been tested and recorded by both Dispatch and Field teams." },
                new DiscrepancyType { Id = "Discrepancy", Comment = "There is a mismatch between the Field and Dispatch TestSet. Please check the TestSet and fix the discrepancy then push the update." },
                new DiscrepancyType { Id = "None", Comment = "No discrepancy found for this TestSet" }
                );

            byte[] salt = CustomLoginProviderUtils.GenerateSalt();
            context.Accounts.AddOrUpdate(new Account() {
                Id = "Bhavesh",
                Username = "bpatel",
                FirstName = "Bhavesh",
                LastName = "Patel",
                Email = "bpatel@sbp.com",
                Salt = salt,
                SaltedAndHashedPassword = CustomLoginProviderUtils.Hash("password", salt)
            }, new Account
            {
                Id = "Ebsan",
                Username = "euddin",
                FirstName = "Ebsan",
                LastName = "Uddin",
                Email = "ebsanu@sbp.com",
                Salt = salt,
                SaltedAndHashedPassword = CustomLoginProviderUtils.Hash("password1", salt)
            },  new Account
            {
                Id = "Guest",
                Username = "guest",
                FirstName = "Guest",
                LastName = "Account",
                Email = "guest@sbp.com",
                Salt = salt,
                SaltedAndHashedPassword = CustomLoginProviderUtils.Hash("password1", salt)
            });
           
            context.SaveChanges();
        }
    }
}

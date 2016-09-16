using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;
using Newtonsoft.Json;

namespace dev_sbpcoveragetoolService.DataObjects
{
    public class TestSet : EntityData
    {
        public TestSet()
        {
            TestPointAttempts = new List<TestPointAttempt>();
        }

        [StringLength(10)]
        public string TestTeamType { get; set; }
        public int FieldTeamNumber { get; set; }
        public int? DispatchTeamNumber { get; set; }

        [DefaultValue(0)]
        public int TestSetCount { get; set; }

        // TestSetId for the opposing team's TestSet that has a discrepancy. This is voluntarily set
        public string DiscrepancyTestSetId { get; set; }
        public string Comments { get; set; }
        public bool Outcome { get; set; }

        [Required]
        public string SubAreaId { get; set; }

        [Required]
        public string ProjectId { get; set; }

        [Required]
        public string TileId { get; set; }
        [JsonIgnore]
        public virtual Tile Tile { get; set; }

        public string ScenarioId { get; set; }
        [JsonIgnore]
        public virtual Scenario Scenario { get; set; }

        public string DiscrepancyTypeId { get; set; }
        [JsonIgnore]
        public virtual DiscrepancyType DiscrepancyType { get; set; }

        public virtual ICollection<TestPointAttempt> TestPointAttempts { get; set; }

    }
}
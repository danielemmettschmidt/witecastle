using Microsoft.Azure.Mobile.Server;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace dev_sbpcoveragetoolService.DataObjects
{
    public class TestPointAttempt : EntityData
    {
        [Required]
        public int TestAttemptNumber { get; set; }

        public bool? TalkIn { get; set; }
        public bool? TalkOut { get; set; }
        public decimal? DAQIn { get; set; }
        public decimal? DAQOut { get; set; }
        public decimal? LatIn { get; set; }
        public decimal? LongIn { get; set; }
        public decimal? LatOut { get; set; }
        public decimal? LongOut { get; set; }

        [Required]
        public string SubAreaId { get; set; }

        [Required]
        public string ProjectId { get; set; }

        [Required]
        public string TestSetId { get; set; }
        [JsonIgnore]
        public virtual TestSet TestSet { get; set; }
    }
}
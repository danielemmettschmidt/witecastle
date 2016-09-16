using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;

namespace dev_sbpcoveragetoolService.DataObjects
{
    public class Scenario : EntityData
    {
        public Scenario()
        {
            TestSets = new List<TestSet>();
        }

        [Required(ErrorMessage = "Scenario must include a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Attempt number must not be empty.")]
        public int NumberOfAttempts { get; set; }

        [Required(ErrorMessage = "BERTested boolean must not be null")]
        public bool BERTested { get; set; }

        [Required(ErrorMessage = "SSITested boolean must not be null")]
        public bool SSITested { get; set; }

        public decimal? BERThreshold { get; set; }
        public decimal? DAQThreshold { get; set; }
        public string Comments { get; set; }

        [Required]
        public string ProjectId { get; set; }
        public virtual Project Project { get; set; }

        [Required]
        public string MethodologyId { get; set; }
        public virtual Methodology Methodology { get; set; }

        public virtual ICollection<TestSet> TestSets { get; set; }
    }
}
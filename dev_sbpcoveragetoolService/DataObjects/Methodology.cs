using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;

namespace dev_sbpcoveragetoolService.DataObjects
{
    public class Methodology : EntityData
    {
        public Methodology()
        {
            Scenarioes = new List<Scenario>();
        }

        public string Name { get; set; }

        [Required]
        public string EntryMethod { get; set; }

        [Required]
        public string TestDirection { get; set; }

        [Required]
        public string PassCriteria { get; set; }

        [Required]
        public string Dependency { get; set; }

        public bool ExtraInfo { get; set; }

        public virtual ICollection<Scenario> Scenarioes { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Azure.Mobile.Server;

namespace dev_sbpcoveragetoolService.DataObjects
{
    public class Project : EntityData
    {
        public Project()
        {
            Areas = new List<Area>();
            Scenarioes = new List<Scenario>();
        }

        [Required(ErrorMessage = "Project name cannot be null.")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "Project manager name cannot be longer than 50 characters.")]
        public string ProjectManager { get; set; }

        [StringLength(50, ErrorMessage = "Lead engineer name cannot be longer than 50 characters.")]
        public string LeadEngineer { get; set; }

        [StringLength(50, ErrorMessage = "Customer contact name cannot be longer than 50 characters.")]
        public string CustomerContactName { get; set; }

        // TODO: Add a regular expression annotation.
        [StringLength(12, ErrorMessage = "Customer contact number cannot be longer than 12 characters and must be in the form 000-000-0000")]
        public string CustomerContactPhone { get; set; }

        public DateTimeOffset? DateStarted { get; set; }
        public DateTimeOffset? DateCompleted { get; set; }
        public string RequirementNotes { get; set; }

        public bool Active { get; set; }

        public decimal CenterLat { get; set; }
        public decimal CenterLong { get; set; }

        public virtual ICollection<Area> Areas { get; set; }
        public virtual ICollection<Scenario> Scenarioes { get; set; }
    }
}
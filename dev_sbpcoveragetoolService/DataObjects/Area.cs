using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace dev_sbpcoveragetoolService.DataObjects
{
    public class Area : EntityData
    {
        public Area()
        {
            SubAreas = new List<SubArea>();
        }

        [Required(ErrorMessage = "Project name cannot be null.")]
        public string Name { get; set; }

        public string ShapeFile { get; set; }
        // A json serialized string of type Microsoft.Maps.SpatialToolbox.BoundingBox
        public string BoundingBox { get; set; }

        [Required]
        public string ProjectId { get; set; }
        [JsonIgnore]
        public virtual Project Project { get; set; }

        public virtual ICollection<SubArea> SubAreas { get; set; }
    }
}
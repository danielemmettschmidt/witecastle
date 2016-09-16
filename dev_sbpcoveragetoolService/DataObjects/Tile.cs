using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;
using Newtonsoft.Json;

namespace dev_sbpcoveragetoolService.DataObjects
{
    public class Tile : EntityData
    {
        public Tile()
        {
            TestSets = new List<TestSet>();
        }

        [Required(ErrorMessage = "X tile coordinate cannot be empty.")]
        public int X { get; set; }

        [Required(ErrorMessage = "Y tile coordinate cannot be empty.")]
        public int Y { get; set; }

        public DbGeometry Geometry { get; set; }

        [Required]
        public string SubAreaId { get; set; }
        [JsonIgnore]
        public virtual SubArea SubArea { get; set; }

        // Used for local db syncs only
        [Required]
        [StringLength(128)]
        [Index]
        public string ProjectId { get; set; }

        public virtual ICollection<TestSet> TestSets { get; set; }
    }
}
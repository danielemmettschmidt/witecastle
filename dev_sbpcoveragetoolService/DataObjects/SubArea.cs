using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;

namespace dev_sbpcoveragetoolService.DataObjects
{
    public class SubArea : EntityData
    {
        public SubArea()
        {
            Tiles = new List<Tile>();
        }

        public int? SubAreaAttenuation { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string ShapeFile { get; set; }

        [Required]
        public string AreaId { get; set; }

        // Used for local db syncs only
        [Required]
        public string ProjectId { get; set; }

        public virtual ICollection<Tile> Tiles { get; set; }
    }
}
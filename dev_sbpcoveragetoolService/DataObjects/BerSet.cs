using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.Azure.Mobile.Server;
using Newtonsoft.Json;

namespace dev_sbpcoveragetoolService.DataObjects
{
    public class BerSet : EntityData
    {
        public decimal? BER { get; set; }
        public decimal? SSI { get; set; }
        public decimal? BERLat { get; set; }
        public decimal? BERLong { get; set; }

        [Required]
        public string TileId { get; set; }
        [JsonIgnore]
        public Tile Tile { get; set; }

        [Required]
        public string SubAreaId { get; set; }

        [Required]
        public string ProjectId { get; set; }

        public string ScenarioId { get; set; }
        [JsonIgnore]
        public virtual Scenario Scenario { get; set; }
        public int FieldTeamNumber { get; set; }
    }
}
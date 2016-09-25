using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Azure.Mobile.Server;

namespace dev_sbpcoveragetoolService.DataTransferObjects
{
    public class TileDto : EntityData
    {
        [Required(ErrorMessage = "X tile coordinate cannot be empty.")]
        public int X { get; set; }

        [Required(ErrorMessage = "Y tile coordinate cannot be empty.")]
        public int Y { get; set; }

        public int Srid { get; set; }
        public string Geometry { get; set; }

        [Required]
        public string SubAreaId { get; set; }

        // Used for local db syncs only
        [Required]
        [StringLength(128)]
        [Index]
        public string ProjectId { get; set; }
    }
}
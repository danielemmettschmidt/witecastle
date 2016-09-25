using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using dev_sbpcoveragetoolService.DataObjects;
using dev_sbpcoveragetoolService.DataTransferObjects;
using dev_sbpcoveragetoolService.Models;
using Microsoft.Azure.Mobile.Server.Config;
using Microsoft.Owin.Logging;

namespace dev_sbpcoveragetoolService.Controllers
{
    [MobileAppController]
    //[AuthorizeLevel(AuthorizationLevel.User)]
    public class BatchTilesController : ApiController
    {
        dev_sbpcoveragetoolContext _context;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            _context = new dev_sbpcoveragetoolContext();
        }
        
        [HttpPost]
        public async Task<bool> InsertTiles(List<TileDto> tileDtos)
        {
            var tiles = new List<Tile>();
            foreach (var t in tileDtos)
            {
                if (string.IsNullOrEmpty(t.Id))
                {
                    t.Id = Guid.NewGuid().ToString();
                }

                if (!string.IsNullOrWhiteSpace(t.Geometry))
                {
                    var tile = new Tile()
                    {
                        Id = t.Id,
                        CreatedAt = t.CreatedAt,
                        Deleted = t.Deleted,
                        Geometry = DbGeometry.FromText(t.Geometry, 4326),
                        ProjectId = t.ProjectId,
                        SubAreaId = t.SubAreaId,
                        X = t.X,
                        Y = t.Y
                    };
                    tiles.Add(tile);
                }
                else
                {
                    System.Diagnostics.Trace.TraceError($"Tile with id {t.Id} did not have a valid Geometry property. System cannot create this tile.");
                    return false;
                }
            }

            try
            {
                _context.Tiles.AddRange(tiles);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError(ex.ToString());
                return false;
            }
        }

    }

}

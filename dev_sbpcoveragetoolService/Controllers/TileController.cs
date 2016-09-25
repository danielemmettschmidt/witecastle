using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using dev_sbpcoveragetoolService.DataObjects;
using dev_sbpcoveragetoolService.Models;

namespace dev_sbpcoveragetoolService.Controllers
{
    public class TileController : TableController<Tile>
    {
        private dev_sbpcoveragetoolContext _context;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            _context = new dev_sbpcoveragetoolContext();
            DomainManager = new EntityDomainManager<Tile>(_context, Request);
        }

        // GET tables/Tile
        public IQueryable<Tile> GetAllTile()
        {
            return Query(); 
        }

        // GET tables/Tile/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Tile> GetTile(string id)
        {
            return Lookup(id);
        }

        // GET tables/Tile/CurrentTestedTiles
        public IEnumerable<Tile> GetCurrentTestedTiles(string subAreaId, int fieldTeamNumber, int dispatchTeamNumber, bool discrepancyCheck = false)
        {
            List<Tile> results;
            if (discrepancyCheck)
            {
                results = _context.Tiles
                    .Join(_context.TestSets, tile => tile.Id, testSet => testSet.TileId,
                        (tile, testSet) => new {tile, testSet})
                    .Where(
                        record =>
                            record.tile.SubAreaId == subAreaId
                            && record.testSet.FieldTeamNumber == fieldTeamNumber
                            &&
                            (record.testSet.DiscrepancyTypeId.ToUpper().Contains("DISCREPANCY") ||
                             (record.testSet.TestTeamType.ToUpper().Contains("F") &&
                              record.testSet.DiscrepancyTypeId.ToUpper().Contains("MISSING")))
                    ).Select(record => new Tile()
                    {
                        Id = record.tile.Id,
                        ProjectId = record.tile.ProjectId,
                        SubAreaId = record.tile.SubAreaId,
                        X = record.tile.X,
                        Y = record.tile.X,
                        CreatedAt = record.tile.CreatedAt,
                        Version = record.tile.Version,
                        UpdatedAt = record.tile.UpdatedAt,
                        Deleted = record.tile.Deleted
                    }).ToList();
            }
            else
            {
                results = _context.Tiles
                    .Join(_context.TestSets, tile => tile.Id, testSet => testSet.TileId,
                        (tile, testSet) => new { tile, testSet })
                    .Where(
                        record =>
                            record.tile.SubAreaId == subAreaId
                            && record.testSet.FieldTeamNumber == fieldTeamNumber
                    ).Select(record => new Tile()
                    {
                        Id = record.tile.Id,
                        ProjectId = record.tile.ProjectId,
                        SubAreaId = record.tile.SubAreaId,
                        X = record.tile.X,
                        Y = record.tile.X,
                        CreatedAt = record.tile.CreatedAt,
                        Version = record.tile.Version,
                        UpdatedAt = record.tile.UpdatedAt,
                        Deleted = record.tile.Deleted
                    }).ToList();
            }

            return results;
        }

        public IEnumerable<Tile> GetDiscrepancyTestedTiles(string subAreaId, int fieldTeamNumber)
        {

            var tileTable = _context.Tiles;
            var testSetTable = _context.TestSets;

            var fieldTiles = (from tile in tileTable
                              join testSet in testSetTable on tile.Id equals testSet.TileId
                              where testSet.TestTeamType == "F"
                                      && testSet.FieldTeamNumber == fieldTeamNumber
                                      && tile.SubAreaId == subAreaId
                                      && (testSet.DiscrepancyTypeId.ToUpper().Contains("DISCREPANCY")
                                            || testSet.DiscrepancyTypeId.ToUpper().Contains("MISSING"))
                              select tile).Distinct<Tile>().ToList();

            return fieldTiles;
        }

        // PATCH tables/Tile/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Tile> PatchTile(string id, Delta<Tile> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Tile
        public async Task<IHttpActionResult> PostTile(Tile item)
        {
            Tile current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Tile/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTile(string id)
        {
             return DeleteAsync(id);
        }
    }
}

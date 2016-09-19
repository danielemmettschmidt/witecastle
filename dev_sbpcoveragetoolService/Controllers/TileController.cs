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
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            dev_sbpcoveragetoolContext context = new dev_sbpcoveragetoolContext();
            DomainManager = new EntityDomainManager<Tile>(context, Request);
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

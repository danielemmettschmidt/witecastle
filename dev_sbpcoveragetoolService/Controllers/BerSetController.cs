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
    public class BerSetController : TableController<BerSet>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            dev_sbpcoveragetoolContext context = new dev_sbpcoveragetoolContext();
            DomainManager = new EntityDomainManager<BerSet>(context, Request);
        }

        // GET tables/BerSet
        public IQueryable<BerSet> GetAllBerSet()
        {
            return Query(); 
        }

        // GET tables/BerSet/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<BerSet> GetBerSet(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/BerSet/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<BerSet> PatchBerSet(string id, Delta<BerSet> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/BerSet
        public async Task<IHttpActionResult> PostBerSet(BerSet item)
        {
            BerSet current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/BerSet/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteBerSet(string id)
        {
             return DeleteAsync(id);
        }
    }
}

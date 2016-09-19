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
    public class DiscrepancyTypeController : TableController<DiscrepancyType>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            dev_sbpcoveragetoolContext context = new dev_sbpcoveragetoolContext();
            DomainManager = new EntityDomainManager<DiscrepancyType>(context, Request);
        }

        // GET tables/DiscrepancyType
        public IQueryable<DiscrepancyType> GetAllDiscrepancyType()
        {
            return Query(); 
        }

        // GET tables/DiscrepancyType/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<DiscrepancyType> GetDiscrepancyType(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/DiscrepancyType/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<DiscrepancyType> PatchDiscrepancyType(string id, Delta<DiscrepancyType> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/DiscrepancyType
        public async Task<IHttpActionResult> PostDiscrepancyType(DiscrepancyType item)
        {
            DiscrepancyType current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/DiscrepancyType/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteDiscrepancyType(string id)
        {
             return DeleteAsync(id);
        }
    }
}

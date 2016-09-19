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
    public class MethodologyController : TableController<Methodology>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            dev_sbpcoveragetoolContext context = new dev_sbpcoveragetoolContext();
            DomainManager = new EntityDomainManager<Methodology>(context, Request);
        }

        // GET tables/Methodology
        public IQueryable<Methodology> GetAllMethodology()
        {
            return Query(); 
        }

        // GET tables/Methodology/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Methodology> GetMethodology(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Methodology/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Methodology> PatchMethodology(string id, Delta<Methodology> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Methodology
        public async Task<IHttpActionResult> PostMethodology(Methodology item)
        {
            Methodology current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Methodology/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteMethodology(string id)
        {
             return DeleteAsync(id);
        }
    }
}

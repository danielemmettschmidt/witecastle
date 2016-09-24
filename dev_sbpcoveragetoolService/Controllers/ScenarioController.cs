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
    public class ScenarioController : TableController<Scenario>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            dev_sbpcoveragetoolContext context = new dev_sbpcoveragetoolContext();
            DomainManager = new EntityDomainManager<Scenario>(context, Request);
        }

        // GET tables/Scenario
        public IQueryable<Scenario> GetAllScenario()
        {
            return Query(); 
        }

        // GET tables/Scenario/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Scenario> GetScenario(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Scenario/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Scenario> PatchScenario(string id, Delta<Scenario> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Scenario
        public async Task<IHttpActionResult> PostScenario(Scenario item)
        {
            Scenario current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Scenario/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteScenario(string id)
        {
             return DeleteAsync(id);
        }
    }
}

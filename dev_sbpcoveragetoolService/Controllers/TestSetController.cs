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
    public class TestSetController : TableController<TestSet>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            dev_sbpcoveragetoolContext context = new dev_sbpcoveragetoolContext();
            DomainManager = new EntityDomainManager<TestSet>(context, Request);
        }

        // GET tables/TestSet
        public IQueryable<TestSet> GetAllTestSet()
        {
            return Query(); 
        }

        // GET tables/TestSet/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<TestSet> GetTestSet(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TestSet/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<TestSet> PatchTestSet(string id, Delta<TestSet> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/TestSet
        public async Task<IHttpActionResult> PostTestSet(TestSet item)
        {
            TestSet current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TestSet/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTestSet(string id)
        {
             return DeleteAsync(id);
        }
    }
}

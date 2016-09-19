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
    public class TestPointAttemptController : TableController<TestPointAttempt>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            dev_sbpcoveragetoolContext context = new dev_sbpcoveragetoolContext();
            DomainManager = new EntityDomainManager<TestPointAttempt>(context, Request);
        }

        // GET tables/TestPointAttempt
        public IQueryable<TestPointAttempt> GetAllTestPointAttempt()
        {
            return Query(); 
        }

        // GET tables/TestPointAttempt/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<TestPointAttempt> GetTestPointAttempt(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TestPointAttempt/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<TestPointAttempt> PatchTestPointAttempt(string id, Delta<TestPointAttempt> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/TestPointAttempt
        public async Task<IHttpActionResult> PostTestPointAttempt(TestPointAttempt item)
        {
            TestPointAttempt current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TestPointAttempt/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTestPointAttempt(string id)
        {
             return DeleteAsync(id);
        }
    }
}

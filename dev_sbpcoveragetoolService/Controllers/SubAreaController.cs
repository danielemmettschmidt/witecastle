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
    public class SubAreaController : TableController<SubArea>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            dev_sbpcoveragetoolContext context = new dev_sbpcoveragetoolContext();
            DomainManager = new EntityDomainManager<SubArea>(context, Request);
        }

        // GET tables/SubArea
        public IQueryable<SubArea> GetAllSubArea()
        {
            return Query(); 
        }

        // GET tables/SubArea/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<SubArea> GetSubArea(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/SubArea/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<SubArea> PatchSubArea(string id, Delta<SubArea> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/SubArea
        public async Task<IHttpActionResult> PostSubArea(SubArea item)
        {
            SubArea current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/SubArea/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteSubArea(string id)
        {
             return DeleteAsync(id);
        }
    }
}

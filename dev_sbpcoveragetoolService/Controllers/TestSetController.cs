using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using dev_sbpcoveragetoolService.DataObjects;
using dev_sbpcoveragetoolService.Models;
using dev_sbpcoveragetoolService.SignalR;
using RestSharp;

namespace dev_sbpcoveragetoolService.Controllers
{
    public class TestSetController : TableController<TestSet>
    {
        private dev_sbpcoveragetoolContext _context;
        private ISignalRClientService _clientService;

        public TestSetController(ISignalRClientService clientService)
        {
            _clientService = clientService;
        }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            _context = new dev_sbpcoveragetoolContext();
            DomainManager = new EntityDomainManager<TestSet>(_context, Request);
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
            // TODO: Re-enable discrepancy checks
            var testSet = await CheckForDiscrepancy(item);
            var current = await InsertAsync(testSet);
            NotifyViewer(testSet.ProjectId, testSet.Id);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TestSet/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTestSet(string id)
        {
             return DeleteAsync(id);
        }

        private async Task<TestSet> CheckForDiscrepancy(TestSet sourceTestSet)
        {
            // Default to failed test

            // Set the team type to search for opposite to the one being posted.
            var searchTeamType = sourceTestSet.TestTeamType == "D" ? "F" : "D";

            // TODO: This result could hold more than one testSet. We need to make sure that only one testSet exists.
            var foundTestSets = _context.TestSets.Where(ts => ts.TileId == sourceTestSet.TileId
                                                             && ts.ScenarioId == sourceTestSet.ScenarioId
                                                             && ts.TestTeamType == searchTeamType)
                .OrderByDescending(ts => ts.CreatedAt);

            TestSet foundTestSet;

            if (searchTeamType == "F")
            {
                foundTestSet =
                    foundTestSets.ToList().FirstOrDefault(ts => ts.FieldTeamNumber == sourceTestSet.FieldTeamNumber);
            }
            else
            {
                foundTestSet = foundTestSets.FirstOrDefault();
            }

            // If no other test set was found from the opposing team then the test set is missing.
            // Else a testSet was found so continue with checks.
            if (!foundTestSets.Any() || foundTestSet == null)
            {
                sourceTestSet.DiscrepancyTypeId = DiscrepancyTypeEnum.Missing.ToString();
            }
            else
            {
                var matchingTestSets = CompareTestPointAttempts(sourceTestSet.TestPointAttempts,
                    foundTestSet.TestPointAttempts);

                if (!matchingTestSets)
                {
                    sourceTestSet.DiscrepancyTypeId = DiscrepancyTypeEnum.Discrepancy.ToString();
                    sourceTestSet.DiscrepancyTestSetId = foundTestSet.Id;
                    foundTestSet.DiscrepancyTypeId = DiscrepancyTypeEnum.Discrepancy.ToString();
                    foundTestSet.DiscrepancyTestSetId = sourceTestSet.Id;

                    _context.TestSets.AddOrUpdate(foundTestSet);

                    _context.SaveChanges();
                }
                else
                {
                    sourceTestSet.DiscrepancyTypeId = DiscrepancyTypeEnum.None.ToString();

                    foundTestSet.DiscrepancyTypeId = DiscrepancyTypeEnum.None.ToString();
                    foundTestSet.DiscrepancyTestSetId = "";
                    _context.TestSets.AddOrUpdate(foundTestSet);
                    _context.SaveChanges();
                }

            }

            // If a discrepancy is found update the client apps via SignalR
            if (sourceTestSet.DiscrepancyTypeId != DiscrepancyTypeEnum.None.ToString())
            {
                var subArea = await _context.SubAreas.Where(s => s.Id == sourceTestSet.SubAreaId).FirstOrDefaultAsync();
                var area = await _context.Areas.Where(a => a.Id == subArea.AreaId).FirstOrDefaultAsync();
                _clientService.NotifyTeamsOfDiscrepancy(area.Id, subArea.Id, sourceTestSet.FieldTeamNumber);
            } 

            return sourceTestSet;
        }

        public void NotifyViewer(string projectId, string testSetId)
        {
            var viewerClient = new RestClient(Constants.SbpWebAppUrl);

            var request = new RestRequest("SctViewer/NotifyViewer", Method.GET);
            request.AddParameter("projectId", projectId);

            var response = viewerClient.Execute(request);

            var statusCode = response.StatusCode;

            if (statusCode != HttpStatusCode.NoContent || statusCode != HttpStatusCode.OK)
            {
                System.Diagnostics.Trace.TraceError($"[SendTestSet] Issue notifying viewer of new testSet ({testSetId}) for project {projectId}");
            }
        }

        private bool CompareTestPointAttempts(IEnumerable<TestPointAttempt> sourceTpAs,
           IEnumerable<TestPointAttempt> foundTpas)
        {
            var pass = false;

            // Make sure the TPAs are ordered correctly
            sourceTpAs = sourceTpAs.OrderBy(tpa => tpa.TestAttemptNumber);
            foundTpas = foundTpas.OrderBy(tpa => tpa.TestAttemptNumber);

            // First check if the total number of testPointAttempts are the same
            if (sourceTpAs.Count() != foundTpas.Count()) return pass;

            foreach (var source in sourceTpAs)
            {
                var foundMatch = false;

                foreach (var found in foundTpas)
                {
                    if (source.TestAttemptNumber == found.TestAttemptNumber)
                    {
                        if (source.TalkIn == found.TalkIn && source.TalkOut == found.TalkOut)
                        {
                            foundMatch = true;
                        }
                    }
                }

                if (!foundMatch)
                {
                    return pass;
                }
            }

            // The foreach loop finished successfully meaning all matches were found
            pass = true;

            return pass;
        }

    }
}

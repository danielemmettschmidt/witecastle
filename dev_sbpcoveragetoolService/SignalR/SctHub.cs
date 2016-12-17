using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dev_sbpcoveragetoolService.DataObjects;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace dev_sbpcoveragetoolService.SignalR
{
    [HubName("scthub")]
    public class SctHub : Hub
    {

        public string SendToArea(string areaId, SubArea subArea, int fieldTeamNumber)
        {
            Clients.Group(areaId).DiscrepancyFound(areaId, subArea, fieldTeamNumber);
            return "Hello from the SignalR hub!";
        }

        //[AuthorizeLevel(AuthorizationLevel.User)]
        public void AreaSubscribe(String areaId)
        {
            Groups.Add(Context.ConnectionId, areaId);
        }
    }
}
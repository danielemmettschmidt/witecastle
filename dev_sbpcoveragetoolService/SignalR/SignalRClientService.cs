using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;

namespace dev_sbpcoveragetoolService.SignalR
{
    public class SignalRClientService : ISignalRClientService
    {
        private IHubConnectionContext<dynamic> _clients;


        public SignalRClientService(IHubConnectionContext<dynamic> clients)
        {
            _clients = clients;
        }

        public void Print()
        {
            Debug.Write("Print command called.");
        }

        public void NotifyTeamsOfDiscrepancy(string areaId, string subareaId, int fieldTeamNumber)
        {
            _clients.Group(areaId).discrepancyFound(areaId, subareaId, fieldTeamNumber);
        }

        public void UpdateTile(string projectId, string tileId, bool pass)
        {
            _clients.Group(projectId).broadcastMessage(tileId, pass);
        }

        public void NotifyViewerClients(string projectId)
        {
            _clients.Group(projectId).updateview();
        }
    }
}
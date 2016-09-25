using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dev_sbpcoveragetoolService.SignalR
{
    public interface ISignalRClientService
    {
        void Print();
        void NotifyTeamsOfDiscrepancy(string areaId, string subareaId, int fieldTeamNumber);
    }
}
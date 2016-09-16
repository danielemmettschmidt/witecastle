using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;

namespace dev_sbpcoveragetoolService.DataObjects
{
    public class DiscrepancyType : EntityData
    {
        public DiscrepancyType()
        {
            TestSets = new List<TestSet>();
        }

        public string Comment { get; set; }

        public virtual ICollection<TestSet> TestSets { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;
using Newtonsoft.Json;

namespace dev_sbpcoveragetoolService.DataObjects
{
    public class Account : EntityData
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        // Random input used for hashing the password
        [JsonIgnore]
        public byte[] Salt { get; set; }

        [JsonIgnore]
        public byte[] SaltedAndHashedPassword { get; set; }
    }
}
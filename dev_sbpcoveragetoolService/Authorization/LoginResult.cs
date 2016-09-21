using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace dev_sbpcoveragetoolService.Authorization
{
    public class LoginResult
    {
        [JsonProperty(PropertyName = "authenticationToken")]
        public string AuthenticationToken { get; set; }

        [JsonProperty(PropertyName = "user")]
        public LoginResultUser User { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace dev_sbpcoveragetoolService.Authorization
{
    public class LoginResultUser
    {
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }
    }
}
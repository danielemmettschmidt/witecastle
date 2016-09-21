using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using dev_sbpcoveragetoolService.Authorization;
using dev_sbpcoveragetoolService.Models;
using dev_sbpcoveragetoolService.Utilities;
using Microsoft.Azure.Mobile.Server.Config;
using Microsoft.Azure.Mobile.Server.Login;

namespace dev_sbpcoveragetoolService.Controllers
{
    [MobileAppController]
    //[AuthorizeLevel(AuthorizationLevel.Anonymous)]
    public class CustomLoginController : ApiController
    {
        private dev_sbpcoveragetoolContext _context;
        private readonly string _signingKey;
        private readonly string _audience;
        private readonly string _issuer;

        public CustomLoginController()
        {
            _context = new dev_sbpcoveragetoolContext();
            _signingKey = Environment.GetEnvironmentVariable("WEBSITE_AUTH_SIGNING_KEY") ?? "devSigningKey123devSigningKey123devSigningKey123devSigningKey123devSigningKey123devSigningKey123devSigningKey123";
            var website = Environment.GetEnvironmentVariable("WEBSITE_HOSTNAME") ?? "localhost";
            _audience = $"https://{website}/";
            _issuer = $"https://{website}/";
        }

        // POST api/CustomLogin
        public IHttpActionResult Post([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null || loginRequest.Username == null || loginRequest.Password == null ||
                loginRequest.Username.Length == 0 || loginRequest.Password.Length == 0)
            {
                return BadRequest(); ;
            }

            // TODO: This should also contain a brute-force detection strategy.

            // TODO: Inject this in the constructor
            var context = new dev_sbpcoveragetoolContext();

            // Check to see that the user exists
            var account = context.Accounts.Where(a => a.Username == loginRequest.Username).OrderBy(a => a.CreatedAt).FirstOrDefault();
            if (account == null)
            {
                return Unauthorized();
            }

            var incoming = CustomLoginProviderUtils.Hash(loginRequest.Password, account.Salt);

            if (!CustomLoginProviderUtils.SlowEquals(incoming, account.SaltedAndHashedPassword))
            {
                return Unauthorized();
            }

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, loginRequest.Username)
            };

            var token = AppServiceLoginHandler.CreateToken(
                claims, _signingKey, _audience, _issuer, TimeSpan.FromDays(30));

            return Ok(new LoginResult()
            {
                AuthenticationToken = token.RawData,
                User = new LoginResultUser { UserId = loginRequest.Username}
            });
        }
    }
}

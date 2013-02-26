using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http.SelfHost;
using ES.Lab.Api.Infrastructure.Security;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Lab.Api.Infrastructure;
using System.Web.Http;

namespace ES.Lab.Api.IntegrationTests
{
    /// <remarks>Needs admin rights</remarks>
    /// <remarks>http://stackoverflow.com/questions/2583347/c-sharp-httplistener-without-using-netsh-to-register-a-uri</remarks>
    public class GameTests : WithSelfHost
    {
        [Test]
        public void GetRequiresAuth()
        {
            var request = CreateRequest
                ("api/Game", MediaType.Json, HttpMethod.Get, new { },
                new JsonMediaTypeFormatter());

            Send(request, res => Assert.AreEqual(HttpStatusCode.Unauthorized, res.StatusCode));
        }
        
    }
}

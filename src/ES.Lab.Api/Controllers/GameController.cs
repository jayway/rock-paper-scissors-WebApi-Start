using System.Threading.Tasks;
using ES.Lab.Api.Infrastructure;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace ES.Lab.Api.Controllers
{
  
    [Authorize(Roles = "Player")]
    public class GameController : ApiController
    {
        private readonly ICommandBus _commandBus;

        public GameController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [Queryable]
        public async Task<IQueryable<OpenGame>> GetOpenGames()
        {
            return Enumerable.Empty<OpenGame>().AsQueryable();
        }  
    }

    //Temp - Remove me!
    public class OpenGame
    {
    }
}

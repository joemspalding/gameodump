using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UI.API.Controllers
{
    public class SteamController : BaseController
    {
        private IGameRepository _gameRepository;
        public SteamController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }
    }
}
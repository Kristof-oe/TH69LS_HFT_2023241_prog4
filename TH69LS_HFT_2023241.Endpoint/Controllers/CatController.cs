using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using TH69LS_HFT_2023241.Endpoint.Services;
using TH69LS_HFT_2023241.Logic;
using TH69LS_HFT_2023241.Models;

namespace TH69LS_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        ICatLogic logic;
        IHubContext<SignalRHub> hub;

        public CatController(ICatLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Cat> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Cat Read(int ID)
        {
            return this.logic.Read(ID);
        }

        [HttpPost]
        public void Create([FromBody] Cat v)
        {
            this.logic.Create(v);
            this.hub.Clients.All.SendAsync("CatCreated", v);
        }

        [HttpPut]
        public void Update([FromBody] Cat v)
        {
            this.logic.Update(v);
            this.hub.Clients.All.SendAsync("CatUpdated", v);
        }

        [HttpDelete("{id}")]
        public void Delete(int ID)
        {
            var catToDelete = this.logic.Read(ID);
            this.logic.Delete(ID);
            this.hub.Clients.All.SendAsync("CatDeleted", catToDelete);
        }
    }
}

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
    public class Cat_OwnerController : ControllerBase
    {
        ICat_OwnerLogic logic;
        IHubContext<SignalRHub> hub;

        public Cat_OwnerController(ICat_OwnerLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Cat_Owner> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Cat_Owner Read(int ID)
        {
            return this.logic.Read(ID);
            
        }

        [HttpPost]
        public void Create([FromBody] Cat_Owner v)
        {
            this.logic.Create(v);
            this.hub.Clients.All.SendAsync("Cat_OwnerCreated", v);
        }

        [HttpPut]
        public void Update([FromBody] Cat_Owner v)
        {
            this.logic.Update(v);
            this.hub.Clients.All.SendAsync("Cat_OwnerUpdated", v);
        }

        [HttpDelete("{id}")]
        public void Delete(int ID)
        {
            var dealershipToDelete = this.logic.Read(ID);
            this.logic.Delete(ID);
            this.hub.Clients.All.SendAsync("Cat_OwnerDeleted", dealershipToDelete);
        }
    }
}
